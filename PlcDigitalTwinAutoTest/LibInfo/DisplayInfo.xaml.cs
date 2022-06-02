using System;
using System.Windows.Controls;
using LibDatenstruktur;

namespace LibInfo;

public partial class DisplayInfo
{
    public VmInfo.VmInfo VmInfo { get; set; }
    public bool FensterAktiv { get; set; }
    public Action CbResetPlcInfo;
    private readonly Datenstruktur _datenstruktur;
    public DisplayInfo(Datenstruktur datenstruktur)
    {
        _datenstruktur = datenstruktur;

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
        VmInfo.StringProjektbezeichnungLokal = _datenstruktur.VersionsStringLokal;
        VmInfo.StringProjektbezeichnungPlc = _datenstruktur.VersionsStringPlc;

        VmInfo.StringPlcStatus = status.ToString();
        VmInfo.StringPlcZykluszeitAct = $"{kommunikationPlcAct}ms";
        VmInfo.StringPlcZykluszeitMin = $"{kommunikationPlcMin}ms";
        VmInfo.StringPlcZykluszeitMax = $"{kommunikationPlcMax}ms";

        VmInfo.StringDa0 = $"[0]={_datenstruktur.Da[0]:X2}";
        VmInfo.StringDa1 = $"[1]={_datenstruktur.Da[1]:X2}";
        VmInfo.StringDi0 = $"[0]={_datenstruktur.Di[0]:X2}";
        VmInfo.StringDi1 = $"[1]={_datenstruktur.Di[1]:X2}";
    }
    public void SetResetInfoCallback(Action resetPlcInfo) => CbResetPlcInfo = resetPlcInfo;
}