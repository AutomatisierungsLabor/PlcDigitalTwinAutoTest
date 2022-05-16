using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Controls;

namespace LibInfo.VmInfo;

public partial class VmInfo
{
    [ObservableProperty] private ClickMode _clickModeTasterReset;

    [ObservableProperty] private string _stringPlcStatus;
    [ObservableProperty] private string _stringPlcZykluszeitAct;
    [ObservableProperty] private string _stringPlcZykluszeitMin;
    [ObservableProperty] private string _stringPlcZykluszeitMax;

    [ObservableProperty] private string _stringProjektbezeichnungLokal;
    [ObservableProperty] private string _stringProjektbezeichnungPlc;

    [ObservableProperty] private string _stringDa0;
    [ObservableProperty] private string _stringDa1;

    [ObservableProperty] private string _stringDi0;
    [ObservableProperty] private string _stringDi1;

}