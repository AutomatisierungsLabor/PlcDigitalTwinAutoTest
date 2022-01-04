using LibPlc;

namespace LibAutoTestSilk.Silk;

internal class DaTesten
{
    public enum StatusDa
    {
        Init = 0,
        AufBitmusterWarten,
        BitmusterLiegtAn,
        SchrittAbgeschlossen,
        Timeout
    }

    public int AktuellerSchritt { get; set; }

    private StatusDa _statusDa;

    private readonly Uint _bitMuster;
    private readonly Uint _bitMaske;
    private readonly ZeitDauer _timeout;
    private readonly string _kommentar;
    private long _startZeit;
    private readonly long _dauerMin;
    private readonly long _dauerMax;


    public DaTesten(ulong bitMuster, ulong bitMaske, string dauer, double toleranz, string timeout, string kommentar)
    {
        _statusDa = StatusDa.Init;

        _bitMuster = new Uint(bitMuster);
        _bitMaske = new Uint(bitMaske);
        var dauer1 = new ZeitDauer(dauer);
        _dauerMin = (long)(dauer1.DauerMs * (1 - toleranz));
        _dauerMax = (long)(dauer1.DauerMs * (1 + toleranz));
        _timeout = new ZeitDauer(timeout);
        _kommentar = kommentar;
    }

    internal void SetStartzeit(long zeit) => _startZeit = zeit;
    internal long GetZeitdauerMin() => _startZeit + _dauerMin;
    internal long GetZeitdauerMax() => _startZeit + _dauerMax;
 

    internal StatusDa GetAktuellerStatus() => _statusDa;
    internal void SetAktuellerStatus(StatusDa status) => _statusDa = status;


    public long GetTimeoutMs() => _startZeit + _timeout.DauerMs;
    internal Uint GetBitMaske() => _bitMaske;
    internal Uint GetBitMuster() => _bitMuster;
    internal string GetKommentar() => _kommentar;
}