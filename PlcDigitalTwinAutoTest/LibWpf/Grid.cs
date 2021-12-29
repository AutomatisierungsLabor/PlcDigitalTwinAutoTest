using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void GridZeichnen(int anzX, int breiteX, int anzY, int hoeheY, bool gridSichtbar)
    {
        for (var i = 0; i < anzX; i++) Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(breiteX) });
        for (var i = 0; i < anzY; i++) Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(hoeheY) });

        if (!gridSichtbar) return;

        for (var i = 0; i < anzY; i++)
        {
            Linie(0, i * hoeheY, anzX * breiteX, i * hoeheY, anzX, anzY, 1, Brushes.Crimson, Grid);
            Text(i.ToString(), 0, 1, i, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        for (var i = 0; i < anzX; i++)
        {
            Linie(i * breiteX, 0, i * breiteX, anzY * hoeheY, anzX, anzY, 1, Brushes.BlueViolet, Grid);
            Text(i.ToString(), i, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
        }
    }

    public void SetBackground(SolidColorBrush brush) => Grid.Background=brush;
}