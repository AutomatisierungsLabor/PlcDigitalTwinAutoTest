using Contracts;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    private readonly CancellationTokenSource _cancellationTokenSource;
    public enum WpfIndex
    {
        Di01 = 0,
        Di17 = 15,
        Da01 = 16,
        Da17 = 31,
        SoureCode = 32
    }
    public VmAutoTesterSilk( CancellationTokenSource cancellationTokenSource)
    {
        _cancellationTokenSource=cancellationTokenSource;
        DataGridZeilen = new ObservableCollection<DataGridZeile>();

        for (var i = 0; i < 100; i++)
        {
            SichtbarEin.Add(Visibility.Hidden);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }
    }
    public void UpdateDataGrid(DataGridZeile zeile)
    {
        if (_cancellationTokenSource.IsCancellationRequested) return;

        Application.Current.Dispatcher.Invoke(() =>
        {
            var zeilenNr = zeile.ZeilenNr;
            
            if (DataGridZeilen.Count <= zeilenNr) DataGridZeilen.Add(zeile);
            else DataGridZeilen[zeilenNr] = zeile;
        });
    }
}