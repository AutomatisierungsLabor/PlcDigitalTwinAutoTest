using System;
using System.IO;
using System.Windows;
using LibAutoTestSilk.Model;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;

namespace LibAutoTestSilk;

public partial class AutoTesterWindow
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ModelAutoTesterSilk ModelSilkAutoTester { get; set; }
    public VmAutoTesterSilk VmAutoTesterSilk { get; set; }
    public DirectoryInfo OrdnerAktuellesProjekt { get; set; }


    public AutoTesterWindow(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {

        VmAutoTesterSilk = new VmAutoTesterSilk(ModelSilkAutoTester);
        ModelSilkAutoTester = new ModelAutoTesterSilk(this, datenstruktur, configPlc, VmAutoTesterSilk);

        InitializeComponent();
        DataContext = VmAutoTesterSilk;

        _ = new DiDaBeschriften(GridTest);


        Closing += (_, e) =>
        {
            e.Cancel = true;
            Hide();
        };
    }
    public void SetNeuesTestProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        OrdnerAktuellesProjekt = ordnerAktuellesProjekt;

        try
        {
            Log.Debug("TestSource: " + @$"{OrdnerAktuellesProjekt}\test.ssc");

            VmAutoTesterSilk.Text[(int)VmAutoTesterSilk.WpfIndex.SoureCode] = File.ReadAllText(@$"{OrdnerAktuellesProjekt}\test.ssc".ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        for (var i = 0; i < 100; i++) VmAutoTesterSilk.SichtbarEin[i] = Visibility.Hidden;

        foreach (var zeile in ModelSilkAutoTester.ConfigPlc.Di.Zeilen)
        {
            var bitPos = (int)VmAutoTesterSilk.WpfIndex.Di01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)VmAutoTesterSilk.WpfIndex.Di17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            VmAutoTesterSilk.SichtbarEin[bitPos] = Visibility.Visible;
            VmAutoTesterSilk.Text[bitPos] = zeile.Bezeichnung;
        }

        foreach (var zeile in ModelSilkAutoTester.ConfigPlc.Da.Zeilen)
        {
            var bitPos = (int)VmAutoTesterSilk.WpfIndex.Da01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)VmAutoTesterSilk.WpfIndex.Da17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            VmAutoTesterSilk.SichtbarEin[bitPos] = Visibility.Visible;
            VmAutoTesterSilk.Text[bitPos] = zeile.Bezeichnung;
        }
    }
}