using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibInfo.VmInfo;

public partial class VmInfo
{
    [ObservableProperty] private ClickMode _clickModeTasterReset;

    [ObservableProperty] private string _stringKommunikationPlcMin;
    [ObservableProperty] private string _stringKommunikationPlcMax;
    [ObservableProperty] private string _stringKommunikationPlcAvg;
}