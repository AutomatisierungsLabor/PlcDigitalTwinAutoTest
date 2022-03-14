using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtNadeltelegraph.ViewModel;

namespace DtNadeltelegraph.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmNadeltelegraph vmNadeltelegraph, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        libWpf.Polygon(0, 40, 0, 40, Brushes.Gray, Brushes.Black, 5, new[] { new double[] { 30,500}, new double[] { 385,40}, new double[] { 730,500}, new double[] { 385,960} });
        
        // Zeiger
        libWpf.PolygonSetWinkel(2, 10, 12, 10, Brushes.Yellow, Brushes.Black, 2, new[] { new double[] { 0, 50 }, new double[] { 10, 100 }, new double[] { 20, 50 }, new double[] { 10, 0 } }, WpfObjects.Zeiger1);
        libWpf.PolygonSetWinkel(4, 10, 12, 10, Brushes.Yellow, Brushes.Black, 2, new[] { new double[] { 0, 50 }, new double[] { 10, 100 }, new double[] { 20, 50 }, new double[] { 10, 0 } }, WpfObjects.Zeiger2);
        libWpf.PolygonSetWinkel(6, 10, 12, 10, Brushes.Yellow, Brushes.Black, 2, new[] { new double[] { 0, 50 }, new double[] { 10, 100 }, new double[] { 20, 50 }, new double[] { 10, 0 } }, WpfObjects.Zeiger3);
        libWpf.PolygonSetWinkel(8, 10, 12, 10, Brushes.Yellow, Brushes.Black, 2, new[] { new double[] { 0, 50 }, new double[] { 10, 100 }, new double[] { 20, 50 }, new double[] { 10, 0 } }, WpfObjects.Zeiger4);
        libWpf.PolygonSetWinkel(10, 10, 12, 10, Brushes.Yellow, Brushes.Black, 2, new[] { new double[] { 0, 50 }, new double[] { 10, 100 }, new double[] { 20, 50 }, new double[] { 10, 0 } }, WpfObjects.Zeiger5);
        
        // Linien nach rechts oben
        libWpf.LinieSetVisibility(1, 13, 12, 10, 105, 0, 385, -350, 5, Brushes.Orange, WpfObjects.LinieRechtsOben1);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 245, 0, 455, -250, 5, Brushes.OrangeRed, WpfObjects.LinieRechtsOben2);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 385, 0, 525, -175, 5, Brushes.Red, WpfObjects.LinieRechtsOben3);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 525, 0, 595, -100, 5, Brushes.OrangeRed, WpfObjects.LinieRechtsOben4);

        // Linien nach rechts unten
        libWpf.LinieSetVisibility(1, 13, 12, 10, 105, 0, 385, 350, 5, Brushes.Orange, WpfObjects.LinieRechtsUnten1);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 245, 0, 455, 250, 5, Brushes.OrangeRed, WpfObjects.LinieRechtsUnten2);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 385, 0, 525, 175, 5, Brushes.Red, WpfObjects.LinieRechtsUnten3);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 525, 0, 595, 100, 5, Brushes.OrangeRed, WpfObjects.LinieRechtsUnten4);

        // Linien nach links oben
        libWpf.LinieSetVisibility(1, 13, 12, 10, 245, 0, 175, -100, 5, Brushes.OrangeRed, WpfObjects.LinieLinksOben1);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 385, 0, 245, -175, 5, Brushes.Red, WpfObjects.LinieLinksOben2);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 525, 0, 315, -250, 5, Brushes.OrangeRed, WpfObjects.LinieLinksOben3);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 665, 0, 385, -350, 5, Brushes.Orange, WpfObjects.LinieLinksOben4);

        // Linien nach links unten 
        libWpf.LinieSetVisibility(1, 13, 12, 10, 245, 0, 175, 100, 5, Brushes.OrangeRed, WpfObjects.LinieLinksUnten1);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 385, 0, 245, 175, 5, Brushes.Red, WpfObjects.LinieLinksUnten2);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 525, 0, 315, 250, 5, Brushes.OrangeRed, WpfObjects.LinieLinksUnten3);
        libWpf.LinieSetVisibility(1, 13, 12, 10, 665, 0, 385, 350, 5, Brushes.Orange, WpfObjects.LinieLinksUnten4);

        // Taster für die Buchstaben
        libWpf.ButtonRounded(2, 2, 2, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeA);
        libWpf.ButtonRounded(2, 2, 4, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeB);
        libWpf.ButtonRounded(4, 2, 4, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeD);
        libWpf.ButtonRounded(2, 2, 6, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeE);
        libWpf.ButtonRounded(5, 2, 6, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeF);
        libWpf.ButtonRounded(6, 2, 6, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeG);
        libWpf.ButtonRounded(2, 2, 8, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeH);
        libWpf.ButtonRounded(4, 2, 8, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeI);
        libWpf.ButtonRounded(6, 2, 8, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeK);
        libWpf.ButtonRounded(8, 2, 8, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeL);
        libWpf.ButtonRounded(2, 2, 12, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeM);
        libWpf.ButtonRounded(4, 2, 14, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeN);
        libWpf.ButtonRounded(6, 2, 14, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeO);
        libWpf.ButtonRounded(8, 2, 14, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeP);
        libWpf.ButtonRounded(2, 2, 16, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeR);
        libWpf.ButtonRounded(4, 2, 16, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeS);
        libWpf.ButtonRounded(6, 2, 16, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeT);
        libWpf.ButtonRounded(2, 2, 18, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeV);
        libWpf.ButtonRounded(4, 2, 18, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeW);
        libWpf.ButtonRounded(2, 2, 20, 2, 20, 10, new Thickness(0, 0, 0, 0), Brushes.LightGray, vmNadeltelegraph.BtnTaster, WpfObjects.BuchstabeY);

        libWpf.TextSetContendSetVisibility(20,15,2,2,HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.BlueViolet, WpfObjects.AsciiCode);

        //  libWpf.PlcError();
    }
}