using LibPlcTools;

namespace LibAutoTestSilk.Silk;

internal class DiSetzen
{
    public enum StatusDigEingaenge
    {
        Init = 0,
        SchrittAktiv,
        SchrittAbgeschlossen
    }

    private StatusDigEingaenge _statusDigEingaenge;
    private readonly Uint _bitMuster;
    private readonly ZeitDauer _dauer;
    private readonly string _kommentar;
    private long _startZeit;

    public DiSetzen(ulong bitMuster, string dauer, string kommentar)
    {
        _statusDigEingaenge = StatusDigEingaenge.Init;
        _bitMuster = new Uint(bitMuster);
        _dauer = new ZeitDauer(dauer);
        _kommentar = kommentar;
    }

    internal void SetStartzeit(long zeit) => _startZeit = zeit;
    internal void SetAktuellerStatus(StatusDigEingaenge status) => _statusDigEingaenge = status;


    internal long GetEndZeit() => _startZeit + _dauer.DauerMs;
    internal StatusDigEingaenge GetAktuellerStatus() => _statusDigEingaenge;
    internal Uint GetBitmuster() => _bitMuster;
    internal ZeitDauer GetDauer() => _dauer;
    internal string GetKommentar() => _kommentar;
}