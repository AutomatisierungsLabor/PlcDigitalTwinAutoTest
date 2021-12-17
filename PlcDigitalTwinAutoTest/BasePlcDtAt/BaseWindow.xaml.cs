using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt.BaseViewModel;

namespace BasePlcDtAt
{
    public partial class BaseWindow : Window
    {
        private  ViewModel _viewModel;
        public BaseWindow(BaseViewModel.ViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext= _viewModel;
        }

        private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
        {
  //
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
