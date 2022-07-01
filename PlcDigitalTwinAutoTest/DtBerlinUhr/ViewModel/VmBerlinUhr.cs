using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtBerlinUhr.Model;
using LibDatenstruktur;

namespace DtBerlinUhr.ViewModel;

public partial class VmBerlinUhr : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelBerlinUhr _modelBerlinUhr;
    private readonly Datenstruktur _datenstruktur;

    public VmBerlinUhr(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
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

        _modelBerlinUhr = model as ModelBerlinUhr;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelBerlinUhr == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        DoubleWinkelSekundenZeiger = _modelBerlinUhr.GetSekunde() * 6;
        DoubleWinkelSekundenZeigerKreisOderSo = _modelBerlinUhr.GetSekunde() * 6 + 45 + 180;
        DoubleWinkelMinutenZeiger = _modelBerlinUhr.GetMinute() * 6;
        DoubleWinkelStundenZeiger = _modelBerlinUhr.GetStunde() * 30 + _modelBerlinUhr.GetMinute() * 0.5;

        var farbeAus = Brushes.DarkGray;

        BrushSegmentSekunde = BaseFunctions.SetBrush(_modelBerlinUhr.SegmentSekunde, Brushes.Orange, farbeAus);
        BrushSegment5Stunden1= BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Stunden1, Brushes.Red, farbeAus);
        BrushSegment5Stunden2 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Stunden2, Brushes.Red, farbeAus);
        BrushSegment5Stunden3 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Stunden3, Brushes.Red, farbeAus);
        BrushSegment5Stunden4 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Stunden4, Brushes.Red, farbeAus);

        BrushSegment1Stunde1 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Stunde1, Brushes.Red, farbeAus);
        BrushSegment1Stunde2 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Stunde2, Brushes.Red, farbeAus);
        BrushSegment1Stunde3 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Stunde3, Brushes.Red, farbeAus);
        BrushSegment1Stunde4 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Stunde4, Brushes.Red, farbeAus);

        BrushSegment5Minuten1= BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten1, Brushes.Orange, farbeAus);
        BrushSegment5Minuten2 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten2, Brushes.OrangeRed, farbeAus);
        BrushSegment5Minuten3 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten3, Brushes.Orange, farbeAus);
        BrushSegment5Minuten4 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten4, Brushes.OrangeRed, farbeAus);
        BrushSegment5Minuten5 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten5, Brushes.Orange, farbeAus);
        BrushSegment5Minuten6 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten6, Brushes.OrangeRed, farbeAus);
        BrushSegment5Minuten7 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten7, Brushes.Orange, farbeAus);
        BrushSegment5Minuten8 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten8, Brushes.OrangeRed, farbeAus);
        BrushSegment5Minuten9 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten9, Brushes.Orange, farbeAus);
        BrushSegment5Minuten10 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten10, Brushes.OrangeRed, farbeAus);
        BrushSegment5Minuten11 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment5Minuten11, Brushes.Orange, farbeAus);

        BrushSegment1Minute1 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Minute1, Brushes.Orange, farbeAus);
        BrushSegment1Minute2 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Minute2, Brushes.Orange, farbeAus);
        BrushSegment1Minute3 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Minute3, Brushes.Orange, farbeAus);
        BrushSegment1Minute4 = BaseFunctions.SetBrush(_modelBerlinUhr.Segment1Minute4, Brushes.Orange, farbeAus);

        _modelBerlinUhr.SetGeschwindigkeit(DoubleGeschwindigkeit);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}