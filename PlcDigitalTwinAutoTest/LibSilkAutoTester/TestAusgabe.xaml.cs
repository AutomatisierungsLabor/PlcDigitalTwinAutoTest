using LibConfigPlc;
using LibSilkAutoTester.Model;
using LibSilkAutoTester.ViewModel;

namespace LibSilkAutoTester;

public partial class TestAusgabeFenster
{
   
   // public void UpdateDataGrid(DataGridZeile data) => Dispatcher.Invoke(() => AutoTesterDataGrid.Add(data));
    public Model.ModelSilkAutoTester ModelSilkAutoTester { get; set; }
    public ViewModel.VmSilkAutoTester VmSilkAutoTester { get; set; }
    private readonly DiDaBeschriften _diDaBeschriften;
    public TestAusgabeFenster(ConfigPlc configPlc)
    {
        ModelSilkAutoTester = new ModelSilkAutoTester(this, configPlc);
        VmSilkAutoTester = new VmSilkAutoTester(ModelSilkAutoTester);
       // AutoTesterDataGrid = new ObservableCollection<DataGridZeile>();


        InitializeComponent();
        DataContext = VmSilkAutoTester;

        _diDaBeschriften = new DiDaBeschriften(GridTest);

        /*
        DataGrid.ItemsSource = AutoTesterDataGrid;
        DataGrid.ItemContainerGenerator.StatusChanged += (_, _) =>
        {
            if (DataGrid.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated) return;
            var reihe = AutoTesterDataGrid.Count;
            if (reihe < 1) return;
            var row = (DataGridRow)DataGrid.ItemContainerGenerator.ContainerFromIndex(reihe - 1);

            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (AutoTesterDataGrid[reihe - 1].Ergebnis)
            {
                case TestErgebnis.Init: row.Background = Brushes.Aquamarine; break;
                case TestErgebnis.Erfolgreich: row.Background = Brushes.LawnGreen; break;
                case TestErgebnis.Timeout: row.Background = Brushes.Orange; break;
                case TestErgebnis.Fehler: row.Background = Brushes.Red; break;
                case TestErgebnis.Default: row.Background = Brushes.White; break;
                default: throw new ArgumentOutOfRangeException();
            }
        };
        */

        Closing += (_, e) =>
        {
            e.Cancel = true;
            Hide();
        };
    }


}