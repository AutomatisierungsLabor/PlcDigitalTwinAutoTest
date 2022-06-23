using System;
using System.Diagnostics;
using LibDatenstruktur;

namespace DtWordclock.Model;

public class ModelWordclock : BasePlcDtAt.BaseModel.BaseModel
{
    public bool TextEins { get; set; }          // 0.0
    public bool TextZwei { get; set; }          // 0.1
    public bool TextDrei { get; set; }          // 0.2
    public bool TextVier { get; set; }          // 0.3
    public bool TextFuenfMinute { get; set; }   // 0.4
    public bool TextFuenfStunde { get; set; }   // 0.5
    public bool TextSechs { get; set; }         // 0.6
    public bool TextSieben { get; set; }        // 0.7

    public bool TextAcht { get; set; }          // 1.0
    public bool TextNeun { get; set; }          // 1.1
    public bool TextZehnMinute { get; set; }    // 1.2
    public bool TextZehnStunde { get; set; }    // 1.3
    public bool TextElf { get; set; }           // 1.4
    public bool TextZwoelf { get; set; }        // 1.5
    public bool TextZwanzig { get; set; }       // 1.6
    public bool TextUhr { get; set; }           // 1.7

    public bool TextEs { get; set; }            // 2.0
    public bool TextIst { get; set; }           // 2.1
    public bool TextBald { get; set; }          // 2.2
    public bool TextGleich { get; set; }        // 2.3
    public bool TextVor { get; set; }           // 2.4
    public bool TextNach { get; set; }          // 2.5
    public bool TextHalb { get; set; }          // 2.6
    public bool TextViertel { get; set; }       // 2.7



    public byte Stunde { get; set; }
    public byte Minute { get; set; }
    public byte Sekunde { get; set; }

    private double _geschwindigkeitZeit;
    private TimeSpan _timeSpan;

    private readonly Stopwatch _stopwatch = new();
    private int _elapsedTime;

    private readonly DatenRangieren _datenRangieren;

    public ModelWordclock(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
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