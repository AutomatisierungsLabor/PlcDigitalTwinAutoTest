using LibDatenstruktur;

namespace DtLap2018_3_Hydraulikaggregat.Model;

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
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLap2018.B1, _modelLap2018.B2, _modelLap2018.B3, _modelLap2018.B4, _modelLap2018.B5, _modelLap2018.F1, _modelLap2018.S1, _modelLap2018.S2);
            _datenstruktur.SetBitmuster(DatenBereich.Di, 1, _modelLap2018.S3, _modelLap2018.S4);
        }
        else
        {
            (_modelLap2018.B1, _modelLap2018.B2, _modelLap2018.B3, _modelLap2018.B4, _modelLap2018.B5, _modelLap2018.F1, _modelLap2018.S1, _modelLap2018.S2) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
            (_modelLap2018.S3, _modelLap2018.S4, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 1);
        }

        (_modelLap2018.K1, _modelLap2018.K2, _modelLap2018.P1, _modelLap2018.P2, _modelLap2018.P3, _modelLap2018.P4, _modelLap2018.P5, _modelLap2018.P6) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
        (_modelLap2018.P7, _modelLap2018.P8, _modelLap2018.Q1, _modelLap2018.Q2, _modelLap2018.Q3, _modelLap2018.Q4, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 1);
    }
}