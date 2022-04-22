using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibInfo.VmInfo;

public partial class VmInfo : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
    public static DisplayInfo DisplayInfo;

    public VmInfo(DisplayInfo displayInfo)
    {
        Log.Debug("Konstruktor - startet");

        DisplayInfo = displayInfo;
    }
}