using System;
using System.Diagnostics;
using LibDatenstruktur;

namespace DtBerlinUhr.Model;

public class ModelBerlinUhr : BasePlcDtAt.BaseModel.BaseModel
{
    public bool SegmentSekunde { get; set; }
    public bool Segment5Stunden1 { get; set; } 
    public bool Segment5Stunden2 { get; set; }
    public bool Segment5Stunden3 { get; set; }
    public bool Segment5Stunden4 { get; set; } 
    public bool Segment1Stunde1 { get; set; }
    public bool Segment1Stunde2 { get; set; }
    public bool Segment1Stunde3 { get; set; }
    public bool Segment1Stunde4 { get; set; }
    public bool Segment5Minuten1 { get; set; }
    public bool Segment5Minuten2 { get; set; }
    public bool Segment5Minuten3 { get; set; }
    public bool Segment5Minuten4 { get; set; }
    public bool Segment5Minuten5 { get; set; }
    public bool Segment5Minuten6 { get; set; }
    public bool Segment5Minuten7 { get; set; }
    public bool Segment5Minuten8 { get; set; }
    public bool Segment5Minuten9 { get; set; }
    public bool Segment5Minuten10 { get; set; }
    public bool Segment5Minuten11 { get; set; }
    public bool Segment1Minute1 { get; set; }
    public bool Segment1Minute2 { get; set; }
    public bool Segment1Minute3 { get; set; }
    public bool Segment1Minute4 { get; set; }


    public byte Stunde { get; set; }
    public byte Minute { get; set; }
    public byte Sekunde { get; set; }

    private double _geschwindigkeitZeit;
    private TimeSpan _timeSpan;

    private readonly Stopwatch _stopwatch = new();
    private int _elapsedTime;

    private readonly DatenRangieren _datenRangieren;

    public ModelBerlinUhr(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        _geschwindigkeitZeit = 1;

        var dateTime = DateTime.Now;
        _timeSpan = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);

        Stunde = (byte)dateTime.Hour;
        Minute = (byte)dateTime.Minute;
        Sekunde = (byte)dateTime.Second;
    }
    protected override void ModelThread()
    {
        _stopwatch.Stop();
        _elapsedTime = (int)_stopwatch.ElapsedMilliseconds;
        _stopwatch.Restart();

        var tSpan = new TimeSpan(0, 0, 0, 0, _elapsedTime * (int)_geschwindigkeitZeit);
        _timeSpan = new TimeSpan(_timeSpan.Ticks + tSpan.Ticks);

        Stunde = (byte)_timeSpan.Hours;
        Minute = (byte)_timeSpan.Minutes;
        Sekunde = (byte)_timeSpan.Seconds;

        _datenRangieren?.Rangieren();
    }
    internal void SetCurrentTime()
    {
        var dateTime = DateTime.Now;
        _timeSpan = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
    internal int GetSekunde() => Sekunde;
    internal int GetMinute() => Minute;
    internal int GetStunde() => Stunde;
    internal void SetGeschwindigkeit(double geschwindigkeitSlider) => _geschwindigkeitZeit = geschwindigkeitSlider;
}