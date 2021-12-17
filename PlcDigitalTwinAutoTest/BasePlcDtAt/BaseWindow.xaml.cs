using System.Windows;
using System.Windows.Controls;

namespace BasePlcDtAt;

public partial class BaseUserControl
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    public BaseModel.Model Model { get; set; }
    public BaseViewModel.ViewModel ViewModel { get; set; }

    public BaseUserControl()
    {
        InitializeComponent();
        
       ViewModel = BasePlcDtAt.BaseViewModel.ViewModel.Instance;
        /*
        ViewModel.SetGridBeschreibung(Grid0);
        ViewModel.SetGridLaborPlatte(Grid1);
        ViewModel.SetGridSimulation(Grid2);
        ViewModel.SetGridAutoTest(Grid3);
        */
        Log.Debug("BaseUserControl startet");
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
