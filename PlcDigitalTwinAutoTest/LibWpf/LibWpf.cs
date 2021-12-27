using System.Windows;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public partial class LibWpf
{
    public System.Windows.Controls.Grid Grid;

    public LibWpf(System.Windows.Controls.Grid grid) => Grid = grid;

    public void AddToGrid(int xPos, int xSpan, int yPos, int ySpan, System.Windows.Controls.Grid grid, UIElement label)
    {
        SetColumn(label, xPos);
        SetColumnSpan(label, xSpan);
        SetRow(label, yPos);
        SetRowSpan(label, ySpan);
        grid.Children.Add(label);
    }
}