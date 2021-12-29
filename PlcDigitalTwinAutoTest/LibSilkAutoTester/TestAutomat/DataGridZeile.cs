namespace LibSilkAutoTester.TestAutomat;

public class DataGridZeile
{
    public int Nr { get; set; }
    public TestErgebnis Ergebnis { get; set; }
    public TestBefehle Befehle { get; set; }
    public string DigInput { get; set; }
    public string DigOutput { get; set; }
    public string Kommentar { get; set; }

    public DataGridZeile(int nr, TestErgebnis ergebnis, TestBefehle befehle, LibPlc.Uint digInput, LibPlc.Uint digOutput, string kommentar)
    {
        Nr = nr;
        Ergebnis = ergebnis;
        Befehle = befehle;
        DigInput = digInput.GetBin16Bit();
        DigOutput = digOutput.GetBin16Bit();
        Kommentar = kommentar;
    }
}