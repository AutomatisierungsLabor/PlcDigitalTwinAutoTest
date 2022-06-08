using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void GridZeichnen(int anzX, int anzY,  bool columnStern, bool rowStern, bool gridSichtbar)
    {
     const double breiteX = 30;
     const double hoeheY = 30;

        for (var i = 0; i < anzX; i++) Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(breiteX) });

        if (columnStern)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(breiteX, GridUnitType.Star) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(breiteX) });
        }

        for (var i = 0; i < anzY; i++) Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(hoeheY) });
        if (rowStern)
        {
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(hoeheY, GridUnitType.Star) });
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(hoeheY) });
        }

        if (!gridSichtbar) return;

        for (var i = 0; i < anzY; i++)
        {
            Linie(0, anzX, 0, anzY, 0, i * hoeheY, anzX * breiteX, i * hoeheY, 1, Brushes.Crimson);
            Text(i.ToString(), 0, 1, i, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        if (rowStern)
        {
            Linie(0, anzX, 0, anzY, 0, anzY * hoeheY, anzX * breiteX, anzY * hoeheY, 1, Brushes.Crimson);
            Text("[*]", 0, 1, anzY, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);

            Linie(0, anzX, 0, anzY, 0, (anzY + 1) * hoeheY, anzX * breiteX, (anzY + 1) * hoeheY, 1, Brushes.Crimson);
            Text((anzY + 1).ToString(), 0, 1, anzY + 1, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        for (var i = 0; i < anzX; i++)
        {
            Linie(0, anzX, 0, anzY, i * breiteX, 0, i * breiteX, anzY * hoeheY, 1, Brushes.BlueViolet);
            Text(i.ToString(), i, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
        }

        if (!columnStern) return;
        Linie(0, anzX, 0, anzY, anzX * breiteX, 0, anzX * breiteX, anzY * hoeheY, 1, Brushes.BlueViolet);
        Text("(*)", anzX, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);

        Linie(0, anzX, 0, anzY, (anzX + 1) * breiteX, 0, (anzX + 1) * breiteX, anzY * hoeheY, 1, Brushes.BlueViolet);
        Text((anzX + 1).ToString(), anzX + 1, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
    }
    public void SetBackground(SolidColorBrush brush) => Grid.Background = brush;
}