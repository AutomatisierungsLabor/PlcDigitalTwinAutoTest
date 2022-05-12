using LibAutoTestSilk;
using LibConfigDt;
using LibDatenstruktur;
using LibPlcTestautomat;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibAutoTest.Model;

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
    public LehrstoffTextbausteine LehrstoffTextbausteine { get; set; }

    private Action<string> _cbPlcConfig;
    private readonly ConfigDt _configDt;

    public AutoTest(Datenstruktur datenstruktur, ConfigDt configDt, ContentControl tabItem, TestAutomat testAutomat, string configtests, CancellationTokenSource cancellationTokenSource)
    {
        _configDt = configDt;
        AutoTesterSilk = new AutoTesterSilk(datenstruktur, _configDt, testAutomat, ResetSelectedProject, cancellationTokenSource);
        VmAutoTest = new ViewModel.VmAutoTest(this, AutoTesterSilk);
        tabItem.DataContext = VmAutoTest;

        LehrstoffTextbausteine = new LehrstoffTextbausteine("json.zip");

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
        libWpfAutoTest.GridZeichnen(30, 30, 30, 30, true, true, true);

        libWpfAutoTest.ButtonBackgroundMarginRoundedSetEnableSetContend(1, 4, 1, 2, 20, 15, Brushes.LawnGreen, new Thickness(2, 5, 2, 5), VmAutoTest.ButtonTasterCommand, "TasterStart", nameof(VmAutoTest.ClickModeStart), nameof(VmAutoTest.EnableTasterStart), nameof(VmAutoTest.StringTasterStart));

        libWpfAutoTest.Text("Einzelschritt", 5, 5, 1, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpfAutoTest.CheckBox(9, 1, 1, 2, new Thickness(2, 2, 2, 2), HorizontalAlignment.Left, VerticalAlignment.Center, VmAutoTest.ButtonTasterCommand, "CheckboxEinzelschritt");

        libWpfAutoTest.ButtonBackgroundContentMarginRoundedSetVisability("Einzelschritt", 11, 5, 1, 2, 20, 15, Brushes.LawnGreen, new Thickness(2, 2, 2, 2), VmAutoTest.ButtonTasterCommand, "TasterEinzelSchritt", nameof(VmAutoTest.ClickModeEinzelSchritt), nameof(VmAutoTest.VisibilityTasterEinzelschritt));


        StackPanel = libWpfAutoTest.StackPanel(1, 9, 3, 20, new Thickness(5, 5, 5, 5), Brushes.LawnGreen);
        WebBrowser = libWpfAutoTest.WebBrowser(10, 21, 3, 20, new Thickness(5, 5, 5, 5));

        foreach (var ordner in AlleTestOrdner) StackPanel.Children.Add(libWpfAutoTest.RadioButton("TestProjekte", ordner.Name, ordner, 14, TestChecked));

        libWpfAutoTest.PlcError();
    }
    private void TestChecked(object sender, RoutedEventArgs e)
    {
        if (sender is not RadioButton { Tag: DirectoryInfo } rb) return;
        AktuellesProjekt = rb.Tag as DirectoryInfo;
        if (AktuellesProjekt == null) return;

        VmAutoTest.EnableTasterStart = true;

        _cbPlcConfig(AktuellesProjekt.ToString());

        Log.Debug("Test ausgewählt: " + AktuellesProjekt.Name);

        AutoTesterSilk.AutoTestFensterOeffnen();

        BeschreibungAnzeigen(_configDt);

        AutoTesterSilk.SetProjekt(AktuellesProjekt);
    }
    private void BeschreibungAnzeigen(ConfigDt configDt)
    {
        var html = new StringBuilder();

        foreach (var textbausteine in configDt.DtConfig.Textbausteine)
        {
            var einLehrstoffTextbaustein = LehrstoffTextbausteine.GetTextbaustein(textbausteine.BausteinId);

            var inhalt = Encoding.UTF8.GetString(Convert.FromBase64String(einLehrstoffTextbaustein.Inhalt));

            switch (textbausteine.WasAnzeigen)
            {
                case TextbausteineAnzeigen.NurInhalt:
                    html.Append(inhalt);
                    break;

                case TextbausteineAnzeigen.H1Inhalt:
                    html.Append("<H1>" + textbausteine.PrefixH1 + einLehrstoffTextbaustein.UeberschriftH1 + "</H1>");
                    html.Append(inhalt);
                    break;

                case TextbausteineAnzeigen.H1H2Inhalt:
                    html.Append("<H1>" + textbausteine.PrefixH1 + einLehrstoffTextbaustein.UeberschriftH1 + "</H1>");
                    html.Append("<H2>" + textbausteine.PrefixH2 + einLehrstoffTextbaustein.UnterUeberschriftH2 + "</H2>");
                    html.Append(inhalt);
                    break;

                case TextbausteineAnzeigen.H2Inhalt:
                    html.Append("<H2>" + textbausteine.PrefixH2 + einLehrstoffTextbaustein.UnterUeberschriftH2 + "</H2>");
                    html.Append(inhalt);
                    break;

                case TextbausteineAnzeigen.H1H2TestInhalt:
                    html.Append("<H1>" + textbausteine.PrefixH1 + einLehrstoffTextbaustein.UeberschriftH1 + "</H1>");
                    html.Append("<H2>" + textbausteine.PrefixH2 + einLehrstoffTextbaustein.UnterUeberschriftH2 + "</H2>");
                    html.Append("<H2> #" + textbausteine.Test + "</H2>");
                    html.Append(inhalt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(textbausteine.WasAnzeigen));
            }
        }

        WebBrowser.NavigateToString(html.ToString());
    }
    public void ResetSelectedProject()
    {
        VmAutoTest.EnableTasterStart = false;

        foreach (var child in StackPanel.Children)
        {
            if (child is RadioButton rb) rb.IsChecked = false;
        }
    }
    public void SetCallback(Action<string> callback) => _cbPlcConfig = callback;
}