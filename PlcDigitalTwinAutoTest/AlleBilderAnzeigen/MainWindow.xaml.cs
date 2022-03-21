namespace AlleBilderAnzeigen;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        var alleBilder = new Model.AlleBilder();
        alleBilder.BilderEinlesen("BasePlcDtAt/Bilder");
        var viewModel = new ViewModel.ViewModel(Grid);
        viewModel.AlleBilderAnzeigen(alleBilder.GetAlleBilder());
    }
}