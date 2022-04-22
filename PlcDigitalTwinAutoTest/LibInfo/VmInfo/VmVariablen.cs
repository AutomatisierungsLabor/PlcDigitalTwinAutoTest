using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibInfo.VmInfo;

public partial class VmInfo
{
    [ObservableProperty] private ClickMode _clickModeTasterReset;

    [ObservableProperty] private string _stringPlcStatus;
    [ObservableProperty] private string _stringPlcZykluszeitAct;
    [ObservableProperty] private string _stringPlcZykluszeitMin;
    [ObservableProperty] private string _stringPlcZykluszeitMax;


}