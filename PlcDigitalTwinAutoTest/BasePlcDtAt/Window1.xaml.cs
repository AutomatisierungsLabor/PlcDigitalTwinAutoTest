using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BasePlcDtAt
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not TabControl tc) return;
            var index = tc.SelectedIndex;
            BaseModel.Model.BetriebsartUmschalten(index);

            var grid = FindName("Grid0");



        }

        private void PlcButtonClick(object sender, RoutedEventArgs e)
        {
            //
        }

        private void PlotterButtonClick(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
