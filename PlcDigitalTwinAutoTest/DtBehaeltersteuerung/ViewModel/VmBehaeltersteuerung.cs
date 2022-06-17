using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBehaeltersteuerung.Model;
using LibDatenstruktur;

namespace DtBehaeltersteuerung.ViewModel;

public partial class VmBehaeltersteuerung : BasePlcDtAt.BaseViewModel.VmBase
{
    public ComboBox VmComboBox { get; set; }

    private readonly ModelBehaeltersteuerung _modelBehaeltersteuerung;
    private readonly Datenstruktur _datenstruktur;

    public VmBehaeltersteuerung(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelBehaeltersteuerung = model as ModelBehaeltersteuerung;
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelBehaeltersteuerung == null) return;

        if (VmComboBox != null)
        {
            if (VmComboBox.Items.Count == 0)
            {
                Application.Current.Dispatcher.Invoke(() => { VmComboBox.Items.Add("0000"); });

                foreach (var permutation in _modelBehaeltersteuerung.PermutationList)
                {
                    Application.Current.Dispatcher.Invoke(() => { VmComboBox.Items.Add(permutation.GetText()); });
                }

                VmComboBox.SelectionChanged += (_, e) =>
                {
                     _modelBehaeltersteuerung.AktivePermutation = e.AddedItems[0]?.ToString();
                };
            }
        }

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BoolAutomatikStarten = !_modelBehaeltersteuerung.AutomatikModusAktiv();
        StringAutomatikStarten = _modelBehaeltersteuerung.AutomatikModusAktiv() ? "Bitte warten" : "Automatik starten";

        BoolDropdownEnabled = _modelBehaeltersteuerung.AutomatikModusAktiv();

        BrushesZuleitung1 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[0].VentilOben, Brushes.Blue, Brushes.LightBlue);
        BrushesZuleitung2 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[1].VentilOben, Brushes.Blue, Brushes.LightBlue);
        BrushesZuleitung3 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[2].VentilOben, Brushes.Blue, Brushes.LightBlue);
        BrushesZuleitung4 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[3].VentilOben, Brushes.Blue, Brushes.LightBlue);

        (VisibilityEinQ1, VisibilityAusQ1) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[0].VentilOben);
        (VisibilityEinQ3, VisibilityAusQ3) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[1].VentilOben);
        (VisibilityEinQ5, VisibilityAusQ5) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[2].VentilOben);
        (VisibilityEinQ7, VisibilityAusQ7) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[3].VentilOben);

        (VisibilityEinQ2, VisibilityAusQ2) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[0].VentilUnten);
        (VisibilityEinQ4, VisibilityAusQ4) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[1].VentilUnten);
        (VisibilityEinQ6, VisibilityAusQ6) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[2].VentilUnten);
        (VisibilityEinQ8, VisibilityAusQ8) = SetVisibility(_modelBehaeltersteuerung.AlleMeineBehaelter[3].VentilUnten);

        BrushesAbleitungOben1 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[0].BehaelterLeer(), Brushes.LightBlue, Brushes.Blue);
        BrushesAbleitungOben2 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[1].BehaelterLeer(), Brushes.LightBlue, Brushes.Blue);
        BrushesAbleitungOben3 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[2].BehaelterLeer(), Brushes.LightBlue, Brushes.Blue);
        BrushesAbleitungOben4 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[3].BehaelterLeer(), Brushes.LightBlue, Brushes.Blue);

        var ableitungUnten1 = !_modelBehaeltersteuerung.AlleMeineBehaelter[0].BehaelterLeer() && _modelBehaeltersteuerung.AlleMeineBehaelter[0].VentilUnten;
        var ableitungUnten2 = !_modelBehaeltersteuerung.AlleMeineBehaelter[1].BehaelterLeer() && _modelBehaeltersteuerung.AlleMeineBehaelter[1].VentilUnten;
        var ableitungUnten3 = !_modelBehaeltersteuerung.AlleMeineBehaelter[2].BehaelterLeer() && _modelBehaeltersteuerung.AlleMeineBehaelter[2].VentilUnten;
        var ableitungUnten4 = !_modelBehaeltersteuerung.AlleMeineBehaelter[3].BehaelterLeer() && _modelBehaeltersteuerung.AlleMeineBehaelter[3].VentilUnten;
        var ableitungUnten = ableitungUnten1 || ableitungUnten2 || ableitungUnten3 || ableitungUnten4;

        BrushesAbleitungUnten = SetBrush(ableitungUnten, Brushes.Blue, Brushes.LightBlue);
        
        BrushesB1 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[0].SchwimmerschalterOben, Brushes.Red, Brushes.LawnGreen);
        BrushesB2 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[0].SchwimmerschalterUnten, Brushes.Red, Brushes.LawnGreen);
        BrushesB3 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[1].SchwimmerschalterOben, Brushes.Red, Brushes.LawnGreen);
        BrushesB4 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[1].SchwimmerschalterUnten, Brushes.Red, Brushes.LawnGreen);
        BrushesB5 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[2].SchwimmerschalterOben, Brushes.Red, Brushes.LawnGreen);
        BrushesB6 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[2].SchwimmerschalterUnten, Brushes.Red, Brushes.LawnGreen);
        BrushesB7 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[3].SchwimmerschalterOben, Brushes.Red, Brushes.LawnGreen);
        BrushesB8 = SetBrush(_modelBehaeltersteuerung.AlleMeineBehaelter[3].SchwimmerschalterUnten, Brushes.Red, Brushes.LawnGreen);

        const double behaelterHoehe = 10 * 30;
        ThicknessFuellstand1 = new Thickness(0, behaelterHoehe - _modelBehaeltersteuerung.AlleMeineBehaelter[0].Pegel * behaelterHoehe, 0, 0);
        ThicknessFuellstand2 = new Thickness(0, behaelterHoehe - _modelBehaeltersteuerung.AlleMeineBehaelter[1].Pegel * behaelterHoehe, 0, 0);
        ThicknessFuellstand3 = new Thickness(0, behaelterHoehe - _modelBehaeltersteuerung.AlleMeineBehaelter[2].Pegel * behaelterHoehe, 0, 0);
        ThicknessFuellstand4 = new Thickness(0, behaelterHoehe - _modelBehaeltersteuerung.AlleMeineBehaelter[3].Pegel * behaelterHoehe, 0, 0);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}