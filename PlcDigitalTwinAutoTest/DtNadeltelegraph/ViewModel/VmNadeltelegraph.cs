using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Contracts;
using DtNadeltelegraph.Model;
using LibDatenstruktur;

namespace DtNadeltelegraph.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    Zeiger1 = 21,
    Zeiger2 = 22,
    Zeiger3 = 23,
    Zeiger4 = 24,
    Zeiger5 = 25,

    AsciiCode = 28,

    LinieRechtsOben1 = 30,
    LinieRechtsOben2 = 31,
    LinieRechtsOben3 = 32,
    LinieRechtsOben4 = 33,

    LinieRechtsUnten1 = 36,
    LinieRechtsUnten2 = 36,
    LinieRechtsUnten3 = 37,
    LinieRechtsUnten4 = 38,

    LinieLinksOben1 = 40,
    LinieLinksOben2 = 41,
    LinieLinksOben3 = 42,
    LinieLinksOben4 = 43,

    LinieLinksUnten1 = 45,
    LinieLinksUnten2 = 46,
    LinieLinksUnten3 = 47,
    LinieLinksUnten4 = 48,

    BuchstabeA = 50,
    BuchstabeB = 51,
    BuchstabeD = 52,
    BuchstabeE = 53,
    BuchstabeF = 54,
    BuchstabeG = 55,
    BuchstabeH = 56,
    BuchstabeI = 57,
    BuchstabeK = 58,
    BuchstabeL = 59,
    BuchstabeM = 60,
    BuchstabeN = 61,
    BuchstabeO = 62,
    BuchstabeP = 63,
    BuchstabeR = 64,
    BuchstabeS = 65,
    BuchstabeT = 66,
    BuchstabeV = 67,
    BuchstabeW = 68,
    BuchstabeY = 69
}
public class VmNadeltelegraph : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelNadeltelegraph _modelNadeltelegraph;
    private readonly Datenstruktur _datenstruktur;

    public VmNadeltelegraph(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelNadeltelegraph = model as ModelNadeltelegraph;
        _datenstruktur = datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;


        Text[(int)WpfObjects.BuchstabeA] = "A";
        Text[(int)WpfObjects.BuchstabeB] = "B";
        Text[(int)WpfObjects.BuchstabeD] = "D";
        Text[(int)WpfObjects.BuchstabeE] = "E";
        Text[(int)WpfObjects.BuchstabeF] = "F";
        Text[(int)WpfObjects.BuchstabeG] = "G";
        Text[(int)WpfObjects.BuchstabeH] = "H";
        Text[(int)WpfObjects.BuchstabeI] = "I";
        Text[(int)WpfObjects.BuchstabeK] = "K";
        Text[(int)WpfObjects.BuchstabeL] = "L";
        Text[(int)WpfObjects.BuchstabeM] = "M";
        Text[(int)WpfObjects.BuchstabeN] = "N";
        Text[(int)WpfObjects.BuchstabeO] = "O";
        Text[(int)WpfObjects.BuchstabeP] = "P";
        Text[(int)WpfObjects.BuchstabeR] = "R";
        Text[(int)WpfObjects.BuchstabeS] = "S";
        Text[(int)WpfObjects.BuchstabeT] = "T";
        Text[(int)WpfObjects.BuchstabeV] = "V";
        Text[(int)WpfObjects.BuchstabeW] = "W";
        Text[(int)WpfObjects.BuchstabeY] = "Y";

    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelNadeltelegraph == null) return;
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        Text[(int)WpfObjects.AsciiCode] = $"ASCII Code: {_modelNadeltelegraph.Zeichen} (16#{_modelNadeltelegraph.Zeichen:X2})";

        _modelNadeltelegraph.AlleZeiger[0].SetPosition(_modelNadeltelegraph.P1R, _modelNadeltelegraph.P1L);
        _modelNadeltelegraph.AlleZeiger[1].SetPosition(_modelNadeltelegraph.P2R, _modelNadeltelegraph.P2L);
        _modelNadeltelegraph.AlleZeiger[2].SetPosition(_modelNadeltelegraph.P3R, _modelNadeltelegraph.P3L);
        _modelNadeltelegraph.AlleZeiger[3].SetPosition(_modelNadeltelegraph.P4R, _modelNadeltelegraph.P4L);
        _modelNadeltelegraph.AlleZeiger[4].SetPosition(_modelNadeltelegraph.P5R, _modelNadeltelegraph.P5L);
        
        for (var i = 0; i < 5; i++)
        {
            Winkel[(int)WpfObjects.Zeiger1 + i] = _modelNadeltelegraph.AlleZeiger[i].GetWinkel();
        
            SichtbarEin[(int)WpfObjects.LinieLinksOben1 + i] = _modelNadeltelegraph.AlleZeiger[i].GetVisibilityUpLeft();
            SichtbarEin[(int)WpfObjects.LinieRechtsOben1 + i] = _modelNadeltelegraph.AlleZeiger[i].GetVisibilityUpRight();
            SichtbarEin[(int)WpfObjects.LinieLinksUnten1 + i] = _modelNadeltelegraph.AlleZeiger[i].GetVisibilityDownLeft();
            SichtbarEin[(int)WpfObjects.LinieRechtsUnten1 + i] = _modelNadeltelegraph.AlleZeiger[i].GetVisibilityDownRight();
        }
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        if (gedrueckt)
        {
            _modelNadeltelegraph.Zeichen = tasterId switch
            {
                WpfObjects.BuchstabeA => (byte)'A',
                WpfObjects.BuchstabeB => (byte)'B',
                WpfObjects.BuchstabeD => (byte)'D',
                WpfObjects.BuchstabeE => (byte)'E',
                WpfObjects.BuchstabeF => (byte)'F',
                WpfObjects.BuchstabeG => (byte)'G',
                WpfObjects.BuchstabeH => (byte)'H',
                WpfObjects.BuchstabeI => (byte)'I',
                WpfObjects.BuchstabeK => (byte)'K',
                WpfObjects.BuchstabeL => (byte)'L',
                WpfObjects.BuchstabeM => (byte)'M',
                WpfObjects.BuchstabeN => (byte)'N',
                WpfObjects.BuchstabeO => (byte)'O',
                WpfObjects.BuchstabeP => (byte)'P',
                WpfObjects.BuchstabeR => (byte)'R',
                WpfObjects.BuchstabeS => (byte)'S',
                WpfObjects.BuchstabeT => (byte)'T',
                WpfObjects.BuchstabeV => (byte)'V',
                WpfObjects.BuchstabeW => (byte)'W',
                WpfObjects.BuchstabeY => (byte)'Y',
                _ => throw new ArgumentOutOfRangeException(nameof(tasterId))
            };
        }
        else
        {
            _modelNadeltelegraph.Zeichen = 0x20;
        }

    }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}