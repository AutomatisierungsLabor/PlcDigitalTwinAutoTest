using LibDatenstruktur;

namespace DtFibonacci.Model;

public class DatenRangieren

{
    private readonly ModelFibonacci _modelFibonacci;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelFibonacci fibonacci, Datenstruktur datenstruktur)
    {
        _modelFibonacci = fibonacci;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (_datenstruktur.BetriebsartProjekt)
        {
            case BetriebsartProjekt.LaborPlatte: (_modelFibonacci.S1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0); break;
            case BetriebsartProjekt.Simulation: _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelFibonacci.S1); break;
        }

        (_modelFibonacci.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}