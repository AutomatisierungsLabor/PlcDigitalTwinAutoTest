using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibAutoTestSilk;
using LibConfigPlc;
using LibDatenstruktur;
using LibPlcKommunikation;

namespace LibAutoTest;

public class AutoTest
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ObservableCollection<DirectoryInfo> AlleTestOrdner { get; set; } = new();
    public DirectoryInfo AktuellesProjekt { get; set; }
    public StackPanel StackPanel { get; set; }
    public WebBrowser WebBrowser { get; set; }
    public ViewModel.VmAutoTest VmAutoTest { get; set; }
    public AutoTesterSilk AutoTesterSilk { get; set; }
    public LibWpf.LibWpf LibWpfAutoTest { get; set; }

    private bool _testWurdeSchonMalGestartet;
    private Action<string> _cbPlcConfig;

    public AutoTest(Datenstruktur datenstruktur, ConfigPlc configPlc, ContentControl tabItem, string configtests)
    {
        AutoTesterSilk = new AutoTesterSilk(datenstruktur, configPlc);

        VmAutoTest = new ViewModel.VmAutoTest(this, AutoTesterSilk);
        tabItem.DataContext = VmAutoTest;

        try
        {
            Log.Debug("Testordner lesen: " + configtests);

            var directory = new DirectoryInfo(@$"{ Environment.CurrentDirectory}\{configtests}");

            foreach (var ordner in directory.GetDirectories())
            {
                if ((ordner.Attributes & FileAttributes.Directory) == 0 || ordner.Name == ".git") continue;
                AlleTestOrdner.Add(ordner);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        LibWpfAutoTest = new LibWpf.LibWpf(tabItem);
        LibWpfAutoTest.SetBackground(Brushes.Yellow);
        LibWpfAutoTest.GridZeichnen(56, 30, 30, 30, false);

        var buttonRand = new Thickness(2, 5, 2, 5);
        LibWpfAutoTest.Button(1, 3, 1, 2, 20, buttonRand, VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.TasterStart);

        LibWpfAutoTest.Text("Einzelschritt", 5, 5, 1, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        LibWpfAutoTest.CheckBox(9, 1, 1, 2, new Thickness(2, 2, 2, 2), HorizontalAlignment.Left, VerticalAlignment.Center, VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.CheckBoxEinzelSchritt);

        LibWpfAutoTest.Button(11, 3, 1, 2, 20, new Thickness(2, 2, 2, 2), VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.TasterEinzelSchritt);


        StackPanel = LibWpfAutoTest.StackPanel(1, 9, 3, 20, new Thickness(5, 5, 5, 5), Brushes.LawnGreen);
        WebBrowser = LibWpfAutoTest.WebBrowser(10, 28, 3, 20, new Thickness(5, 5, 5, 5), Brushes.White);

        foreach (var ordner in AlleTestOrdner) StackPanel.Children.Add(LibWpfAutoTest.RadioButton("TestProjekte", ordner.Name, ordner, 14, TestChecked));
        }

    public void TestStarten()
    {
        if (_testWurdeSchonMalGestartet) return;

        _testWurdeSchonMalGestartet = true;

        AutoTesterSilk.TestStarten();
    }

    private void TestChecked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton { Tag: DirectoryInfo } rb) return;
        AktuellesProjekt = rb.Tag as DirectoryInfo;
        if (AktuellesProjekt == null) return;

        VmAutoTest.ButtonIsEnabled[(int)ViewModel.VmAutoTest.WpfObjects.TasterStart] = true;

        _cbPlcConfig(AktuellesProjekt.ToString());

        Log.Debug("Test ausgewählt: " + AktuellesProjekt.Name);

        var dateiName = $@"{AktuellesProjekt.FullName}\index.html";
        var htmlSeite = File.Exists(dateiName) ? File.ReadAllText(dateiName) : "--??--";
        var htmlCssSeite = htmlSeite;

        if (htmlSeite.Contains(@"<MeinStyleSheet/>"))
        {
            var dateiCssFile = $@"{AktuellesProjekt.FullName}\ConfigTests.css".Replace(AktuellesProjekt.Name + "\\", "");
            var styleSheet = "<style>" + File.ReadAllText(dateiCssFile) + "</style>";

            htmlCssSeite = htmlSeite.Replace(@"<MeinStyleSheet/>", styleSheet);
        }

        var dataHtmlCssSeite = Encoding.UTF8.GetBytes(htmlCssSeite);
        var stmHtmlCssSeite = new MemoryStream(dataHtmlCssSeite, 0, dataHtmlCssSeite.Length);

        WebBrowser.NavigateToStream(stmHtmlCssSeite);
        AutoTesterSilk.SetProjekt(AktuellesProjekt);
    }
    public void ResetSelectedProject()
    {
        VmAutoTest.ButtonIsEnabled[(int)ViewModel.VmAutoTest.WpfObjects.TasterStart] = false;

        foreach (var child in StackPanel.Children)
        {
            if (child is RadioButton rb) rb.IsChecked = false;
        }
    }
    public void SetCallback(Action<string> callback) => _cbPlcConfig = callback;
}