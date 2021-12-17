using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static BasePlcDtAt.BaseViewModel.ViewModel;

namespace LibWpf
{
    public  class LibMeldungen
    {

        public static void PlcError(Grid grid)
        {
            LibFormen.RechteckViz(2, 20, 2, 10, Brushes.LightSalmon,  (int)WpfObjects.ErrorAnzeige,  grid);
            LibTexte.TextViz("-",5,10,5,10,HorizontalAlignment.Left,VerticalAlignment.Center,10,Brushes.Black, (int)WpfObjects.ErrorVersionLokal,  grid);
            LibTexte.TextViz("-",5,10,5,10,HorizontalAlignment.Left,VerticalAlignment.Center,10,Brushes.Black, (int)WpfObjects.ErrorVersionPlc,  grid);
        }
    }
}
