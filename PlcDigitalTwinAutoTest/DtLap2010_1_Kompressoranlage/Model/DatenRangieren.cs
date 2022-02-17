using LibDatenstruktur;

namespace DtLap2010_1_Kompressoranlage.Model;

public class DatenRangieren

{
    private readonly ModelLap2010 _kata;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelLap2010 kata, Datenstruktur datenstruktur)
    {
        _kata = kata;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _kata.B1, _kata.B2, _kata.F1, _kata.S1, _kata.S2);
        }
        else
        {
            (_kata.B1, _kata.B2, _kata.F1, _kata.S1, _kata.S2, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
        }

        (_kata.P1, _kata.P2, _kata.Q1, _kata.Q2, _kata.Q3, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}