using LibDatenstruktur;

namespace DtLinearachse.Model;

public class DatenRangieren

{
    private readonly ModelLinearachse _modelLinearachse;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelLinearachse fibonacci, Datenstruktur datenstruktur)
    {
        _modelLinearachse = fibonacci;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLinearachse.B1, _modelLinearachse.B2, _modelLinearachse.S2, _modelLinearachse.S1, _modelLinearachse.S4, _modelLinearachse.S3, _modelLinearachse.S6, _modelLinearachse.S5);
            _datenstruktur.SetBitmuster(DatenBereich.Di, 1, _modelLinearachse.S8, _modelLinearachse.S7, _modelLinearachse.S9, _modelLinearachse.S10, _modelLinearachse.S11);
        }
        else
        {
            (_modelLinearachse.B1, _modelLinearachse.B2, _modelLinearachse.S2, _modelLinearachse.S1, _modelLinearachse.S4, _modelLinearachse.S3, _modelLinearachse.S6, _modelLinearachse.S5) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
            (_modelLinearachse.S8, _modelLinearachse.S7, _modelLinearachse.S9, _modelLinearachse.S10, _modelLinearachse.S11, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 1);
        }

        (_modelLinearachse.Q1, _modelLinearachse.Q2, _modelLinearachse.P1, _modelLinearachse.P2, _modelLinearachse.P3, _modelLinearachse.P4, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}