using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;

namespace LibWpf;

public partial class LibWpf
{
    public void GridZeichnen(int anzX, int anzY, bool columnStern, bool rowStern, bool gridSichtbar)
    {
        for (var i = 0; i < anzX; i++) Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(WpfData.RasterX) });

        if (columnStern)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(WpfData.RasterX, GridUnitType.Star) });
            Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(WpfData.RasterX) });
        }

        for (var i = 0; i < anzY; i++) Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(WpfData.RasterY) });
        if (rowStern)
        {
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(WpfData.RasterY, GridUnitType.Star) });
            Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(WpfData.RasterY) });
        }

        if (!gridSichtbar) return;

        for (var i = 0; i < anzY; i++)
        {
            Linie(0, anzX, 0, anzY, 0, i * WpfData.RasterY, anzX * WpfData.RasterX, i * WpfData.RasterY, 1, Brushes.Crimson);
            Text(i.ToString(), 0, 1, i, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        if (rowStern)
        {
            Linie(0, anzX, 0, anzY, 0, anzY * WpfData.RasterY, anzX * WpfData.RasterX, anzY * WpfData.RasterY, 1, Brushes.Crimson);
            Text("[*]", 0, 1, anzY, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);

            Linie(0, anzX, 0, anzY, 0, (anzY + 1) * WpfData.RasterY, anzX * WpfData.RasterX, (anzY + 1) * WpfData.RasterY, 1, Brushes.Crimson);
            Text((anzY + 1).ToString(), 0, 1, anzY + 1, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.Blue);
        }

        for (var i = 0; i < anzX; i++)
        {
            Linie(0, anzX, 0, anzY, i * WpfData.RasterX, 0, i * WpfData.RasterX, anzY * WpfData.RasterY, 1, Brushes.BlueViolet);
            Text(i.ToString(), i, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
        }

        if (!columnStern) return;
        Linie(0, anzX, 0, anzY, anzX * WpfData.RasterX, 0, anzX * WpfData.RasterX, anzY * WpfData.RasterY, 1, Brushes.BlueViolet);
        Text("(*)", anzX, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);

        Linie(0, anzX, 0, anzY, (anzX + 1) * WpfData.RasterX, 0, (anzX + 1) * WpfData.RasterX, anzY * WpfData.RasterY, 1, Brushes.BlueViolet);
        Text((anzX + 1).ToString(), anzX + 1, 1, 0, 1, HorizontalAlignment.Left, VerticalAlignment.Top, 7, Brushes.DarkGreen);
    }
    public void SetBackground(SolidColorBrush brush) => Grid.Background = brush;
}