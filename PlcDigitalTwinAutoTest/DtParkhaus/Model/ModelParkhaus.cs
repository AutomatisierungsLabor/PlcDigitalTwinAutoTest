using System;
using LibDatenstruktur;

namespace DtParkhaus.Model;

public class ModelParkhaus : BasePlcDtAt.BaseModel.BaseModel
{
    public byte[] BesetzteParkPlaetze { get; set; } = new byte[4];

    public int FreieParkplaetze { get; set; }
    public int FreieParkplaetzeSoll { get; set; }

    public bool ParkhausReihe1 { get; set; } // Signal von der SPS
    public bool ParkhausReihe2 { get; set; }
    public bool ParkhausReihe3 { get; set; }
    public bool ParkhausReihe4 { get; set; }

    public bool ParkhausSpalte1 { get; set; }
    public bool ParkhausSpalte2 { get; set; }
    public bool ParkhausSpalte3 { get; set; }
    public bool ParkhausSpalte4 { get; set; }
    public bool ParkhausSpalte5 { get; set; }
    public bool ParkhausSpalte6 { get; set; }
    public bool ParkhausSpalte7 { get; set; }
    public bool ParkhausSpalte8 { get; set; }

    private readonly DatenRangieren _datenRangieren;


    public ModelParkhaus(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {

        var random = new Random();
        random.NextBytes(BesetzteParkPlaetze);

        _datenRangieren = new DatenRangieren(this, datenstruktur);
    }
    protected override void ModelThread()
    {

        ParkhausSpalte1 = ParkhausSpalte2 = ParkhausSpalte3 = ParkhausSpalte4 = ParkhausSpalte5 = ParkhausSpalte6 = ParkhausSpalte7 = ParkhausSpalte8 = false;

        if (ParkhausReihe1) (ParkhausSpalte1, ParkhausSpalte2, ParkhausSpalte3, ParkhausSpalte4, ParkhausSpalte5, ParkhausSpalte6, ParkhausSpalte7, ParkhausSpalte8) = LibPlcTools.Bytes.AlleBitLesen(BesetzteParkPlaetze[0]);
        if (ParkhausReihe2) (ParkhausSpalte1, ParkhausSpalte2, ParkhausSpalte3, ParkhausSpalte4, ParkhausSpalte5, ParkhausSpalte6, ParkhausSpalte7, ParkhausSpalte8) = LibPlcTools.Bytes.AlleBitLesen(BesetzteParkPlaetze[1]);
        if (ParkhausReihe3) (ParkhausSpalte1, ParkhausSpalte2, ParkhausSpalte3, ParkhausSpalte4, ParkhausSpalte5, ParkhausSpalte6, ParkhausSpalte7, ParkhausSpalte8) = LibPlcTools.Bytes.AlleBitLesen(BesetzteParkPlaetze[2]);
        if (ParkhausReihe4) (ParkhausSpalte1, ParkhausSpalte2, ParkhausSpalte3, ParkhausSpalte4, ParkhausSpalte5, ParkhausSpalte6, ParkhausSpalte7, ParkhausSpalte8) = LibPlcTools.Bytes.AlleBitLesen(BesetzteParkPlaetze[3]);

        FreieParkplaetzeSoll = 0;
        for (var i = 0; i < 4; i++)
        {
            FreieParkplaetzeSoll += 8 - GesetzteBitZaehlen(BesetzteParkPlaetze[i]);
        }
        _datenRangieren?.Rangieren();
    }
    internal static int GesetzteBitZaehlen(byte wert)
    {
        var ergebnis = 0;
        for (var i = 0; i < 8; i++)
        {
            var bitMuster = (byte)(1 << i);
            if ((wert & bitMuster) == bitMuster) ergebnis++;
        }
        return ergebnis;
    }
}