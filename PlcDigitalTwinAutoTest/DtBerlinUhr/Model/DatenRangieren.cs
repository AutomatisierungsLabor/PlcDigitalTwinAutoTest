using LibDatenstruktur;

namespace DtBerlinUhr.Model;

public class DatenRangieren

{
    private readonly ModelBerlinUhr _modelBerlinUhr;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelBerlinUhr modelBerlinUhr, Datenstruktur datenstruktur)
    {
        _modelBerlinUhr = modelBerlinUhr;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetByte(DatenBereich.Ai, 0, _modelBerlinUhr.Stunde);
            _datenstruktur.SetByte(DatenBereich.Ai, 1, _modelBerlinUhr.Minute);
            _datenstruktur.SetByte(DatenBereich.Ai, 2, _modelBerlinUhr.Sekunde);
        }

        (_modelBerlinUhr.SegmentSekunde, _modelBerlinUhr.Segment5Stunden1, _modelBerlinUhr.Segment5Stunden2, _modelBerlinUhr.Segment5Stunden3, _modelBerlinUhr.Segment5Stunden4, _modelBerlinUhr.Segment1Stunde1, _modelBerlinUhr.Segment1Stunde2, _modelBerlinUhr.Segment1Stunde3) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
        (_modelBerlinUhr.Segment1Stunde4, _modelBerlinUhr.Segment5Minuten1, _modelBerlinUhr.Segment5Minuten2, _modelBerlinUhr.Segment5Minuten3, _modelBerlinUhr.Segment5Minuten4, _modelBerlinUhr.Segment5Minuten5, _modelBerlinUhr.Segment5Minuten6, _modelBerlinUhr.Segment5Minuten7) = _datenstruktur.GetBitmuster(DatenBereich.Da, 1);
        (_modelBerlinUhr.Segment5Minuten8, _modelBerlinUhr.Segment5Minuten9, _modelBerlinUhr.Segment5Minuten10, _modelBerlinUhr.Segment5Minuten11, _modelBerlinUhr.Segment1Minute1, _modelBerlinUhr.Segment1Minute2, _modelBerlinUhr.Segment1Minute3, _modelBerlinUhr.Segment1Minute4) = _datenstruktur.GetBitmuster(DatenBereich.Da, 2);
    }
}