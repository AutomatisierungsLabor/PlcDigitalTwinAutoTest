using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibGrid
{
    public static void Zeichnen( int anzX, int breiteX, int anzY, int hoeheY, bool gridSichtbar, Grid grid)
    {
        for (var i = 0; i < anzX; i++) grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(breiteX) });
        for (var i = 0; i < anzY; i++) grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(hoeheY) });


        if (!gridSichtbar) return;

        for (var i = 0; i < anzY; i++)
        {
            LibFormen.Linie( 0, i * hoeheY, anzX * breiteX, i * hoeheY, anzX, anzY, 1, Brushes.Crimson,  grid);
            LibTexte.Text(i.ToString(), 0, 1, i, 1,  HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue,   grid);
        }

        for (var i = 0; i < anzX; i++)
        {
            LibFormen.Linie( i * breiteX, 0, i * breiteX, anzY * hoeheY, anzX, anzY, 1, Brushes.BlueViolet,  grid);
            LibTexte.Text(i.ToString(), i, 1, 0, 1,  HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen,   grid);
        }
    }
}