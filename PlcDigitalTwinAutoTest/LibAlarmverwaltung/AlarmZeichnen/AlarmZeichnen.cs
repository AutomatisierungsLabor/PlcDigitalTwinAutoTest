using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibAlarmverwaltung.ViewModel;
using LibConfigDt;

namespace LibAlarmverwaltung.AlarmZeichnen;

public class AlarmZeichnen
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    private readonly ConfigDt _configDt;
    private readonly LibWpf.LibWpf _libWpf;
    private readonly Alarmverwaltung _alarmverwaltung;
    private readonly VmAlarmverwaltung _vmAlarmverwaltung;

    private int _hoeheAlarmAnzeige;


    public AlarmZeichnen(ConfigDt configDt, Grid grid, VmAlarmverwaltung vmAlarmverwaltung, Alarmverwaltung alarmverwaltung)
    {
        _configDt = configDt;
        _libWpf = new LibWpf.LibWpf(grid);
        _vmAlarmverwaltung = vmAlarmverwaltung;
        _alarmverwaltung = alarmverwaltung;

    }
    public void UpdateConfig()
    {
        switch (_configDt.DtConfig.Alarm)
        {
            case null:
                KeineAlarmeVorhandenZeichnen();
                return;
            case { Length: 0 }:
                KeineAlarmeVorhandenZeichnen();
                break;
            default:
                if (_configDt.DtConfig.Alarm!.Length > 19)
                {
                    var error = "Es sind zu viele Alarmmeldungen vorhanden:" + _configDt.DtConfig.Alarm.Length;
                    Log.Debug(error);
                    MessageBox.Show(error);
                }

                AlarmAnzeigeZeichnen();
                AlarmListeZeichnen();
                break;
        }
    }
    private void KeineAlarmeVorhandenZeichnen()
    {
        _alarmverwaltung.WindowSetSize(600, 200);

        _libWpf.Clear();
        _libWpf.GridZeichnen(30, 20, false, false, false);

        _libWpf.Text("Es sind keine Alarme parametriert!", 2, 20, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);
    }
    private void AlarmAnzeigeZeichnen()
    {
        var posY = 1;
        var anzAlarme = _configDt.DtConfig.Alarm.Length;
        _alarmverwaltung.WindowSetSize(1200, 900);

        _libWpf.Clear();
        _libWpf.GridZeichnen(40, 40, false, false, false);

        _libWpf.RectangleFillMarginStroke(1, 35, 1, anzAlarme + 1, Brushes.Lavender, new Thickness(0, 0, 0, 0), Brushes.Black, 2);
        _libWpf.Text("Alarm", 2, 4, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        _libWpf.Text("Kommt", 8, 4, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        _libWpf.Text("Geht", 14, 4, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        _libWpf.Text("Kommentar", 20, 12, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        _libWpf.Linie(1, 50, 1, 2, 0, 30, 35 * 30, 30, 2, Brushes.Black);

        _libWpf.Linie(2, 1, 1, anzAlarme + 1, 0, 0, 1, (1 + anzAlarme) * 30, 2, Brushes.Black);
        _libWpf.Linie(8, 1, 1, anzAlarme + 1, 0, 0, 1, (1 + anzAlarme) * 30, 2, Brushes.Black);
        _libWpf.Linie(14, 1, 1, anzAlarme + 1, 0, 0, 1, (1 + anzAlarme) * 30, 2, Brushes.Black);
        _libWpf.Linie(20, 1, 1, anzAlarme + 1, 0, 0, 1, (1 + anzAlarme) * 30, 2, Brushes.Black);

        posY++;

        foreach (var alarm in _configDt.DtConfig.Alarm)
        {
            _libWpf.Linie(1, 50, posY, 2, 0, 30, 35 * 30, 30, 2, Brushes.Black);

            _libWpf.RectangleMarginStrokeSetFill(1, 1, posY, 1, new Thickness(5, 5, 5, 5), Brushes.Black, 2, $"BrushAlarm{alarm.Id:D2}");
            _libWpf.TextSetContent(2, 8, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 15, Brushes.Black, $"StringBezeichnung{alarm.Id:D2}");
            _libWpf.TextSetContent(8, 8, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 15, Brushes.Black, $"StringKommt{alarm.Id:D2}");
            _libWpf.TextSetContent(14, 8, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 15, Brushes.Black, $"StringGeht{alarm.Id:D2}");
            _libWpf.TextSetContent(20, 12, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 15, Brushes.Black, $"StringKommentar{alarm.Id:D2}");
            posY++;
        }

        _hoeheAlarmAnzeige = posY;
    }
    private void AlarmListeZeichnen()
    {
        _libWpf.ButtonBackgroundContentMarginRounded("Reset", 32, 4, _hoeheAlarmAnzeige, 2, 16, 5, Brushes.DeepPink, new Thickness(0, 5, 0, 5), _vmAlarmverwaltung.ButtonTasterCommand, "-", nameof(VmAlarmverwaltung.ClickModeTasterReset));

        _hoeheAlarmAnzeige += 2;

        _libWpf.RectangleFillMarginStroke(1, 35, _hoeheAlarmAnzeige, 20, Brushes.Cyan, new Thickness(0, 0, 0, 0), Brushes.Black, 2);
        var dataGrid = _libWpf.DataGrid(1, 35, _hoeheAlarmAnzeige, 20, new Thickness(0, 0, 0, 0), _alarmverwaltung.AlarmListe);

    }
}