using LibDatenstruktur;

namespace DtBehaeltersteuerung.Model;

public class DatenRangieren

{
    private readonly ModelBehaeltersteuerung _behaeltersteuerung;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelBehaeltersteuerung behaeltersteuerungata, Datenstruktur datenstruktur)
    {
        _behaeltersteuerung = behaeltersteuerungata;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _behaeltersteuerung.AlleMeineBehaelter[0].SchwimmerschalterOben, _behaeltersteuerung.AlleMeineBehaelter[0].SchwimmerschalterUnten,
                _behaeltersteuerung.AlleMeineBehaelter[1].SchwimmerschalterOben, _behaeltersteuerung.AlleMeineBehaelter[1].SchwimmerschalterUnten,
                _behaeltersteuerung.AlleMeineBehaelter[2].SchwimmerschalterOben, _behaeltersteuerung.AlleMeineBehaelter[2].SchwimmerschalterUnten,
                _behaeltersteuerung.AlleMeineBehaelter[3].SchwimmerschalterOben, _behaeltersteuerung.AlleMeineBehaelter[3].SchwimmerschalterUnten);
        }

        (_behaeltersteuerung.AlleMeineBehaelter[0].VentilOben, _behaeltersteuerung.AlleMeineBehaelter[1].VentilOben, _behaeltersteuerung.AlleMeineBehaelter[0].VentilOben, _behaeltersteuerung.AlleMeineBehaelter[1].VentilOben, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}