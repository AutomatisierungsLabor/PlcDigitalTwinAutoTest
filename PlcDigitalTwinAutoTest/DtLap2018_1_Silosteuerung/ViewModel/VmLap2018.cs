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
    RutscheVoll = 42


}

public class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    public ImageAnimationController ImageAnimationController { get; set; }
    public Image ImageSchneckenFoerderer { get; set; }

    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;
    private bool _imageGeladen;
    public VmLap2018(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2018 = model as ModelLap2018;
        _datenstruktur = datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S0] = "Aus";
        Text[(int)WpfObjects.S1] = "Ein";
        Text[(int)WpfObjects.S2] = "S2";
        Text[(int)WpfObjects.S3] = "Reset";

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

        FarbeUmschalten(_modelLap2018!.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2018!.F2, (int)WpfObjects.F2, Brushes.LawnGreen, Brushes.Red);

        FarbeUmschalten(_modelLap2018!.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018!.P2, (int)WpfObjects.P2, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018!.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.White);

        FarbeUmschalten(_modelLap2018!.S2, (int)WpfObjects.S2, Brushes.LawnGreen, Brushes.Red);

        FarbeUmschalten(_modelLap2018!.RutscheVoll, (int)WpfObjects.RutscheVoll, Brushes.Firebrick, Brushes.LightGray);

        SichtbarkeitUmschalten(_modelLap2018!.B1, (int)WpfObjects.B1);
        SichtbarkeitUmschalten(_modelLap2018!.B2, (int)WpfObjects.B2);
        SichtbarkeitUmschalten(_modelLap2018!.Q1, (int)WpfObjects.Q1);
        SichtbarkeitUmschalten(_modelLap2018!.Q2, (int)WpfObjects.Q2);
        SichtbarkeitUmschalten(_modelLap2018!.Y1, (int)WpfObjects.Y1);
        //  SichtbarkeitUmschalten(_modelLap2018!.Silo.GetFuellstand() > 0.01, 30);
        //   SichtbarkeitUmschalten(_modelLap2018!.Silo.GetFuellstand() > 0.01 && _modelLap2018.Y1, 31);

        /*
        TxtLagerSiloVoll = _modelLap2018.RutscheVoll ? "LagerSilo Voll" : "LagerSilo Leer";

        PositionWagenBeschriftung(_modelLap2018.Wagen.GetPosition());
        PositionWagen(_modelLap2018.Wagen.GetPosition());
        PositionWagenInhalt(_modelLap2018.Wagen.GetPosition(), _modelLap2018.Wagen.GetFuellstand());
        WagenFuellstand = Math.Floor(_modelLap2018.Wagen.GetFuellstand());

        FuellstandProzent = (100 * _modelLap2018.Silo.GetFuellstand()).ToString("F0") + "%";

        if (_mainWindow.AnimationGestartet)
        {
           
        }
        */


        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (!_imageGeladen) return;
        if (_modelLap2018.S1) ImageAnimationController.Play(); else ImageAnimationController.Pause();    //Q2

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
}