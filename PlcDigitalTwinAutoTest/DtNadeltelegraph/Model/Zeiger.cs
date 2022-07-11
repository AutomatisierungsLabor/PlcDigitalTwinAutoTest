using System.Windows;

namespace DtNadeltelegraph.Model;

public class Zeiger
{
    private int _winkel;

    private Visibility _visibilityUpLeft;
    private Visibility _visibilityUpRight;
    private Visibility _visibilityDownLeft;
    private Visibility _visibilityDownRight;

    private const int WinkelNadel = 40;

    public Zeiger()
    {
        _winkel = 0;

        _visibilityUpLeft = Visibility.Hidden;
        _visibilityUpRight = Visibility.Hidden;
        _visibilityDownLeft = Visibility.Hidden;
        _visibilityDownRight = Visibility.Hidden;
    }

    internal void SetPosition(bool rechts, bool links)
    {
        _winkel = 0;

        _visibilityUpLeft = Visibility.Hidden;
        _visibilityUpRight = Visibility.Hidden;
        _visibilityDownLeft = Visibility.Hidden;
        _visibilityDownRight = Visibility.Hidden;

        if (rechts)
        {
            _winkel = WinkelNadel;

            _visibilityUpRight = Visibility.Visible;
            _visibilityDownLeft = Visibility.Visible;
        }

        if (!links) return;

        _winkel = -WinkelNadel;

        _visibilityUpLeft = Visibility.Visible;
        _visibilityDownRight = Visibility.Visible;
    }

    internal int GetWinkel() => _winkel;
    internal Visibility GetVisibilityUpLeft(bool b) => b ? _visibilityUpLeft : Visibility.Hidden;
    internal Visibility GetVisibilityUpRight(bool b) => b ? _visibilityUpRight : Visibility.Hidden;
    internal Visibility GetVisibilityDownLeft(bool b) => b ? _visibilityDownLeft : Visibility.Hidden;
    internal Visibility GetVisibilityDownRight(bool b) => b ? _visibilityDownRight : Visibility.Hidden;
}