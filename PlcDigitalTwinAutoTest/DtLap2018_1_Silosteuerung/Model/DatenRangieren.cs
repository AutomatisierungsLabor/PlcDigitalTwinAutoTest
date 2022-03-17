using LibDatenstruktur;

namespace DtLap2018_1_Silosteuerung.Model;

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
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLap2018.B1, _modelLap2018.B2, _modelLap2018.F1, _modelLap2018.F2, _modelLap2018.S0, _modelLap2018.S1, _modelLap2018.S2, _modelLap2018.S3);
        }
        else
        {
            (_modelLap2018.B1, _modelLap2018.B2, _modelLap2018.F1, _modelLap2018.F2, _modelLap2018.S0, _modelLap2018.S1, _modelLap2018.S2, _modelLap2018.S3) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
        }

        (_modelLap2018.P1, _modelLap2018.P2, _modelLap2018.Q1, _modelLap2018.Q2, _modelLap2018.Y1, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}