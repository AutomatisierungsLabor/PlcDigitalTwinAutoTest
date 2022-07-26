using LibDatenstruktur;

namespace DtSchleifmaschine.Model;

public class ModelSchleifmaschine : BasePlcDtAt.BaseModel.BaseModel
{
    public bool B1 { get; set; }    // Störung "Motor Übersynchron"
    public bool F1 { get; set; }    // Thermorelais langsame Drehzahl
    public bool F2 { get; set; }    // Thermorelais schnelle Drehzahl
    public bool S0 { get; set; }    // Taster ( ⓪ ) 
    public bool S1 { get; set; }    // Taster ( Ⅰ )  
    public bool S2 { get; set; }    // Taster ( Ⅱ )  
    public bool S3 { get; set; }    // Not-Halt
    public bool S4 { get; set; }    // Störung quittieren
    public bool P1 { get; set; }    // Meldeleuchte "Taster langsam"
    public bool P2 { get; set; }    // Meldeleuchte "Taster schnell"
    public bool P3 { get; set; }    // Meldeleuchte "Störung"
    public bool Q1 { get; set; }    // Getriebemotor Langsam
    public bool Q2 { get; set; }    // Getriebemotor Schnell

    public double WinkelSchleifmaschine { get; set; }
    public double DrehzahlSchleifmaschine { get; set; }

    private const double SynchrondrehzahlLangsam = 1000;
    private const double SynchrondrehzahlSchnell = 3000;
    private const double BeschleunigungLangsam = 0.01;
    private const double BeschleunigungSchnell = 0.01;
    private const double VerzoegerungDrehzahl = 0.999;

    private const double DrehzahlWinkelFaktor = 0.002;

    private readonly DatenRangieren _datenRangieren;
    public ModelSchleifmaschine(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelSetValues()
    {
        F1 = true;
        F2 = true;
        S0 = true;
        S3 = true;
    }
    protected override void ModelThread(double dT)
    {
        if (Q1) DrehzahlSchleifmaschine += (SynchrondrehzahlLangsam - DrehzahlSchleifmaschine) * BeschleunigungLangsam;
        if (Q2) DrehzahlSchleifmaschine += (SynchrondrehzahlSchnell - DrehzahlSchleifmaschine) * BeschleunigungSchnell;

        DrehzahlSchleifmaschine *= VerzoegerungDrehzahl;

        WinkelSchleifmaschine += DrehzahlSchleifmaschine * DrehzahlWinkelFaktor;

        if (WinkelSchleifmaschine > 360) WinkelSchleifmaschine -= 360;
        if (WinkelSchleifmaschine < 0) WinkelSchleifmaschine += 360;

        if (Q1 & DrehzahlSchleifmaschine > SynchrondrehzahlLangsam) B1 = true;

        _datenRangieren?.Rangieren();
    }
}