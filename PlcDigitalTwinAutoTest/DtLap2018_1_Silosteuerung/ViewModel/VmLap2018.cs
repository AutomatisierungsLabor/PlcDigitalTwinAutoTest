﻿using System;
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


        BrushF1 = SetBrush(_modelLap2018.F1, Brushes.LawnGreen, Brushes.Red);
        BrushF2 = SetBrush(_modelLap2018.F2, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = SetBrush(_modelLap2018.P1, Brushes.LawnGreen, Brushes.White);
        BrushP2 = SetBrush(_modelLap2018.P2, Brushes.Red, Brushes.White);
        BrushQ1 = SetBrush(_modelLap2018.Q1, Brushes.LawnGreen, Brushes.Gray);
        BrushS2 = SetBrush(_modelLap2018.S2, Brushes.LawnGreen, Brushes.Red);

        BrushRutscheVoll = SetBrush(_modelLap2018.RutscheVoll, Brushes.Firebrick, Brushes.LightGray);
        BrushMaterialOben = SetBrush(_modelLap2018!.Silo.GetFuellstand() > 0.01, Brushes.LightGray, Brushes.Firebrick);
        BrushMaterialUnten = SetBrush(_modelLap2018!.Silo.GetFuellstand() > 0.01 && _modelLap2018.Y1, Brushes.LightGray, Brushes.Firebrick);

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2018.B1);
        (VisibilityEinB2, VisibilityAusB2) = SetVisibility(_modelLap2018.B2);
        (VisibilityEinQ1, VisibilityAusQ1) = SetVisibility(_modelLap2018.Q1);
        (VisibilityEinQ2, VisibilityAusQ2) = SetVisibility(_modelLap2018.Q2);
        (VisibilityEinY1, VisibilityAusY1) = SetVisibility(_modelLap2018.Y1);
        (VisibilityEinMaterialOben, VisibilityAusMaterialOben) = SetVisibility(true);
        (VisibilityEinMaterialUnten, VisibilityAusMaterialUnten) = SetVisibility(true);
        
        MarginPositionWagen = new Thickness(_modelLap2018.Wagen.GetPosition().X, 0, BreiteFahrbereichWagen - _modelLap2018.Wagen.GetPosition().X, 0);
        MarginPostionWagenInhalt = new Thickness(_modelLap2018.Wagen.GetPosition().X, _modelLap2018.Wagen.GetFuellstand(), BreiteFahrbereichWagen - _modelLap2018.Wagen.GetPosition().X, 0);

        StringMaterialSiloFuellstand = (100 * _modelLap2018.Silo.GetFuellstand()).ToString("F0") + "%";

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (!_imageGeladen) return;
        if (_modelLap2018.Q2) ImageAnimationController.Play(); else ImageAnimationController.Pause();
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
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