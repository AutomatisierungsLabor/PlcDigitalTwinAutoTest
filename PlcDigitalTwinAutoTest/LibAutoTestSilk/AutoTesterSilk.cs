using LibConfigPlc;
using LibDatenstruktur;
using System.IO;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public AutoTesterWindow AutoTesterWindow;
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }

    public AutoTesterSilk(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {
        Datenstruktur = datenstruktur;
        ConfigPlc = configPlc;

        AutoTesterWindow = new AutoTesterWindow(datenstruktur, configPlc);

        AutoTesterWindow.Show();
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt) => AutoTesterWindow.SetNeuesTestProjekt(ordnerAktuellesProjekt);
    public void TestStarten() => AutoTesterWindow.ModelSilkAutoTester.AutoTestStarten();
}