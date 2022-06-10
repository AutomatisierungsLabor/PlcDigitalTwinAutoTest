using System.Windows;
using System.Windows.Controls;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public partial class LibWpf
{
    public Grid Grid;

    public LibWpf() { }
    public LibWpf(Grid grid) => Grid = grid;
    public LibWpf(ContentControl tabItem)
    {
        Grid = new Grid();
        tabItem.Content = Grid;
    }
    public static void AddToGrid(int xPos, int xSpan, int yPos, int ySpan, Grid grid, UIElement label)
    {
        SetColumn(label, xPos);
        SetColumnSpan(label, xSpan);
        SetRow(label, yPos);
        SetRowSpan(label, ySpan);
        grid.Children.Add(label);
    }
    public void Clear()
    {
        Grid.Children.Clear();
        Grid.RowDefinitions.Clear();
        Grid.ColumnDefinitions.Clear();
    }
}