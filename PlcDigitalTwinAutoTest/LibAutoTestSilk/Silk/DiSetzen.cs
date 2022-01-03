using LibPlc;

namespace LibAutoTestSilk.Silk;

internal class DiSetzen
{
    public enum StatusDi
    {
        Init = 0,
        SchrittAktiv,
        SchrittAbgeschlossen
    }

    private static int _aktuellerSchritt;

    private StatusDi _statusDi;
    private readonly Uint _bitMuster;
    private readonly ZeitDauer _dauer;
    private readonly string _kommentar;
    private long _startZeit;

    public DiSetzen(ulong bitMuster, string dauer, string kommentar)
    {
        _statusDi = StatusDi.Init;
        _bitMuster = new Uint(bitMuster);
        _dauer = new ZeitDauer(dauer);
        _kommentar = kommentar;
    }

    internal void SetStartzeit(long zeit) => _startZeit = zeit;
    internal long GetEndZeit() => _startZeit + _dauer.DauerMs;

    internal static int GetAktuellerSchritt() => _aktuellerSchritt;
    internal static void SetAktuellerSchritt(int schritt) => _aktuellerSchritt = schritt;
    internal static void SetNaechsterSchritt() => _aktuellerSchritt++;

    internal StatusDi GetAktuellerStatus() => _statusDi;
    internal void SetAktuellerStatus(StatusDi status) => _statusDi = status;

    internal Uint GetBitmuster() => _bitMuster;
    internal ZeitDauer GetDauer() => _dauer;
    internal string GetKommentar() => _kommentar;
}