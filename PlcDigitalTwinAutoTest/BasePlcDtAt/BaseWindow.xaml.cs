using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt.BaseViewModel;

namespace BasePlcDtAt;

public partial class BaseWindow
{
    private readonly ViewModel _viewModel;
    public BaseWindow(ViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        DataContext= _viewModel;
    }

    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e) => _viewModel.BetriebsartProjektChanged( sender,e);
    private void PlcButtonClick(object sender, RoutedEventArgs e) => _viewModel.PlcButtonClick(sender,e);
    private void PlotterButtonClick(object sender, RoutedEventArgs e) => _viewModel.PlotterButtonClick(sender, e);
}