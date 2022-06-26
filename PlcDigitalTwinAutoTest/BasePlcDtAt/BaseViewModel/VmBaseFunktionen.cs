using System.Threading;
using System.Windows;
using System.Windows.Media;


namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    private void ViewModelTask(CancellationTokenSource cancellationTokenSource)
    {
        while (!cancellationTokenSource.IsCancellationRequested)
        {
            var errorVersion = !string.Equals(_datenstruktur.VersionsStringLokal, _datenstruktur.VersionsStringPlc);

            if (errorVersion || PlcDaemon.PlcState.PlcError)
            {
                VisibilityErrorAnzeige = Visibility.Visible;
                BrushErrorAnzeige = Brushes.Red;
            }
            else
            {
                VisibilityErrorAnzeige = Visibility.Hidden;
                VisibilityErrorMeldung = Visibility.Hidden;
                VisibilityErrorVersionLokal = Visibility.Hidden;
                VisibilityErrorVersionPlc = Visibility.Hidden;
            }

            if (PlcDaemon.PlcState.PlcError)
            {
                VisibilityErrorMeldung = Visibility.Visible;
                StringErrorMeldung = PlcDaemon.PlcState.PlcErrorMessage;
            }

            if (errorVersion)
            {
                VisibilityErrorVersionLokal = Visibility.Visible;
                VisibilityErrorVersionPlc = Visibility.Visible;

                StringErrorVersionLokal = _datenstruktur.VersionsStringLokal;
                StringErrorVersionPlc = _datenstruktur.VersionsStringPlc;
            }

            ViewModelAufrufThread();

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}