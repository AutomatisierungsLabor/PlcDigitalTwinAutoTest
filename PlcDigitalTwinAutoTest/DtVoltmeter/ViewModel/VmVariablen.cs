using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtVoltmeter.ViewModel;

public partial class VmVoltmeter
{
    [ObservableProperty] private Brush _brushHintergrundFarbe;

    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;
    [ObservableProperty] private ClickMode _clickModeS5;

    [ObservableProperty] private double _doubleAnalogsignal;

    [ObservableProperty] private short _shortEinerStelle;
    [ObservableProperty] private short _shortZehnerStelle;
    [ObservableProperty] private short _shortHunderterStelle;
    [ObservableProperty] private short _shortTausenderStelle;

    [ObservableProperty] private string _stringAnalogsignal;
    [ObservableProperty] private string _stringAnalogInVolt;
}