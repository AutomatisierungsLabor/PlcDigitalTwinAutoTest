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
        if (_datenstruktur.BetriebsartProjekt == BetriebsartProjekt.Simulation) _datenstruktur.SetInt(DatenBereich.Ai, 0, _voltmeter.AnalogSignal);

        _voltmeter.BitmusterEinerStelle = _datenstruktur.GetByte(DatenBereich.Da, 0);
        _voltmeter.BitmusterZehnerStelle = _datenstruktur.GetByte(DatenBereich.Da, 1);
        _voltmeter.BitmusterHunderterStelle = _datenstruktur.GetByte(DatenBereich.Da, 2);
        _voltmeter.BitmusterTausenderStelle = _datenstruktur.GetByte(DatenBereich.Da, 3);
        (_voltmeter.HintergrundGruen, _voltmeter.HintergrundGelb, _voltmeter.HintergrundRot, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 4);

    }
}