using Microsoft.Toolkit.Mvvm.Input;

namespace LibInfo.VmInfo;

public partial class VmInfo
{
    [ICommand]
    private void ButtonTaster(string cmd) => DisplayInfo.CbResetPlcInfo();
}
