using LibDatenstruktur;

namespace DtLap2010_4_Abfuellanlage.Model;

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
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLap2010.B1, _modelLap2010.B2, _modelLap2010.S1, _modelLap2010.S2);
        }
        else
        {
            (_modelLap2010.B1, _modelLap2010.B2, _modelLap2010.S1, _modelLap2010.S2, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
        }

        (_modelLap2010.K1, _modelLap2010.K2, _modelLap2010.Q1, _modelLap2010.P1, _modelLap2010.Q1, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}