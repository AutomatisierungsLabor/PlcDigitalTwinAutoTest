using LibDatenstruktur;

namespace DtGetriebemotor.Model;

public class DatenRangieren

{
    private readonly ModelGetriebemotor _modelGetriebemotor;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelGetriebemotor getriebemotor, Datenstruktur datenstruktur)
    {
        _modelGetriebemotor = getriebemotor;
        _datenstruktur = datenstruktur;
    }

    public void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelGetriebemotor.S1, _modelGetriebemotor.S2, _modelGetriebemotor.S4, _modelGetriebemotor.S3, _modelGetriebemotor.S5, _modelGetriebemotor.S7, _modelGetriebemotor.S6, _modelGetriebemotor.S8);
            _datenstruktur.SetBitmuster(DatenBereich.Di, 1, _modelGetriebemotor.S91, _modelGetriebemotor.S92, _modelGetriebemotor.B1, _modelGetriebemotor.B2);
        }
        else
        {
            (_modelGetriebemotor.S1, _modelGetriebemotor.S2, _modelGetriebemotor.S4, _modelGetriebemotor.S3, _modelGetriebemotor.S5, _modelGetriebemotor.S7, _modelGetriebemotor.S6, _modelGetriebemotor.S8) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
            (_modelGetriebemotor.S91, _modelGetriebemotor.S92, _modelGetriebemotor.B1, _modelGetriebemotor.B2, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 1);
        }

        (_modelGetriebemotor.Q1, _modelGetriebemotor.Q2, _modelGetriebemotor.Q3, _, _modelGetriebemotor.P1, _modelGetriebemotor.P2, _modelGetriebemotor.P3, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}