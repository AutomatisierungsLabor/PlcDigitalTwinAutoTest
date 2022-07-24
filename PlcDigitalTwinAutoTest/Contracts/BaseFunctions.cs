using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Contracts;


public class BaseFunctions
{
    public const double ThreadZyklusZeit = 0.01;

    public static (Visibility Ein, Visibility Aus) SetVisibility(bool val) => val ? (Visibility.Visible, Visibility.Hidden) : (Visibility.Hidden, Visibility.Visible);
    public static Visibility SetVisibilityEin(bool val) => val ? Visibility.Visible : Visibility.Hidden;
    public static Brush SetBrush(bool val, Brush farbeTrue, Brush farbeFalse) => val ? farbeTrue : farbeFalse;
    public static (bool ergebnis, ClickMode clickModeTaster) ButtonClickMode(ClickMode clickMode) => clickMode == ClickMode.Press ? (true, ClickMode.Release) : (false, ClickMode.Press);
    public static (bool ergebnis, ClickMode clickModeTaster) ButtonClickModeInvertiert(ClickMode clickMode) => clickMode == ClickMode.Press ? (false, ClickMode.Release) : (true, ClickMode.Press);
}