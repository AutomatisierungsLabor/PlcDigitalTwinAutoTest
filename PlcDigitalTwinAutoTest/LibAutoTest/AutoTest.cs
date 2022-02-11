using LibAutoTestSilk;
using LibConfigPlc;
using LibDatenstruktur;
using LibPlcKommunikation;
using LibPlcTestautomat;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

    private Action<string> _cbPlcConfig;

    public AutoTest(Datenstruktur datenstruktur, PlcDaemon plcDaemon, ConfigPlc configPlc, ContentControl tabItem, TestAutomat testAutomat, string configtests, CancellationTokenSource cancellationTokenSource)
    {
        AutoTesterSilk = new AutoTesterSilk(datenstruktur, configPlc, testAutomat, cancellationTokenSource);
        VmAutoTest = new ViewModel.VmAutoTest(this, AutoTesterSilk, datenstruktur, plcDaemon, cancellationTokenSource);
        tabItem.DataContext = VmAutoTest;

        try
        {
            Log.Debug("Testordner lesen: " + configtests);
            var directory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), configtests));

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

        var libWpfAutoTest = new LibWpf.LibWpf(tabItem);

        libWpfAutoTest.SetBackground(Brushes.Yellow);
        libWpfAutoTest.GridZeichnen(56, 30, 30, 30, false);

        var buttonRand = new Thickness(2, 5, 2, 5);
        libWpfAutoTest.ButtonRounded(1, 3, 1, 2, 20, 15, buttonRand, Brushes.LawnGreen, VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.TasterStart);

        libWpfAutoTest.Text("Einzelschritt", 5, 5, 1, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpfAutoTest.CheckBox(9, 1, 1, 2, new Thickness(2, 2, 2, 2), HorizontalAlignment.Left, VerticalAlignment.Center, VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.CheckBoxEinzelSchritt);

        libWpfAutoTest.ButtonRounded(11, 3, 1, 2, 20, 15, new Thickness(2, 2, 2, 2), Brushes.LawnGreen, VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.TasterEinzelSchritt);


        StackPanel = libWpfAutoTest.StackPanel(1, 9, 3, 20, new Thickness(5, 5, 5, 5), Brushes.LawnGreen);
        WebBrowser = libWpfAutoTest.WebBrowser(10, 28, 3, 20, new Thickness(5, 5, 5, 5), Brushes.White);

        foreach (var ordner in AlleTestOrdner) StackPanel.Children.Add(libWpfAutoTest.RadioButton("TestProjekte", ordner.Name, ordner, 14, TestChecked));

        libWpfAutoTest.PlcError();
    }
    private void TestChecked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton { Tag: DirectoryInfo } rb) return;
        AktuellesProjekt = rb.Tag as DirectoryInfo;
        if (AktuellesProjekt == null) return;

        VmAutoTest.ButtonIsEnabled[(int)ViewModel.VmAutoTest.WpfObjects.TasterStart] = true;

        _cbPlcConfig(AktuellesProjekt.ToString());

        Log.Debug("Test ausgewählt: " + AktuellesProjekt.Name);

        AutoTesterSilk.AutoTestFensterOeffnen();

        var dateiName = Path.Combine(AktuellesProjekt.FullName, "index.html");
        var htmlSeite = File.Exists(dateiName) ? File.ReadAllText(dateiName) : "--??--";
        var htmlCssSeite = htmlSeite;

        if (htmlSeite.Contains(@"<MeinStyleSheet/>"))
        {
            var dateiCssFile = Path.Combine(AktuellesProjekt.FullName, "ConfigTests.css").Replace(AktuellesProjekt.Name + "\\", "");
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