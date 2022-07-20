using LibDatenstruktur;

namespace DtSchleifmaschine.Model;

public class DatenRangieren

{
    private readonly ModelSchleifmaschine _schleifmaschine;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelSchleifmaschine schleifmaschine, Datenstruktur datenstruktur)
    {
        _schleifmaschine = schleifmaschine;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (_datenstruktur.BetriebsartProjekt)
        {
            case BetriebsartProjekt.LaborPlatte:
                (_schleifmaschine.B1, _schleifmaschine.F1, _schleifmaschine.F2, _schleifmaschine.S0, _schleifmaschine.S1, _schleifmaschine.S2, _schleifmaschine.S3, _schleifmaschine.S4) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
                break;
            case BetriebsartProjekt.Simulation:
                _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _schleifmaschine.B1, _schleifmaschine.F1, _schleifmaschine.F2, _schleifmaschine.S0, _schleifmaschine.S1, _schleifmaschine.S2, _schleifmaschine.S3, _schleifmaschine.S4);
                _datenstruktur.SetInt(DatenBereich.Ai, 0, LibPlcTools.Simatic.Analog_2_Int16(_schleifmaschine.DrehzahlSchleifmaschine, 3000));  // 0...3000U/min entspricht 0..100% 
                break;
        }

        (_schleifmaschine.P1, _schleifmaschine.P2, _schleifmaschine.P3, _schleifmaschine.Q1, _schleifmaschine.Q2, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}