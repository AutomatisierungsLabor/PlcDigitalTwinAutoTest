﻿using DtLap2018_1_Silosteuerung.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using WpfAnimatedGif;

namespace DtLap2018_1_Silosteuerung.ViewModel;


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

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;
    }
    protected override void ViewModelAufrufThread()
    {
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        //   FuellstandSilo(_modelLap2018.Silo.GetFuellstand());

        if (ImageSchneckenFoerderer != null)
        {
            if (ImageBehavior.GetIsAnimationLoaded(ImageSchneckenFoerderer))
            {
                _imageGeladen = true;
                ImageAnimationController = ImageBehavior.GetAnimationController(ImageSchneckenFoerderer);
            }
        }

        StringRutscheVoll = _modelLap2018.RutscheVoll ? "Materialmangel" : "Rutsche voll";


        BrushF1 = BaseFunctions.SetBrush(_modelLap2018.F1, Brushes.LawnGreen, Brushes.Red);
        BrushF2 = BaseFunctions.SetBrush(_modelLap2018.F2, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = BaseFunctions.SetBrush(_modelLap2018.P1, Brushes.LawnGreen, Brushes.White);
        BrushP2 = BaseFunctions.SetBrush(_modelLap2018.P2, Brushes.Red, Brushes.White);
        BrushQ1 = BaseFunctions.SetBrush(_modelLap2018.Q1, Brushes.LawnGreen, Brushes.Gray);
        BrushS2 = BaseFunctions.SetBrush(_modelLap2018.S2, Brushes.LawnGreen, Brushes.Red);

        BrushRutscheVoll = BaseFunctions.SetBrush(_modelLap2018.RutscheVoll, Brushes.Firebrick, Brushes.LightGray);
        BrushMaterialOben = BaseFunctions.SetBrush(_modelLap2018!.Silo.GetFuellstand() > 0.01, Brushes.LightGray, Brushes.Firebrick);
        BrushMaterialUnten = BaseFunctions.SetBrush(_modelLap2018!.Silo.GetFuellstand() > 0.01 && _modelLap2018.Y1, Brushes.LightGray, Brushes.Firebrick);

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLap2018.B1);
        (VisibilityEinB2, VisibilityAusB2) = BaseFunctions.SetVisibility(_modelLap2018.B2);
        (VisibilityEinQ1, VisibilityAusQ1) = BaseFunctions.SetVisibility(_modelLap2018.Q1);
        (VisibilityEinQ2, VisibilityAusQ2) = BaseFunctions.SetVisibility(_modelLap2018.Q2);
        (VisibilityEinY1, VisibilityAusY1) = BaseFunctions.SetVisibility(_modelLap2018.Y1);
        (VisibilityEinMaterialOben, VisibilityAusMaterialOben) = BaseFunctions.SetVisibility(true);
        (VisibilityEinMaterialUnten, VisibilityAusMaterialUnten) = BaseFunctions.SetVisibility(true);

        MarginPositionWagen = new Thickness(_modelLap2018.Wagen.GetPosition().X, 0, BreiteFahrbereichWagen - _modelLap2018.Wagen.GetPosition().X, 0);
        MarginPostionWagenInhalt = new Thickness(_modelLap2018.Wagen.GetPosition().X, _modelLap2018.Wagen.GetFuellstand(), BreiteFahrbereichWagen - _modelLap2018.Wagen.GetPosition().X, 0);

        StringMaterialSiloFuellstand = (100 * _modelLap2018.Silo.GetFuellstand()).ToString("F0") + "%";

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (!_imageGeladen) return;
        if (_modelLap2018.Q2) ImageAnimationController.Play(); else ImageAnimationController.Pause();
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