
using Contracts;
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
                SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Visible;
                Farbe[(int)WpfBase.ErrorAnzeige] = Brushes.Red;
            }
            else
            {
                SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Hidden;
                SichtbarEin[(int)WpfBase.ErrorMeldung] = Visibility.Hidden;
                SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Hidden;
                SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Hidden;
            }

            if (PlcDaemon.PlcState.PlcError)
            {
                SichtbarEin[(int)WpfBase.ErrorMeldung] = Visibility.Visible;
                Text[(int)WpfBase.ErrorMeldung] = PlcDaemon.PlcState.PlcErrorMessage;
            }

            if (errorVersion)
            {
                SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Visible;
                SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Visible;

                Text[(int)WpfBase.ErrorVersionLokal] = _datenstruktur.VersionsStringLokal;
                Text[(int)WpfBase.ErrorVersionPlc] = _datenstruktur.VersionsStringPlc;
            }

            ViewModelAufrufThread();
            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}