using System.Threading;

namespace BasePlcDtAt.BaseModel;

public abstract class Model
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected abstract void ModelTaskThread();

    public LibDatenstruktur.Datenstruktur Datenstruktur { get; set; }
    public LibConfigPlc.Config ConfigPlc { get; set; }

    private readonly DatenRangieren _datenRangieren;

    protected Model()
    {
        Log.Debug("Konstruktor BasePlcDtAt  BaseModel startet");

        Datenstruktur = new();
        ConfigPlc = new();
        
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
    
}