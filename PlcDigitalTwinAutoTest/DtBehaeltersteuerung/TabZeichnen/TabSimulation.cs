using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBehaeltersteuerung.ViewModel;

namespace DtBehaeltersteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmBehaeltersteuerung vmBehaeltersteuerung, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, true);

        var buttonRand = new Thickness(2, 5, 2, 5);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(27, 8, 2, 23, Brushes.LightGray);

        libWpf.ButtonBackgroundMarginRoundedSetEnableSetContend(28, 6, 4, 2, 20, 15, Brushes.Violet, buttonRand, vmBehaeltersteuerung.ButtonTasterCommand, "AutomatikStarten", nameof(vmBehaeltersteuerung.ClickModeAutomatikStarten), nameof(vmBehaeltersteuerung.BoolAutomatikStarten), nameof(vmBehaeltersteuerung.StringAutomatikStarten));
        
        libWpf.Text("Entleerreihenfolge", 28, 7, 6, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        vmBehaeltersteuerung.VmComboBox = libWpf.ComboBox(28, 6, 8, 2, 20, new Thickness(0,10,0,10));



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFillMargin(1, 21, 2, 1, Brushes.Blue, new Thickness(0, 0, 0, 10));

        libWpf.RectangleFillMargin(3, 2, 2, 2, Brushes.Blue, new Thickness(20, 0, 20, 0));
        libWpf.RectangleFillMargin(9, 2, 2, 2, Brushes.Blue, new Thickness(20, 0, 20, 0));
        libWpf.RectangleFillMargin(15, 2, 2, 2, Brushes.Blue, new Thickness(20, 0, 20, 0));
        libWpf.RectangleFillMargin(21, 2, 2, 2, Brushes.Blue, new Thickness(20, 0, 20, 0));

        var randBeschriftung = new Thickness(10, 0, 0, 0);
        libWpf.TextMargin("-Q1", 0, 2, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);
        libWpf.TextMargin("-Q3", 6, 2, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);
        libWpf.TextMargin("-Q5", 12, 2, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);
        libWpf.TextMargin("-Q7", 18, 2, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);

        var randVentilOben = new Thickness(0, 0, 5, 0);
        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 2, 3, 4, 2, randVentilOben, nameof(vmBehaeltersteuerung.VisibilityEinQ1), nameof(vmBehaeltersteuerung.VisibilityAusQ1));
        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 8, 3, 4, 2, randVentilOben, nameof(vmBehaeltersteuerung.VisibilityEinQ3), nameof(vmBehaeltersteuerung.VisibilityAusQ3));
        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 14, 3, 4, 2, randVentilOben, nameof(vmBehaeltersteuerung.VisibilityEinQ5), nameof(vmBehaeltersteuerung.VisibilityAusQ5));
        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 20, 3, 4, 2, randVentilOben, nameof(vmBehaeltersteuerung.VisibilityEinQ7), nameof(vmBehaeltersteuerung.VisibilityAusQ7));

        var randSenkrechteLeitungen = new Thickness(20, 0, 20, 0);

        libWpf.RectangleMarginSetFill(3, 2, 6, 12, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesZuleitung1));
        libWpf.RectangleMarginSetFill(9, 2, 6, 12, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesZuleitung2));
        libWpf.RectangleMarginSetFill(15, 2, 6, 12, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesZuleitung3));
        libWpf.RectangleMarginSetFill(21, 2, 6, 12, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesZuleitung4));


        libWpf.RectangleFill(2, 4, 8, 10, Brushes.LightBlue);
        libWpf.RectangleFill(8, 4, 8, 10, Brushes.LightBlue);
        libWpf.RectangleFill(14, 4, 8, 10, Brushes.LightBlue);
        libWpf.RectangleFill(20, 4, 8, 10, Brushes.LightBlue);

        libWpf.RectangleFillSetMargin(2, 4, 8, 10, Brushes.Blue, nameof(vmBehaeltersteuerung.ThicknessFuellstand1));
        libWpf.RectangleFillSetMargin(8, 4, 8, 10, Brushes.Blue, nameof(vmBehaeltersteuerung.ThicknessFuellstand2));
        libWpf.RectangleFillSetMargin(14, 4, 8, 10, Brushes.Blue, nameof(vmBehaeltersteuerung.ThicknessFuellstand3));
        libWpf.RectangleFillSetMargin(20, 4, 8, 10, Brushes.Blue, nameof(vmBehaeltersteuerung.ThicknessFuellstand4));

        var randSchwimmerschalter = new Thickness(2, 15, 10, 15);

        libWpf.RectangleMarginSetFill(6, 2, 8, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB1));
        libWpf.RectangleMarginSetFill(6, 2, 16, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB2));
        libWpf.RectangleMarginSetFill(12, 2, 8, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB3));
        libWpf.RectangleMarginSetFill(12, 2, 16, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB4));
        libWpf.RectangleMarginSetFill(18, 2, 8, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB5));
        libWpf.RectangleMarginSetFill(18, 2, 16, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB6));
        libWpf.RectangleMarginSetFill(24, 2, 8, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB7));
        libWpf.RectangleMarginSetFill(24, 2, 16, 2, randSchwimmerschalter, nameof(vmBehaeltersteuerung.BrushesB8));
        
        libWpf.Text("B1", 6, 2, 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B2", 6, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B3", 12, 2, 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B4", 12, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B5", 18, 2, 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B6", 18, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B7", 24, 2, 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("B8", 24, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleMarginSetFill(3, 2, 18, 2, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungOben1));
        libWpf.RectangleMarginSetFill(9, 2, 18, 2, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungOben2));
        libWpf.RectangleMarginSetFill(15, 2, 18, 2, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungOben3));
        libWpf.RectangleMarginSetFill(21, 2, 18, 2, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungOben4));

        libWpf.TextMargin("-Q2", 0, 2, 20, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);
        libWpf.TextMargin("-Q4", 6, 2, 20, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);
        libWpf.TextMargin("-Q6", 12, 2, 20, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);
        libWpf.TextMargin("-Q8", 18, 2, 20, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung);

        libWpf.ButtonMarginSetVisibilityZweiBilder(2, 3, 20, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", randVentilOben, vmBehaeltersteuerung.ButtonSchalterCommand, "Q2", nameof(vmBehaeltersteuerung.ClickModeQ2), nameof(vmBehaeltersteuerung.VisibilityEinQ2), nameof(vmBehaeltersteuerung.VisibilityAusQ2));
        libWpf.ButtonMarginSetVisibilityZweiBilder(8, 3, 20, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", randVentilOben, vmBehaeltersteuerung.ButtonSchalterCommand, "Q4", nameof(vmBehaeltersteuerung.ClickModeQ4), nameof(vmBehaeltersteuerung.VisibilityEinQ4), nameof(vmBehaeltersteuerung.VisibilityAusQ4));
        libWpf.ButtonMarginSetVisibilityZweiBilder(14, 3, 20, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", randVentilOben, vmBehaeltersteuerung.ButtonSchalterCommand, "Q6", nameof(vmBehaeltersteuerung.ClickModeQ6), nameof(vmBehaeltersteuerung.VisibilityEinQ6), nameof(vmBehaeltersteuerung.VisibilityAusQ6));
        libWpf.ButtonMarginSetVisibilityZweiBilder(20, 3, 20, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", randVentilOben, vmBehaeltersteuerung.ButtonSchalterCommand, "Q8", nameof(vmBehaeltersteuerung.ClickModeQ8), nameof(vmBehaeltersteuerung.VisibilityEinQ8), nameof(vmBehaeltersteuerung.VisibilityAusQ8));

        libWpf.RectangleMarginSetFill(3, 2, 22, 3, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungUnten));
        libWpf.RectangleMarginSetFill(9, 2, 22, 3, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungUnten));
        libWpf.RectangleMarginSetFill(15, 2, 22, 3, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungUnten));
        libWpf.RectangleMarginSetFill(21, 2, 22, 3, randSenkrechteLeitungen, nameof(vmBehaeltersteuerung.BrushesAbleitungUnten));

        libWpf.RectangleMarginSetFill(3, 21, 24, 1, new Thickness(20, 10, 0, 0), nameof(vmBehaeltersteuerung.BrushesAbleitungUnten));

        libWpf.PlcError();
    }
}