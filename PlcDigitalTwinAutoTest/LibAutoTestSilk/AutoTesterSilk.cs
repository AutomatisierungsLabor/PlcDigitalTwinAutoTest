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
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        AutoTesterWindow.OrdnerAktuellesProjekt = ordnerAktuellesProjekt;
        AutoTesterWindow.VmAutoTesterSilk.SetNeuesTestProjekt(ordnerAktuellesProjekt, ConfigPlc);
    }
    public void TestStarten()
    {
        AutoTesterWindow.Show();
        AutoTesterWindow.ModelSilkAutoTester.AutoTestStarten();
    }
}