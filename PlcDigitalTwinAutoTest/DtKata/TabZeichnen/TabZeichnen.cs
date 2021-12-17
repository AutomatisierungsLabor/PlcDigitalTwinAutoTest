using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibWpf;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{

    private readonly LibWpf.LibGrid _libGrid;

    public TabZeichnen()
    {
        _libGrid = new LibGrid();

    }
}