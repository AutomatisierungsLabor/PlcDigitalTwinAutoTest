using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibAutoTest;

public partial class AutoTest
{

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ObservableCollection<DirectoryInfo> AlleTestOrdner { get; set; } = new();

    private bool _testWurdeSchonMalGestartet;
    private readonly AutoTesterWindow _autoTesterWindow;

    public AutoTest(Grid grid, string configtests)
    {
        _autoTesterWindow = new AutoTesterWindow();

        try
        {
            Log.Debug("Testordner lesen: " + configtests);

            var aktuellerOrder = Environment.CurrentDirectory;
            var directory = new DirectoryInfo(@$"{aktuellerOrder}\{configtests}");

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
}