﻿using Contracts;
using DtGetriebemotor.Model;
using LibDatenstruktur;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtGetriebemotor.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20,// // enum WpfBase


    WinkelGetriebemotor = 50
}
public partial class VmGetriebemotor : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelGetriebemotor _modelGetriebemotor;
    private readonly Datenstruktur _datenstruktur;
    public VmGetriebemotor(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Visible;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        StringS1 = "①";
        StringS2 = "⓪";
        StringS3 = "I";
        StringS4 = "STOP";
        StringS5 = "II";
        StringS6 = "←";
        StringS7 = "STOP";
        StringS8 = "→";

        TransformOrigin[(int)WpfObjects.WinkelGetriebemotor] = new Point(5, 5);

        _modelGetriebemotor = model as ModelGetriebemotor;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelGetriebemotor == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityEinB1, VisibilityEinB1) = SetVisibility(_modelGetriebemotor.B1);
        (VisibilityEinB2, VisibilityEinB2) = SetVisibility(_modelGetriebemotor.B2);
        (VisibilityEinS91, VisibilityEinS91) = SetVisibility(_modelGetriebemotor.S91);

        BrushP1 = SetBrush(_modelGetriebemotor.P1, Brushes.White, Brushes.LightGray);
        BrushP2 = SetBrush(_modelGetriebemotor.P2, Brushes.LawnGreen, Brushes.LightGray);
        BrushP3 = SetBrush(_modelGetriebemotor.P3, Brushes.Red, Brushes.LightGray);

        Winkel[(int)WpfObjects.WinkelGetriebemotor] = _modelGetriebemotor.WinkelGetriebemotor;
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}