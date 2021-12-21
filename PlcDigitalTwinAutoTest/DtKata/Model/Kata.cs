using LibDatenstruktur;

namespace DtKata.Model;

public class Kata : BasePlcDtAt.BaseModel.Model
{
    public bool S1 { get; set; }
    public bool S2 { get; set; }
    public bool S3 { get; set; }
    public bool S4 { get; set; }
    public bool S5 { get; set; }
    public bool S6 { get; set; }
    public bool S7 { get; set; }
    public bool S8 { get; set; }

    public bool P1 { get; set; }
    public bool P2 { get; set; }
    public bool P3 { get; set; }
    public bool P4 { get; set; }
    public bool P5 { get; set; }
    public bool P6 { get; set; }
    public bool P7 { get; set; }
    public bool P8 { get; set; }

    public Kata()
    {
        S3 = true;
        S4 = true;
        S7 = true;
        S8 = true;
    }
    protected override void ModelTaskThread()
    {
        P1 = S1;
        P2 = S2;
        P3 = S3;
        P4 = S4;
        P5 = S5;
        P6 = S6;
        P7 = S7;
        P8 = S8;
    }
    public void SetRefDatenstuktur(Datenstruktur datenstruktur) => Datenstruktur = datenstruktur;
}