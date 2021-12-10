

using DtKata.Model;

namespace DtKata;

public partial  class MainWindow
{

    private readonly Model.Kata _kata;
    private  readonly ViewModel.ViewModel _viewModel;

    public MainWindow()
    {

        InitializeComponent();


        _kata = new Kata();
        _viewModel = new ViewModel.ViewModel();

        DataContext = _viewModel;

    }
}