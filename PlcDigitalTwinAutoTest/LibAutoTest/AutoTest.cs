using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibAutoTest;

public partial class AutoTest
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ObservableCollection<DirectoryInfo> AlleTestOrdner { get; set; } = new();
    public DirectoryInfo AktuellesProjekt { get; set; }
    public  WebBrowser WebBrowser { get; set; }
    
    private bool _testWurdeSchonMalGestartet;
    private readonly AutoTesterWindow _autoTesterWindow;
    private  Action<string> _cbPlcConfig;

    public AutoTest(Grid grid, string configtests)
    {
        _autoTesterWindow = new AutoTesterWindow();

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

        grid.Background = Brushes.Yellow;

        var libWpf = new LibWpf.LibWpf(grid);

        AutoTestZeichnen(libWpf);


        // libWpf.PlcError();

    }

    private void TestStarten(object sender, RoutedEventArgs e)
    {
        if (_testWurdeSchonMalGestartet)
        {
            _autoTesterWindow.Show();
        }
        else
        {
            _testWurdeSchonMalGestartet = true;
        }
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
        var dataHtmlSeite = Encoding.UTF8.GetBytes(htmlSeite);
        var stmHtmlSeite = new MemoryStream(dataHtmlSeite, 0, dataHtmlSeite.Length);

        WebBrowser.NavigateToStream(stmHtmlSeite);
    }

    public void SetCallback(Action<string> callback) => _cbPlcConfig = callback;
}