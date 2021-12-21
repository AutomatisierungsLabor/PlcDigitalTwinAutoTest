using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(Grid grid, bool gridSichtbar)
    {
        LibWpf.LibGrid.Zeichnen(50, 20, 30, 20, gridSichtbar, grid);

        LibWpf.LibTexte.Text("Simulation", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black, grid);

        var viewmodel = grid.DataContext as BasePlcDtAt.BaseViewModel.ViewModel ?? throw new ArgumentNullException($"{nameof(ViewModel)}", "Datacontext is not of type viewmodel");
        LibWpf.LibButton.ButtonViz("S1", 3, 1, 4, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S1, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S1}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S2", 3, 1, 6, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S2, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S2}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S3", 3, 1, 8, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S3, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S3}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S4", 3, 1, 10, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S4, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S4}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S5", 3, 1, 12, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S5, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S5}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S6", 3, 1, 14, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S6, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S6}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S7", 3, 1, 16, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S7, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S7}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S8", 3, 1, 18, 2, 10, new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S8, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S8}]", System.Windows.Controls.Primitives.ButtonBase.ClickModeProperty, grid);


        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 4, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S1}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 4, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S1}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 6, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S2}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 6, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S2}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 8, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S3}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 8, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S3}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 10, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S4}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 10, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S4}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 12, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S5}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 12, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S5}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 14, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S6}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 14, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S6}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 16, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S7}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 16, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S7}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 4, 2, 18, 2, new Thickness(0, 5, 5, 5), $"SichtbarEin[{ (int)ViewModel.ViewModel.WpfObjects.S8}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 4, 2, 18, 2, new Thickness(0, 5, 5, 5), $"SichtbarAus[{ (int)ViewModel.ViewModel.WpfObjects.S8}]", UIElement.VisibilityProperty, grid);


        LibWpf.LibFormen.KreisRandViz(10, 2, 4, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P1}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 6, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P2}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 8, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P3}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 10, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P4}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 12, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P5}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 14, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P6}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 16, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P7}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(10, 2, 18, 2, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), $"Farbe[{ (int)ViewModel.ViewModel.WpfObjects.P8}]", System.Windows.Shapes.Shape.FillProperty, grid);


        LibWpf.LibMeldungen.PlcError(grid);
    }
}