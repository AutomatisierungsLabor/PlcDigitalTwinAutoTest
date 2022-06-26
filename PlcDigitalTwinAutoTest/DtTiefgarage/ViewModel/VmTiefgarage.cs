using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtTiefgarage.Model;
using LibDatenstruktur;

namespace DtTiefgarage.ViewModel;

public partial class VmTiefgarage : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelTiefgarage _modelTiefgarage;
    private readonly Datenstruktur _datenstruktur;

    private const double GesamtBreite = 20 * 30;
    private const double GesamtHoehe = 25 * 30;

    public VmTiefgarage(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
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

        _modelTiefgarage = model as ModelTiefgarage;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelTiefgarage == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        StringAnzahlAutos = $"Autos in der TG: {_modelTiefgarage.AnzahlAutos}";
        StringAnzahlPersonen = $"Personen in der TG: {_modelTiefgarage.AnzahlPersonen}";

        BrushB1 = BaseFunctions.SetBrush(_modelTiefgarage.B1, Brushes.Yellow, Brushes.LightGray);
        BrushB2 = BaseFunctions.SetBrush(_modelTiefgarage.B2, Brushes.Yellow, Brushes.LightGray);

        ThicknessPkw1 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[0]);
        ThicknessPkw2 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[1]);
        ThicknessPkw3 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[2]);
        ThicknessPkw4 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[3]);
        ThicknessMensch1 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[4]);
        ThicknessMensch2 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[5]);
        ThicknessMensch3 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[6]);
        ThicknessMensch4 = PositionBerechnen(_modelTiefgarage.AllePkwPersonen[7]);
    }
    private static Thickness PositionBerechnen(FahrzeugPerson fahrzeugPerson) => fahrzeugPerson.GetPosition(GesamtBreite, GesamtHoehe);
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}