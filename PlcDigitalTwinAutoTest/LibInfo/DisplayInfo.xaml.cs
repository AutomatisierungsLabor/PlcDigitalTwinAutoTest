using System;
using System.Windows.Controls;

namespace LibInfo;

public partial class DisplayInfo
{
    public VmInfo.VmInfo VmInfo { get; set; }
    public bool FensterAktiv { get; set; }
    public Action CbResetPlcInfo;

    public DisplayInfo()
    {
        var grid = new Grid();
        Content = grid;

        VmInfo = new VmInfo.VmInfo(this);
        DataContext = VmInfo;

        _ = new InfoZeichnen(grid, VmInfo);
    }
    public void FensterAusblenden()
    {
        FensterAktiv = false;
        Hide();
    }
    public void FensterAnzeigen()
    {
        FensterAktiv = true;
        Show();
    }
    public void SetKommunikationPlcValues(LibPlcKommunikation.PlcDaemon.PlcDaemonStatus status, long kommunikationPlcAct, long kommunikationPlcMin, long kommunikationPlcMax)
    {
        VmInfo.StringPlcStatus = status.ToString();
        VmInfo.StringPlcZykluszeitAct = $"{kommunikationPlcAct}ms";
        VmInfo.StringPlcZykluszeitMin = $"{kommunikationPlcMin}ms";
        VmInfo.StringPlcZykluszeitMax = $"{kommunikationPlcMax}ms";
    }
    public void SetResetInfoCallback(Action resetPlcInfo) => CbResetPlcInfo = resetPlcInfo;
}