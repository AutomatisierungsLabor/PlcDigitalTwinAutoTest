namespace LibInfo;

public partial class DisplayInfo
{
    public VmInfo.VmInfo VmInfo { get; set; }
    public bool FensterAktiv { get; set; }

    public DisplayInfo()
    {
        InitializeComponent();


        DataContext = VmInfo;

        VmInfo = new VmInfo.VmInfo(Grid);
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

    public void SetKommunikationPlcValues(int kommunikationPlcAvg, int kommunikationPlcMax, int kommunikationPlcMin)
    {
        VmInfo.StringKommunikationPlcAvg = $"{kommunikationPlcAvg}ms";
        VmInfo.StringKommunikationPlcMax = $"{kommunikationPlcMax}ms";
        VmInfo.StringKommunikationPlcMin = $"{kommunikationPlcMin}ms";
    }
}