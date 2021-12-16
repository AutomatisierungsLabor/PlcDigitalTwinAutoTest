using DtKata.Model;

namespace DtKata;

public partial class MainWindow
{

    public LibDatenstruktur.Datenstruktur Datenstruktur { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        Datenstruktur = new LibDatenstruktur.Datenstruktur();


        var kata = new Kata();
        var viewModel = new ViewModel.ViewModel();


        kata.VersionLokal = "Kata" + " " + "V2.0";
        kata.SetRefDatenstuktur(Datenstruktur);
        kata.ConfigPlc.SetPath("/ConfigPlc");

        viewModel.SetRefModel(kata);
        viewModel.SetRefDatenstruktur(Datenstruktur);


        DataContext = viewModel;
    }

}