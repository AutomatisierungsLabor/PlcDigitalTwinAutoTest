using LibDatenstruktur;

namespace DtBlinker.Model;

public class DatenRangieren

{
    private readonly ModelBlinker _blinker;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelBlinker blinker, Datenstruktur datenstruktur)
    {
        _blinker = blinker;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (_datenstruktur.BetriebsartProjekt)
        {
            case BetriebsartProjekt.LaborPlatte: (_blinker.S1, _blinker.S2, _blinker.S3, _blinker.S4, _blinker.S5, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0); break;
            case BetriebsartProjekt.Simulation: _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _blinker.S1, _blinker.S2, _blinker.S3, _blinker.S4, _blinker.S5); break;
        }

        (_blinker.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}