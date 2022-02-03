using LibDatenstruktur;
using System.Diagnostics;

namespace DtBlinker.Model;

public class ModelBlinker : BasePlcDtAt.BaseModel.BaseModel
{
    public bool P1 { get; set; }
    public bool S1 { get; set; }
    public bool S2 { get; set; }
    public bool S3 { get; set; }
    public bool S4 { get; set; }
    public bool S5 { get; set; }

    public double Frequenz { get; set; }
    public double Tastverhaeltnis { get; set; }
    public double EinZeit { get; set; }
    public double AusZeit { get; set; }

    private readonly Datenstruktur _datenstruktur;
    private readonly DatenRangieren _datenRangieren;

    private bool _p1Alt;
    private readonly Stopwatch _stopwatch;
    public ModelBlinker(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _datenRangieren = new DatenRangieren(this, _datenstruktur);

        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }
    protected override void ModelThread()
    {
        long zeitDauer;

        switch (P1)
        {
            // positive Flanke
            case true when !_p1Alt:
                zeitDauer = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Restart();
                AusZeit = zeitDauer;
                break;
            // negative Flanke
            case false when _p1Alt:
                zeitDauer = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Restart();
                EinZeit = zeitDauer;
                break;
        }

        _p1Alt = P1;

        var periodenDauer = EinZeit + AusZeit;
        Frequenz = 1000 / periodenDauer;
        Tastverhaeltnis = 100 * EinZeit / periodenDauer;

        _datenRangieren?.Rangieren();
    }
    public void SetVersionLokal(string vLokal) => _datenstruktur.VersionsStringLokal = vLokal;
}