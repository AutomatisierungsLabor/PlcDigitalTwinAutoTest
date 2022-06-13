using Contracts;
using LibHighResTimer;
using LibPlcTools;
using SoftCircuits.Silk;
using System.Diagnostics;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public enum DaBitmusterBlinktDebugWerte
    {
        Messwert0,
        Messwert1,
        Messwert2,
        Messwert3
    }
    private enum SchritteBlinken
    {
        Starten = 0,
        AufPosFlankeWarten = 1,
        AufNegFlankeWarten = 2
    }
    private struct BlinkerPeriode
    {
        public long Pause;
        public long Impuls;
        public long Periodendauer;
        public float Tastverhaeltnis;
        public BlinkerPeriode()
        {
            Pause = -1;
            Impuls = -1;
            Periodendauer = -1;
            Tastverhaeltnis = -1;
        }
    }

    private SchritteBlinken _schritte;
    private bool _messungAktiv;
    private bool _messungBeedet;
    private int _anzFlanken;
    private readonly Stopwatch _periodenDauerMessen = new();
    private readonly BlinkerPeriode[] _ergebnisse = new BlinkerPeriode[100];
    private int _bitMaske;
    private int _bitMuster;
    private ZeitDauer _timeOut;
    private string _kommentar;
    private ZeitDauer _periodenDauer;
    private double _tastVerhaeltnis;
    private int _anzahlPerioden;
    private double _toleranz;
    private double _periodenDauerMax;
    private double _periodenDauerMin;
    private double _tastVerhaeltnisMax;
    private double _tastVerhaeltnisMin;
    private int _guterMesswert;

    public void FuncBitmusterBlinktTesten(FunctionEventArgs args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Array.Fill(_ergebnisse, new BlinkerPeriode());

        _schritte = SchritteBlinken.Starten;

        _bitMuster = args.Parameters[0].ToInteger();
        _bitMaske = args.Parameters[1].ToInteger();
        _periodenDauer = new ZeitDauer(args.Parameters[2].ToString());
        _tastVerhaeltnis = args.Parameters[3].ToFloat();
        _anzahlPerioden = args.Parameters[4].ToInteger();
        _toleranz = args.Parameters[5].ToFloat();
        _timeOut = new ZeitDauer(args.Parameters[6].ToString());
        _kommentar = args.Parameters[7].ToString();

        _periodenDauerMax = _periodenDauer.DauerMs * (1 + _toleranz);
        _periodenDauerMin = _periodenDauer.DauerMs * (1 - _toleranz);

        _tastVerhaeltnisMax = _tastVerhaeltnis * (1 + _toleranz);
        _tastVerhaeltnisMin = _tastVerhaeltnis * (1 - _toleranz);


        var highResTimer = new HighResTimer
        {
            Interval = 1000,
            Enabled = true
        };

        highResTimer.MicroTimerElapsed += (_, _) =>
        {
            var digitalOutput = GetDigitalOutputWord();

            switch (_schritte)
            {
                case SchritteBlinken.Starten:
                    _messungAktiv = false;
                    _anzFlanken = 0;
                    _periodenDauerMessen.Restart();
                    _schritte = (digitalOutput & (short)_bitMaske) > 0
                        ? SchritteBlinken.AufNegFlankeWarten
                        : SchritteBlinken.AufPosFlankeWarten;
                    break;

                case SchritteBlinken.AufPosFlankeWarten:
                    if ((digitalOutput & (short)_bitMaske) == (short)_bitMuster)
                    {
                        if (_messungAktiv)
                            _ergebnisse[_anzFlanken / 2].Pause = _periodenDauerMessen.ElapsedMilliseconds;
                        _schritte = SchritteBlinken.AufNegFlankeWarten;
                        MessungAktiv();
                    }

                    break;

                case SchritteBlinken.AufNegFlankeWarten:
                    if ((digitalOutput & (short)_bitMaske) == 0)
                    {
                        if (_messungAktiv)
                            _ergebnisse[_anzFlanken / 2].Impuls = _periodenDauerMessen.ElapsedMilliseconds;
                        _schritte = SchritteBlinken.AufPosFlankeWarten;
                        MessungAktiv();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(_schritte.ToString());
            }
        };

        while (stopwatch.ElapsedMilliseconds < _timeOut.DauerMs)
        {
            if (_anzFlanken > 200)
            {
                highResTimer.Stop();
                DataGridUpdaten(TestAnzeige.Fehler, (uint)_bitMuster, _kommentar);
                return;
            }

            if (_messungBeedet)
            {
                highResTimer.Stop();
                DataGridUpdaten(TestAnzeige.Erfolgreich, (uint)_bitMuster, $"{_kommentar}: I:{_ergebnisse[_guterMesswert].Impuls}ms A: {_ergebnisse[_guterMesswert].Pause}ms → {100 * _ergebnisse[_guterMesswert].Tastverhaeltnis:F1}%");
                return;
            }

            Thread.Sleep(10);
        }

        highResTimer.Stop();
        DataGridUpdaten(TestAnzeige.Timeout, (uint)_bitMuster, _kommentar);
    }
    private void MessungAktiv()
    {
        var anzRichtigeMessungen = 0;

        _periodenDauerMessen.Restart();
        _messungAktiv = true;

        var perioden = _anzFlanken / 2;
        _ergebnisse[perioden].Periodendauer = _ergebnisse[perioden].Impuls + _ergebnisse[perioden].Pause;
        _ergebnisse[perioden].Tastverhaeltnis = _ergebnisse[perioden].Impuls / (float)_ergebnisse[perioden].Periodendauer;

        _anzFlanken++;

        for (var i = 0; i <= perioden; i++)
        {
            if (_ergebnisse[i].Periodendauer < _periodenDauerMin) continue;
            if (_ergebnisse[i].Periodendauer > _periodenDauerMax) continue;
            if (_ergebnisse[i].Tastverhaeltnis < _tastVerhaeltnisMin) continue;
            if (_ergebnisse[i].Tastverhaeltnis > _tastVerhaeltnisMax) continue;

            _guterMesswert = i;
            anzRichtigeMessungen++;
        }

        if (anzRichtigeMessungen >= _anzahlPerioden) _messungBeedet = true;
    }
    public string GetDaBitmusterBlinktDebugWerte(DaBitmusterBlinktDebugWerte werte)
    {
        return werte switch
        {
            DaBitmusterBlinktDebugWerte.Messwert0 => MesswerteAnzeigen(0),
            DaBitmusterBlinktDebugWerte.Messwert1 => MesswerteAnzeigen(1),
            DaBitmusterBlinktDebugWerte.Messwert2 => MesswerteAnzeigen(2),
            DaBitmusterBlinktDebugWerte.Messwert3 => MesswerteAnzeigen(3),
            _ => throw new ArgumentOutOfRangeException(nameof(werte), werte, null)
        };
    }
    private string MesswerteAnzeigen(int zeile) => "Impuls:" + _ergebnisse[zeile].Impuls + " Pause:" + _ergebnisse[zeile].Pause + " Tastverhältnis" + _ergebnisse[zeile].Tastverhaeltnis;
}