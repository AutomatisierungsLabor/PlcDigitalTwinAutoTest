using System;
using System.IO;
using LibConfigPlc;
using LibDatenstruktur;

namespace LibSilkAutoTester;

public class SilkAutoTester
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
    
    public TestAusgabeFenster TestAusgabeFenster;
    public DirectoryInfo OrdnerAktuellesProjekt { get; set; }
    public  Datenstruktur Datenstruktur { get; set; }
    public LibConfigPlc.ConfigPlc ConfigPlc { get; set; }
    
    
    public SilkAutoTester(Datenstruktur datenstruktur, ConfigPlc configPlc, string configtests)
    {
        Datenstruktur=datenstruktur;
        ConfigPlc = configPlc;

        OrdnerAktuellesProjekt = new DirectoryInfo(configtests);
        TestAusgabeFenster = new TestAusgabeFenster(datenstruktur, configPlc);

        TestAusgabeFenster.Show();
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        OrdnerAktuellesProjekt = ordnerAktuellesProjekt;
        TestSourceEinlesen();
    }
    private void TestSourceEinlesen()
    {
        try
        {
            Log.Debug("TestSource: " + @$"{OrdnerAktuellesProjekt}\test.ssc");
            TestAusgabeFenster.ModelSilkAutoTester.TestSource = File.ReadAllText(@$"{OrdnerAktuellesProjekt}\test.ssc".ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void TestStarten() => TestAusgabeFenster.ModelSilkAutoTester.AutoTestStarten();
}