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

        _modelWordclock = model as ModelWordclock;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelWordclock == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        DoubleWinkelSekundenZeiger = _modelWordclock.GetSekunde() * 6;
        DoubleWinkelMinutenZeiger = _modelWordclock.GetMinute() * 6;
        DoubleWinkelStundenZeiger = _modelWordclock.GetStunde() * 30 + _modelWordclock.GetMinute() * 0.5;


        BrushEins = SetBrush(_modelWordclock.TextEins, Brushes.Yellow, Brushes.DarkGray);
        BrushZwei = SetBrush(_modelWordclock.TextZwei, Brushes.Yellow, Brushes.DarkGray);
        BrushDrei = SetBrush(_modelWordclock.TextDrei, Brushes.Yellow, Brushes.DarkGray);
        BrushVier = SetBrush(_modelWordclock.TextVier, Brushes.Yellow, Brushes.DarkGray);
        BrushFuenfMinute = SetBrush(_modelWordclock.TextFuenfMinute, Brushes.Yellow, Brushes.DarkGray);
        BrushFuenfStunde = SetBrush(_modelWordclock.TextFuenfStunde, Brushes.Yellow, Brushes.DarkGray);
        BrushSechs = SetBrush(_modelWordclock.TextSechs, Brushes.Yellow, Brushes.DarkGray);
        BrushSieben = SetBrush(_modelWordclock.TextSieben, Brushes.Yellow, Brushes.DarkGray);
        BrushAcht = SetBrush(_modelWordclock.TextAcht, Brushes.Yellow, Brushes.DarkGray);
        BrushNeun = SetBrush(_modelWordclock.TextNeun, Brushes.Yellow, Brushes.DarkGray);
        BrushZehnMinute = SetBrush(_modelWordclock.TextZehnMinute, Brushes.Yellow, Brushes.DarkGray);
        BrushZehnStunde = SetBrush(_modelWordclock.TextZehnStunde, Brushes.Yellow, Brushes.DarkGray);
        BrushElf = SetBrush(_modelWordclock.TextElf, Brushes.Yellow, Brushes.DarkGray);
        BrushZwoelf = SetBrush(_modelWordclock.TextZwoelf, Brushes.Yellow, Brushes.DarkGray);
        BrushZwanzig = SetBrush(_modelWordclock.TextZwanzig, Brushes.Yellow, Brushes.DarkGray);

        BrushEs = SetBrush(_modelWordclock.TextEs, Brushes.Yellow, Brushes.DarkGray);
        BrushIst = SetBrush(_modelWordclock.TextIst, Brushes.Yellow, Brushes.DarkGray);
        BrushBald = SetBrush(_modelWordclock.TextBald, Brushes.Yellow, Brushes.DarkGray);
        BrushGleich = SetBrush(_modelWordclock.TextGleich, Brushes.Yellow, Brushes.DarkGray);
        BrushVor = SetBrush(_modelWordclock.TextVor, Brushes.Yellow, Brushes.DarkGray);
        BrushNach = SetBrush(_modelWordclock.TextNach, Brushes.Yellow, Brushes.DarkGray);
        BrushUhr = SetBrush(_modelWordclock.TextUhr, Brushes.Yellow, Brushes.DarkGray);
        BrushHalb = SetBrush(_modelWordclock.TextHalb, Brushes.Yellow, Brushes.DarkGray);
        BrushViertel = SetBrush(_modelWordclock.TextViertel, Brushes.Yellow, Brushes.DarkGray);
        

        _modelWordclock.SetGeschwindigkeit(DoubleGeschwindigkeit);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}