using Contracts;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
    
    private readonly CancellationToken _cancellationTokenSource;

    public VmAutoTesterSilk(CancellationToken cancellationTokenSource)
    {
        _cancellationTokenSource = cancellationTokenSource;
        DataGridZeilen = new ObservableCollection<DataGridZeile>();

        AlleDpFuellen();
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