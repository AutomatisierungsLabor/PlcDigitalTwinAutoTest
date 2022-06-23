using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtWordclock.Model;
using LibDatenstruktur;

namespace DtWordclock.ViewModel;

public partial class VmWordclock : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelWordclock _modelWordclock;
    private readonly Datenstruktur _datenstruktur;

    public VmWordclock(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;

        DoubleGeschwindigkeit = 1;

        _modelWordclock = model as ModelWordclock;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelWordclock == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        DoubleWinkelSekundenZeiger = _modelWordclock.GetSekunde() * 6;
        DoubleWinkelSekundenZeigerKreisOderSo = _modelWordclock.GetSekunde() * 6 + 45 + 180;
        DoubleWinkelMinutenZeiger = _modelWordclock.GetMinute() * 6;
        DoubleWinkelStundenZeiger = _modelWordclock.GetStunde() * 30 + _modelWordclock.GetMinute() * 0.5;

        var farbeEin = Brushes.Yellow;
        var farbeAus = Brushes.DarkGray;

        BrushEins = SetBrush(_modelWordclock.TextEins, farbeEin, farbeAus);
        BrushZwei = SetBrush(_modelWordclock.TextZwei, farbeEin, farbeAus);
        BrushDrei = SetBrush(_modelWordclock.TextDrei, farbeEin, farbeAus);
        BrushVier = SetBrush(_modelWordclock.TextVier, farbeEin, farbeAus);
        BrushFuenfMinute = SetBrush(_modelWordclock.TextFuenfMinute, farbeEin, farbeAus);
        BrushFuenfStunde = SetBrush(_modelWordclock.TextFuenfStunde, farbeEin, farbeAus);
        BrushSechs = SetBrush(_modelWordclock.TextSechs, farbeEin, farbeAus);
        BrushSieben = SetBrush(_modelWordclock.TextSieben, farbeEin, farbeAus);
        BrushAcht = SetBrush(_modelWordclock.TextAcht, farbeEin, farbeAus);
        BrushNeun = SetBrush(_modelWordclock.TextNeun, farbeEin, farbeAus);
        BrushZehnMinute = SetBrush(_modelWordclock.TextZehnMinute, farbeEin, farbeAus);
        BrushZehnStunde = SetBrush(_modelWordclock.TextZehnStunde, farbeEin, farbeAus);
        BrushElf = SetBrush(_modelWordclock.TextElf, farbeEin, farbeAus);
        BrushZwoelf = SetBrush(_modelWordclock.TextZwoelf, farbeEin, farbeAus);
        BrushZwanzig = SetBrush(_modelWordclock.TextZwanzig, farbeEin, farbeAus);

        BrushEs = SetBrush(_modelWordclock.TextEs, farbeEin, farbeAus);
        BrushIst = SetBrush(_modelWordclock.TextIst, farbeEin, farbeAus);
        BrushBald = SetBrush(_modelWordclock.TextBald, farbeEin, farbeAus);
        BrushGleich = SetBrush(_modelWordclock.TextGleich, farbeEin, farbeAus);
        BrushVor = SetBrush(_modelWordclock.TextVor, farbeEin, farbeAus);
        BrushNach = SetBrush(_modelWordclock.TextNach, farbeEin, farbeAus);
        BrushUhr = SetBrush(_modelWordclock.TextUhr, farbeEin, farbeAus);
        BrushHalb = SetBrush(_modelWordclock.TextHalb, farbeEin, farbeAus);
        BrushViertel = SetBrush(_modelWordclock.TextViertel, farbeEin, farbeAus);


        _modelWordclock.SetGeschwindigkeit(DoubleGeschwindigkeit);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}