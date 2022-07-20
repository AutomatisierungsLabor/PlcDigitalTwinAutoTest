using LibDatenstruktur;
using LibPlcTools;

namespace DtLap2018_2_Abfuellanlage.Model;

public class DatenRangieren

{
    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelLap2018 modelLap2018, Datenstruktur datenstruktur)
    {
        _modelLap2018 = modelLap2018;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (_datenstruktur.BetriebsartProjekt)
        {
            case BetriebsartProjekt.LaborPlatte:
                (_modelLap2018.B1, _modelLap2018.F1, _modelLap2018.S1, _modelLap2018.S2, _modelLap2018.S3, _modelLap2018.S4, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
                break;
            case BetriebsartProjekt.Simulation:
                _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLap2018.B1, _modelLap2018.F1, _modelLap2018.S1, _modelLap2018.S2, _modelLap2018.S3, _modelLap2018.S4);
                _datenstruktur.SetInt(DatenBereich.Ai, 0, Simatic.Analog_2_Int16(_modelLap2018.Pegel, 1));
                break;
        }

        (_modelLap2018.K1, _modelLap2018.K2, _modelLap2018.P1, _modelLap2018.P2, _modelLap2018.Q1, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}