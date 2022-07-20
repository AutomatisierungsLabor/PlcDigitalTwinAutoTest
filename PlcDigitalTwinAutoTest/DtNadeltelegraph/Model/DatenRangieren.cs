using LibDatenstruktur;

namespace DtNadeltelegraph.Model;

public class DatenRangieren

{
    private readonly ModelNadeltelegraph _modelNadeltelegraph;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelNadeltelegraph nadeltelegraph, Datenstruktur datenstruktur)
    {
        _modelNadeltelegraph = nadeltelegraph;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.BetriebsartProjekt == BetriebsartProjekt.Simulation) _datenstruktur.SetByte(DatenBereich.Ai, 0, _modelNadeltelegraph.AsciiCode);

        (_modelNadeltelegraph.P1R, _modelNadeltelegraph.P1L, _modelNadeltelegraph.P2R, _modelNadeltelegraph.P2L, _modelNadeltelegraph.P3R, _modelNadeltelegraph.P3L, _modelNadeltelegraph.P4R, _modelNadeltelegraph.P4L) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
        (_modelNadeltelegraph.P5R, _modelNadeltelegraph.P5L, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 1);
    }
}