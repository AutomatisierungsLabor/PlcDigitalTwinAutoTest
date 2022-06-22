using System;
using System.Diagnostics;
using LibDatenstruktur;

namespace DtWordclock.Model;

public class ModelWordclock : BasePlcDtAt.BaseModel.BaseModel
{

    public bool TextEins { get; set; }
    public bool TextZwei { get; set; }
    public bool TextDrei { get; set; }
    public bool TextVier { get; set; }
    public bool TextFuenfMinute { get; set; }
    public bool TextFuenfStunde { get; set; }
    public bool TextSechs { get; set; }
    public bool TextSieben { get; set; }
    public bool TextAcht { get; set; }
    public bool TextNeun { get; set; }
    public bool TextZehnMinute { get; set; }
    public bool TextZehnStunde { get; set; }
    public bool TextElf { get; set; }
    public bool TextZwoelf { get; set; }
    public bool TextZwanzig { get; set; }

    public bool TextEs { get; set; }
    public bool TextIst { get; set; }
    public bool TextBald { get; set; }
    public bool TextGleich { get; set; }
    public bool TextVor { get; set; }
    public bool TextNach { get; set; }
    public bool TextUhr { get; set; }
    public bool TextHalb { get; set; }
    public bool TextViertel { get; set; }




    public ushort DatumJahr { get; set; }
    public byte DatumMonat { get; set; }
    public byte DatumTag { get; set; }
    public byte DatumWochentag { get; set; }
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

        DatumJahr = (ushort)dateTime.Year;
        DatumMonat = (byte)dateTime.Month;
        DatumTag = (byte)dateTime.Day;
        DatumWochentag = (byte)dateTime.DayOfWeek;
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