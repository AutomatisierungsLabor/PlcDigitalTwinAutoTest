namespace LibSilkAutoTester.TestAutomat;

public class DataGridZeile
{
    public int ZeilenNr { get; set; }
    public string Zeit { get; set; }
    public TestAutomat.TestAnzeige Ergebnis { get; set; }
    public string DigInput { get; set; }
    public string DigOutSoll { get; set; }
    public string DigOutIst { get; set; }
    public string Kommentar { get; set; }

    public DataGridZeile(short nr, string zeit, TestAutomat.TestAnzeige ergebnis,  string digInput, string digOutSoll, string digOutIst, string kommentar)
    {
        ZeilenNr = nr;
        Zeit = zeit;
        Ergebnis = ergebnis;
        DigInput = digInput;
        DigOutSoll = digOutSoll;
        DigOutIst = digOutIst;
        Kommentar = kommentar;
    }

}