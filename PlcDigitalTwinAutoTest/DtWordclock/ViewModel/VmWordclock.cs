using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
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

        BrushEins = BaseFunctions.SetBrush(_modelWordclock.TextEins, farbeEin, farbeAus);
        BrushZwei = BaseFunctions.SetBrush(_modelWordclock.TextZwei, farbeEin, farbeAus);
        BrushDrei = BaseFunctions.SetBrush(_modelWordclock.TextDrei, farbeEin, farbeAus);
        BrushVier = BaseFunctions.SetBrush(_modelWordclock.TextVier, farbeEin, farbeAus);
        BrushFuenfMinute = BaseFunctions.SetBrush(_modelWordclock.TextFuenfMinute, farbeEin, farbeAus);
        BrushFuenfStunde = BaseFunctions.SetBrush(_modelWordclock.TextFuenfStunde, farbeEin, farbeAus);
        BrushSechs = BaseFunctions.SetBrush(_modelWordclock.TextSechs, farbeEin, farbeAus);
        BrushSieben = BaseFunctions.SetBrush(_modelWordclock.TextSieben, farbeEin, farbeAus);
        BrushAcht = BaseFunctions.SetBrush(_modelWordclock.TextAcht, farbeEin, farbeAus);
        BrushNeun = BaseFunctions.SetBrush(_modelWordclock.TextNeun, farbeEin, farbeAus);
        BrushZehnMinute = BaseFunctions.SetBrush(_modelWordclock.TextZehnMinute, farbeEin, farbeAus);
        BrushZehnStunde = BaseFunctions.SetBrush(_modelWordclock.TextZehnStunde, farbeEin, farbeAus);
        BrushElf = BaseFunctions.SetBrush(_modelWordclock.TextElf, farbeEin, farbeAus);
        BrushZwoelf = BaseFunctions.SetBrush(_modelWordclock.TextZwoelf, farbeEin, farbeAus);
        BrushZwanzig = BaseFunctions.SetBrush(_modelWordclock.TextZwanzig, farbeEin, farbeAus);

        BrushEs = BaseFunctions.SetBrush(_modelWordclock.TextEs, farbeEin, farbeAus);
        BrushIst = BaseFunctions.SetBrush(_modelWordclock.TextIst, farbeEin, farbeAus);
        BrushBald = BaseFunctions.SetBrush(_modelWordclock.TextBald, farbeEin, farbeAus);
        BrushGleich = BaseFunctions.SetBrush(_modelWordclock.TextGleich, farbeEin, farbeAus);
        BrushVor = BaseFunctions.SetBrush(_modelWordclock.TextVor, farbeEin, farbeAus);
        BrushNach = BaseFunctions.SetBrush(_modelWordclock.TextNach, farbeEin, farbeAus);
        BrushUhr = BaseFunctions.SetBrush(_modelWordclock.TextUhr, farbeEin, farbeAus);
        BrushHalb = BaseFunctions.SetBrush(_modelWordclock.TextHalb, farbeEin, farbeAus);
        BrushViertel = BaseFunctions.SetBrush(_modelWordclock.TextViertel, farbeEin, farbeAus);


        _modelWordclock.SetGeschwindigkeit(DoubleGeschwindigkeit);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}