using LibDatenstruktur;

namespace DtVoltmeter.Model;

public class DatenRangieren

{
    private readonly ModelVoltmeter _voltmeter;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelVoltmeter voltmeter, Datenstruktur datenstruktur)
    {
        _voltmeter = voltmeter;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, false);
        }
        else
        {
            (_, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
        }

        (_, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}