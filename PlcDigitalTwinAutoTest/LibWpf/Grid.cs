using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    private const double RasterX = 30;
    private const double RasterY = 30;

    public void GridZeichnen(int anzX, int anzY, bool columnStern, bool rowStern, bool gridSichtbar)
    {


        for (var i = 0; i < anzX; i++) Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(RasterX) });

        if (columnStern)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(RasterX, GridUnitType.Star) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(RasterX) });
        }

        for (var i = 0; i < anzY; i++) Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RasterY) });
        if (rowStern)
        {
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RasterY, GridUnitType.Star) });
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(RasterY) });
        }

        if (!gridSichtbar) return;

        for (var i = 0; i < anzY; i++)
        {
            Linie(0, anzX, 0, anzY, 0, i * RasterY, anzX * RasterX, i * RasterY, 1, Brushes.Crimson);
            Text(i.ToString(), 0, 1, i, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        if (rowStern)
        {
            Linie(0, anzX, 0, anzY, 0, anzY * RasterY, anzX * RasterX, anzY * RasterY, 1, Brushes.Crimson);
            Text("[*]", 0, 1, anzY, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);

            Linie(0, anzX, 0, anzY, 0, (anzY + 1) * RasterY, anzX * RasterX, (anzY + 1) * RasterY, 1, Brushes.Crimson);
            Text((anzY + 1).ToString(), 0, 1, anzY + 1, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        for (var i = 0; i < anzX; i++)
        {
            Linie(0, anzX, 0, anzY, i * RasterX, 0, i * RasterX, anzY * RasterY, 1, Brushes.BlueViolet);
            Text(i.ToString(), i, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
        }

        if (!columnStern) return;
        Linie(0, anzX, 0, anzY, anzX * RasterX, 0, anzX * RasterX, anzY * RasterY, 1, Brushes.BlueViolet);
        Text("(*)", anzX, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);

        Linie(0, anzX, 0, anzY, (anzX + 1) * RasterX, 0, (anzX + 1) * RasterX, anzY * RasterY, 1, Brushes.BlueViolet);
        Text((anzX + 1).ToString(), anzX + 1, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
    }
    public void SetBackground(SolidColorBrush brush) => Grid.Background = brush;
}