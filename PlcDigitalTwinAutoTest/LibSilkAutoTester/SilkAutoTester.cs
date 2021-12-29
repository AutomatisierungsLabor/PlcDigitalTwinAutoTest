using System;
using System.IO;

namespace LibSilkAutoTester;

public class SilkAutoTester
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
    
    public TestAusgabeFenster TestAusgabeFenster;
    public string TestSource { get; set; }


    public DirectoryInfo AktuellesProjekt { get; set; }
    public SilkAutoTester(string configtests)
    {
        AktuellesProjekt = new DirectoryInfo(configtests);
        TestAusgabeFenster = new TestAusgabeFenster();


        TestAusgabeFenster.Show();
    }
    public void SetProjekt(DirectoryInfo aktuellesProjekt)
    {
        AktuellesProjekt = aktuellesProjekt;
        TestSourceEinlesen();
    }
    private void TestSourceEinlesen()
    {
        try
        {
            Log.Debug("TestSource: " + @$"{AktuellesProjekt}\test.ssc");
            TestSource = File.ReadAllText(@$"{AktuellesProjekt}\test.ssc".ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}