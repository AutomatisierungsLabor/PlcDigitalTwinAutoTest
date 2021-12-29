using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using LibSilkAutoTester.TestAutomat;

namespace LibSilkAutoTester;

public partial class TestAusgabeFenster
{
    public ObservableCollection<DataGridZeile> AutoTesterDataGrid { get; set; }
    public void UpdateDataGrid(DataGridZeile data) => Dispatcher.Invoke(() => AutoTesterDataGrid.Add(data));
    

    public TestAusgabeFenster()
    {
        AutoTesterDataGrid = new ObservableCollection<DataGridZeile>();

        InitializeComponent();

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
    }
}