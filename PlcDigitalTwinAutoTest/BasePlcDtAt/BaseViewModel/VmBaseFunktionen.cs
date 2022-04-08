using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    protected (Visibility Ein, Visibility Aus) SetVisibility(bool val) => val ? (Visibility.Visible, Visibility.Hidden) : (Visibility.Hidden, Visibility.Visible);
    protected Brush SetBrush(bool val, Brush farbeTrue, Brush farbeFalse) => val ? farbeTrue : farbeFalse;
    public (bool ergebnis, ClickMode clickModeTaster) ButtonClickMode(ClickMode clickMode) => clickMode == ClickMode.Press ? (true, ClickMode.Release) : (false, ClickMode.Press);
    public (bool ergebnis, ClickMode clickModeTaster) ButtonClickModeInvertiert(ClickMode clickMode) => clickMode == ClickMode.Press ? (false, ClickMode.Release) : (true, ClickMode.Press);
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