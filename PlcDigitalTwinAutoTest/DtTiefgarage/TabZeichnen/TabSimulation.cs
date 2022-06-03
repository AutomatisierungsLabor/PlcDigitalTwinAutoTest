using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtTiefgarage.ViewModel;

namespace DtTiefgarage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmTiefgarage vmTiefgarage, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false, false, true);

        var buttonRand = new Thickness(2, 5, 2, 5);


        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(25, 10, 2, 6, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("Drinnen Parken", 27, 6, 2, 3, 20, 15, Brushes.LawnGreen, buttonRand, vmTiefgarage.ButtonTasterCommand, "DrinnenParken", nameof(vmTiefgarage.ClickModeDrinnenParken));
        libWpf.ButtonBackgroundContentMarginRounded("Draussen Parken", 27, 6, 5, 3, 20, 15, Brushes.DeepPink, buttonRand, vmTiefgarage.ButtonTasterCommand, "DraussenParken", nameof(vmTiefgarage.ClickModeDraussenParken));

        libWpf.RectangleFill(25, 10, 9, 4, Brushes.LightGray);

        libWpf.TextSetContent(26, 10, 9, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmTiefgarage.StringAnzahlAutos));
        libWpf.TextSetContent(26, 10, 11, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmTiefgarage.StringAnzahlPersonen));


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////



        // links
        libWpf.RectangleFillMargin(1, 4, 5, 1, Brushes.Gray, new Thickness(0, 0, 0, 15));
        libWpf.RectangleFillMargin(4, 1, 5, 5, Brushes.Gray, new Thickness(15, 0, 0, 0));
        libWpf.RectangleFillMargin(2, 3, 10, 1, Brushes.Gray, new Thickness(0, 0, 0, 15));
        libWpf.RectangleFillMargin(2, 1, 10, 15, Brushes.Gray, new Thickness(0, 0, 15, 0));

        libWpf.Text("P1", 6, 2, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("P2", 6, 2, 7, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.EllipseFillMarginStroke(5, 1, 5, 1, Brushes.Yellow, new Thickness(2, 2, 2, 2), Brushes.Black, 2);
        libWpf.EllipseFillMarginStroke(5, 1, 7, 1, Brushes.Yellow, new Thickness(2, 2, 2, 2), Brushes.Black, 2);

        // rechts
        libWpf.RectangleFillMargin(15, 4, 5, 1, Brushes.Gray, new Thickness(0, 0, 0, 15));
        libWpf.RectangleFillMargin(15, 1, 5, 5, Brushes.Gray, new Thickness(0, 0, 15, 0));
        libWpf.RectangleFillMargin(15, 3, 10, 1, Brushes.Gray, new Thickness(0, 0, 0, 15));
        libWpf.RectangleFillMargin(18, 1, 10, 15, Brushes.Gray, new Thickness(0, 0, 15, 0));

        libWpf.Text("B1", 13, 2, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("B2", 13, 2, 7, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(14, 1, 5, 1, new Thickness(2, 2, 2, 2), Brushes.Black, 2, nameof(vmTiefgarage.BrushB1));
        libWpf.EllipseMarginStrokeSetFilling(14, 1, 7, 1, new Thickness(2, 2, 2, 2), Brushes.Black, 2, nameof(vmTiefgarage.BrushB2));


        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Pkw1.jpg", vmTiefgarage.ButtonTasterCommand, "Pkw1", nameof(vmTiefgarage.ClickModePkw1), nameof(vmTiefgarage.ThicknessPkw1));
        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Pkw2.jpg", vmTiefgarage.ButtonTasterCommand, "Pkw2", nameof(vmTiefgarage.ClickModePkw2), nameof(vmTiefgarage.ThicknessPkw2));
        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Pkw3.jpg", vmTiefgarage.ButtonTasterCommand, "Pkw3", nameof(vmTiefgarage.ClickModePkw3), nameof(vmTiefgarage.ThicknessPkw3));
        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Pkw4.jpg", vmTiefgarage.ButtonTasterCommand, "Pkw4", nameof(vmTiefgarage.ClickModePkw4), nameof(vmTiefgarage.ThicknessPkw4));

        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Frau1.jpg", vmTiefgarage.ButtonTasterCommand, "Mensch1", nameof(vmTiefgarage.ClickModePkw1), nameof(vmTiefgarage.ThicknessMensch1));
        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Frau2.jpg", vmTiefgarage.ButtonTasterCommand, "Mensch2", nameof(vmTiefgarage.ClickModePkw1), nameof(vmTiefgarage.ThicknessMensch2));
        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Mann1.jpg", vmTiefgarage.ButtonTasterCommand, "Mensch3", nameof(vmTiefgarage.ClickModePkw1), nameof(vmTiefgarage.ThicknessMensch3));
        libWpf.ButtonBildSetMargin(0, 20, 0, 25, "Mann2.jpg", vmTiefgarage.ButtonTasterCommand, "Mensch4", nameof(vmTiefgarage.ClickModePkw1), nameof(vmTiefgarage.ThicknessMensch4));

        libWpf.PlcError();
    }
}