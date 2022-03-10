using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2010_5_Pumpensteuerung.Model;
using LibDatenstruktur;

namespace DtLap2010_5_Pumpensteuerung.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    P1 = 21,
    P2 = 22,
    Q1 = 23,
    Y1 = 24,

    B1 = 31,
    B2 = 32,
    F1 = 33,
    S1 = 34,
    S2 = 35,
    S3 = 36,


    Pegel = 40,
    WinkelSchalter = 41,

    SchalterHand = 50,
    SchalterAus = 51,
    SchalterAutomatik = 52,
    
    ZuleitungWaagrecht = 60,
    ZuleitungSenkrecht = 61,
    AbleitungOben = 62,
    AbleitungUnten = 63


}
public class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010? _modelLap2010;
    private readonly Datenstruktur _datenstruktur;


    private const double HoeheFuellBalken = 9 * 35;

    public VmLap2010(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2010 = model as ModelLap2010;
        _datenstruktur = datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.B1] = "B1";
        Text[(int)WpfObjects.B2] = "B2";
        Text[(int)WpfObjects.F1] = "F1";

        Text[(int)WpfObjects.S3] = "Reset";
        Text[(int)WpfObjects.S2] = "Ein";
        Text[(int)WpfObjects.P1] = "Pumpe";
        Text[(int)WpfObjects.P2] = "Störung";

        Text[(int)WpfObjects.SchalterHand] = "Hand";
        Text[(int)WpfObjects.SchalterAus] = "Aus";
        Text[(int)WpfObjects.SchalterAutomatik] = "Automatik";
    }

    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        FarbeUmschalten(_modelLap2010!.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2010!.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.LightGray);
        FarbeUmschalten(_modelLap2010!.P2, (int)WpfObjects.P2, Brushes.Red, Brushes.LightGray);

        FarbeUmschalten(_modelLap2010!.Q1, (int)WpfObjects.ZuleitungWaagrecht, Brushes.Blue, Brushes.LightBlue);
        FarbeUmschalten(_modelLap2010!.Q1, (int)WpfObjects.ZuleitungSenkrecht, Brushes.Blue, Brushes.LightBlue);
        FarbeUmschalten(_modelLap2010!.Pegel > 0.01, (int)WpfObjects.AbleitungOben, Brushes.Blue, Brushes.LightBlue);
        FarbeUmschalten(_modelLap2010!.Pegel > 0.01 && _modelLap2010!.Y1, (int)WpfObjects.AbleitungUnten, Brushes.Blue, Brushes.LightBlue);

        SichtbarkeitUmschalten(_modelLap2010!.B1, (int)WpfObjects.B1);
        SichtbarkeitUmschalten(_modelLap2010!.B2, (int)WpfObjects.B2);
        SichtbarkeitUmschalten(_modelLap2010!.Q1, (int)WpfObjects.Q1);
        SichtbarkeitUmschalten(_modelLap2010!.Y1, (int)WpfObjects.Y1);

        Margin[(int)WpfObjects.Pegel] = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2010.Pegel), 0, 0);


        SchalterWinkel(_modelLap2010!.S1, _modelLap2010!.S2, WpfObjects.WinkelSchalter);

    }
    private void SchalterWinkel(bool s1, bool s2, object wpfId)
    {
        Winkel[(int)wpfId] = 0;
        if (s1) Winkel[(int)wpfId] = -45;
        if (s2) Winkel[(int)wpfId] = 45;
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S3:
                _modelLap2010!.S3 = !_modelLap2010!.S3;
                break;

            case WpfObjects.SchalterHand:
                _modelLap2010!.S1 = true;
                _modelLap2010!.S2 = false;
                break;

            case WpfObjects.SchalterAus:
                _modelLap2010!.S1 = false;
                _modelLap2010!.S2 = false;
                break;

            case WpfObjects.SchalterAutomatik:
                _modelLap2010!.S1 = false;
                _modelLap2010!.S2 = true;
                break;

            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.F1: _modelLap2010!.F1 = !_modelLap2010.F1; break;
            case WpfObjects.Y1: _modelLap2010!.Y1 = !_modelLap2010.Y1; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }


    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}