using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2018_1_Silosteuerung.Model;
using LibDatenstruktur;
using WpfAnimatedGif;

namespace DtLap2018_1_Silosteuerung.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase


    P1 = 21,
    P2 = 22,
    Q1 = 23,
    Q2 = 24,
    Y1 = 25,

    B1 = 30,
    B2 = 31,
    F1 = 32,
    F2 = 33,
    S0 = 34,
    S1 = 35,
    S2 = 36,
    S3 = 37,

    WagenNachLinks = 40,
    WagenNachRechts = 41,
    RutscheVoll = 42,

    MaterialUnten = 45,
    MaterialOben = 46,
    MaterialSilo = 47,
    MaterialSiloFuellstand = 48,
    PositionWagen = 50,
    PostionWagenInhalt = 51
}

public partial class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    public ImageAnimationController ImageAnimationController { get; set; }
    public Image ImageSchneckenFoerderer { get; set; }

    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;
    private bool _imageGeladen;

    private const double BreiteFahrbereichWagen = 300;
    public VmLap2018(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2018 = model as ModelLap2018;
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.MaterialSiloFuellstand] = Visibility.Visible;

        Text[(int)WpfObjects.F1] = "F1";
        Text[(int)WpfObjects.F2] = "F2";

        Text[(int)WpfObjects.S0] = "Aus";
        Text[(int)WpfObjects.S1] = "Ein";
        Text[(int)WpfObjects.S2] = "S2";
        Text[(int)WpfObjects.S3] = "Reset";

        Text[(int)WpfObjects.WagenNachRechts] = "Nach Rechts";
        Text[(int)WpfObjects.WagenNachLinks] = "Nach Links";

        Farbe[(int)WpfObjects.MaterialOben] = Brushes.Firebrick;
        Farbe[(int)WpfObjects.MaterialUnten] = Brushes.Firebrick;
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        //   FuellstandSilo(_modelLap2018.Silo.GetFuellstand());

        if (ImageSchneckenFoerderer != null)
        {
            if (ImageBehavior.GetIsAnimationLoaded(ImageSchneckenFoerderer))
            {
                _imageGeladen = true;
                ImageAnimationController = ImageBehavior.GetAnimationController(ImageSchneckenFoerderer);
            }
        }

        if (_modelLap2018.RutscheVoll) Text[(int)WpfObjects.RutscheVoll] = "Materialmangel"; else Text[(int)WpfObjects.RutscheVoll] = "Rutsche voll";


        FarbeUmschalten(_modelLap2018!.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2018!.F2, (int)WpfObjects.F2, Brushes.LawnGreen, Brushes.Red);

        FarbeUmschalten(_modelLap2018!.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018!.P2, (int)WpfObjects.P2, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018!.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.Gray);

        FarbeUmschalten(_modelLap2018!.S2, (int)WpfObjects.S2, Brushes.LawnGreen, Brushes.Red);

        FarbeUmschalten(_modelLap2018!.RutscheVoll, (int)WpfObjects.RutscheVoll, Brushes.Firebrick, Brushes.LightGray);

        RipSichtbarkeitUmschalten(_modelLap2018!.B1, (int)WpfObjects.B1);
        RipSichtbarkeitUmschalten(_modelLap2018!.B2, (int)WpfObjects.B2);
        RipSichtbarkeitUmschalten(_modelLap2018!.Q1, (int)WpfObjects.Q1);
        RipSichtbarkeitUmschalten(_modelLap2018!.Q2, (int)WpfObjects.Q2);
        RipSichtbarkeitUmschalten(_modelLap2018!.Y1, (int)WpfObjects.Y1);
        RipSichtbarkeitUmschalten(true, (int)WpfObjects.MaterialOben);
        RipSichtbarkeitUmschalten(true, (int)WpfObjects.MaterialUnten);

        FarbeUmschalten(_modelLap2018!.Silo.GetFuellstand() > 0.01, (int)WpfObjects.MaterialOben, Brushes.LightGray, Brushes.Firebrick);
        FarbeUmschalten(_modelLap2018!.Silo.GetFuellstand() > 0.01 && _modelLap2018.Y1, (int)WpfObjects.MaterialUnten, Brushes.LightGray, Brushes.Firebrick);

        Margin[(int)WpfObjects.PositionWagen] = new Thickness(_modelLap2018.Wagen.GetPosition().X, 0, BreiteFahrbereichWagen - _modelLap2018.Wagen.GetPosition().X, 0);
        Margin[(int)WpfObjects.PostionWagenInhalt] = new Thickness(_modelLap2018.Wagen.GetPosition().X, _modelLap2018.Wagen.GetFuellstand(), BreiteFahrbereichWagen - _modelLap2018.Wagen.GetPosition().X, 0);

        Text[(int)WpfObjects.MaterialSiloFuellstand] = (100 * _modelLap2018.Silo.GetFuellstand()).ToString("F0") + "%";

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (!_imageGeladen) return;
        if (_modelLap2018.Q2) ImageAnimationController.Play(); else ImageAnimationController.Pause();
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S0: _modelLap2018!.S0 = !gedrueckt; break;
            case WpfObjects.S1: _modelLap2018!.S1 = gedrueckt; break;
            case WpfObjects.S3: _modelLap2018!.S3 = gedrueckt; break;
            case WpfObjects.WagenNachLinks: _modelLap2018!.WagenNachLinks(); break;
            case WpfObjects.WagenNachRechts: _modelLap2018!.WagenNachRechts(); break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.F1: _modelLap2018!.F1 = !_modelLap2018.F1; break;
            case WpfObjects.F2: _modelLap2018!.F2 = !_modelLap2018.F2; break;
            case WpfObjects.S2: _modelLap2018!.S2 = !_modelLap2018.S2; break;
            case WpfObjects.RutscheVoll: _modelLap2018!.RutscheVoll = !_modelLap2018.RutscheVoll; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
    public void AnimatedLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is not Image img) return;
        _imageGeladen = true;
        ImageAnimationController = ImageBehavior.GetAnimationController(img);
    }
}