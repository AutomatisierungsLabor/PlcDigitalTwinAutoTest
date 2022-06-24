using LibDatenstruktur;

namespace DtAmpelVerbania.Model;

public class DatenRangieren

{
    private readonly ModelAmpelVarbania _ampelVarbania;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelAmpelVarbania ampelVarbania, Datenstruktur datenstruktur)
    {
        _ampelVarbania = ampelVarbania;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, false);
        }
      

        (_, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}