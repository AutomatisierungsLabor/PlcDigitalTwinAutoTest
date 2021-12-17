using System.Windows.Controls;
using System.Windows.Media;
using DtKata.Model;

namespace DtKata;

// ReSharper disable once UnusedMember.Global
public partial class MainWindow
{
    public LibDatenstruktur.Datenstruktur Datenstruktur { get; set; }

    public MainWindow()

    {
        Datenstruktur = new LibDatenstruktur.Datenstruktur();


        InitializeComponent();
        
        var sdfsf = FindName("Grid0");
        var dataGrid = (Grid)FindName("Grid1");
        var viewModel = new ViewModel.ViewModel();
        var kata = new Kata { VersionLokal = "Kata" + " " + "V2.0" };
        
        
        viewModel.SetRefModel(kata);
        viewModel.SetRefDatenstruktur(Datenstruktur);
        viewModel.SetGridSichtbar(true);
        BasePlcDtAt.BaseViewModel.ViewModel.Instance = viewModel;


        kata.SetRefDatenstuktur(Datenstruktur);
        kata.ConfigPlc.SetPath("/ConfigPlc");





        DataContext = viewModel;
    }
}