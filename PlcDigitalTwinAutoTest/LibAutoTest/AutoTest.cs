using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibSilkAutoTester;

namespace LibAutoTest;

public class AutoTest
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ObservableCollection<DirectoryInfo> AlleTestOrdner { get; set; } = new();
    public DirectoryInfo AktuellesProjekt { get; set; }
    public StackPanel StackPanel { get; set; }
    public WebBrowser WebBrowser { get; set; }
    public ViewModel.VmAutoTest VmAutoTest { get; set; }
    public LibSilkAutoTester.SilkAutoTester SilkAutoTester { get; set; }


    private bool _testWurdeSchonMalGestartet;
    private Action<string> _cbPlcConfig;

    public AutoTest(ContentControl tabItem, string configtests)
    {
        SilkAutoTester = new SilkAutoTester(configtests);

        VmAutoTest = new ViewModel.VmAutoTest(this);
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

        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(Brushes.Yellow);
        libWpf.GridZeichnen(56, 30, 30, 30, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        libWpf.ButtonText(1, 3, 1, 2, 20, buttonRand, VmAutoTest.BtnTaster, ViewModel.VmAutoTest.WpfObjects.TasterStart);

        StackPanel = libWpf.StackPanel(1, 9, 3, 20, new Thickness(5, 5, 5, 5), Brushes.LawnGreen);
        WebBrowser = libWpf.WebBrowser(10, 28, 3, 20, new Thickness(5, 5, 5, 5), Brushes.White);

        foreach (var ordner in AlleTestOrdner) StackPanel.Children.Add(libWpf.RadioButton("TestProjekte", ordner.Name, ordner, 14, TestChecked));

        // libWpf.PlcError();

    }

    public void TestStarten()
    {
        if (_testWurdeSchonMalGestartet) return;

        _testWurdeSchonMalGestartet = true;
    }

    private void TestChecked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton { Tag: DirectoryInfo } rb) return;
        AktuellesProjekt = rb.Tag as DirectoryInfo;
        if (AktuellesProjekt == null) return;

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

        SilkAutoTester.SetProjekt(AktuellesProjekt);
    }

    public void SetCallback(Action<string> callback) => _cbPlcConfig = callback;

    public void ResetSelectedProject()
    {
        foreach (RadioButton rb in StackPanel.Children)
        {
            //
        }
    }
}