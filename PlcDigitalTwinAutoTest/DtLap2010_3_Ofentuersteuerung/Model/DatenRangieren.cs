using LibDatenstruktur;

namespace DtLap2010_3_Ofentuersteuerung.Model;

public class DatenRangieren

{
    private readonly ModelLap2010 _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelLap2010 modelLap2010, Datenstruktur datenstruktur)
    {
        _modelLap2010 = modelLap2010;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (_datenstruktur.BetriebsartProjekt)
        {
            case BetriebsartProjekt.LaborPlatte:  (_modelLap2010.B1, _modelLap2010.B2, _modelLap2010.B3, _modelLap2010.S1, _modelLap2010.S2, _modelLap2010.S3, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0); break;
            case BetriebsartProjekt.Simulation:   _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLap2010.B1, _modelLap2010.B2, _modelLap2010.B3, _modelLap2010.S1, _modelLap2010.S2, _modelLap2010.S3); break;
        }
     
        (_modelLap2010.P1, _modelLap2010.Q1, _modelLap2010.Q2, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}