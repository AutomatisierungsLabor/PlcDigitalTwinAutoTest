using LibConfigPlc;
using LibDatenstruktur;
using System.IO;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public Silk.Silk.BetriebsartAutoTest Betriebsart { get; set; }
    public AutoTesterWindow AutoTesterWindow;
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }


    public AutoTesterSilk(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {
        Datenstruktur = datenstruktur;
        ConfigPlc = configPlc;

        Betriebsart = new Silk.Silk.BetriebsartAutoTest();
        Betriebsart = Silk.Silk.BetriebsartAutoTest.Automatik;

        AutoTesterWindow = new AutoTesterWindow(datenstruktur, configPlc);

        AutoTesterWindow.Show();
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt) => AutoTesterWindow.SetNeuesTestProjekt(ordnerAktuellesProjekt);
    public void TestStarten() => AutoTesterWindow.ModelSilkAutoTester.AutoTestStarten();
    public void MakeEinzelnerSchritt() => AutoTesterWindow.EinzelnerSchrittAusfuehren();
    public void SetBetriebsart(bool b) => AutoTesterWindow.SetBetriebsart(b);
}