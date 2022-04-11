namespace AlleBilderAnzeigen;
// ReSharper disable once UnusedMember.Global
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        
        var alleBilder = new Model.AlleBilder();
        alleBilder.BilderEinlesen("Bilder");
        var viewModel = new ViewModel.ViewModel(Grid);
        viewModel.AlleBilderAnzeigen(alleBilder.GetAlleBilder());
    }
}