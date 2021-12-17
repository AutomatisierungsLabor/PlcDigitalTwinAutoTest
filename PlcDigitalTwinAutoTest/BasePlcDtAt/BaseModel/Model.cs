using System.Runtime.CompilerServices;
using System.Threading;
using LibConfigPlc;
using LibDatenstruktur;

namespace BasePlcDtAt.BaseModel;

public abstract class Model
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ModelTaskThread();

    public static Datenstruktur Datenstruktur { get; set; }
    public Config ConfigPlc { get; set; }

    public string VersionLokal { get; set; } = "-?-";
    public string VersionPlc { get; set; } = "-???-";


    private readonly DatenRangieren _datenRangieren;

    protected Model()
    {
        Log.Debug("Konstruktor - startet");


        ConfigPlc = new Config();

        _datenRangieren = new DatenRangieren(this);

        System.Threading.Tasks.Task.Run(ModelTask);
    }

    private void ModelTask()
    {
        while (true)
        {
            _datenRangieren.Rangieren();

            ModelTaskThread();

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    public static void BetriebsartUmschalten(int i)
    {
        Datenstruktur.BetriebsartProjekt = i switch
        {
            0 => BetriebsartProjekt.LaborPlatte,
            1 => BetriebsartProjekt.Simulation,
            2 => BetriebsartProjekt.AutomatischerSoftwareTest,
            _ => Datenstruktur.BetriebsartProjekt
        };

        
    }


}