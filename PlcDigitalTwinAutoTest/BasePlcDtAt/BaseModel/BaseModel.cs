using System.Diagnostics;
using System.Threading;
using LibDatenstruktur;

namespace BasePlcDtAt.BaseModel;

public abstract class BaseModel
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ModelSetValues();
    protected abstract void ModelThread(double dT);

    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Datenstruktur _datenstruktur;
    private BetriebsartProjekt _betriebsartProjekt;

    protected BaseModel(CancellationTokenSource cancellationTokenSource, Datenstruktur datenstruktur)
    {
        Log.Debug("Konstruktor - startet");
        _cancellationTokenSource = cancellationTokenSource;
        _datenstruktur = datenstruktur;
        System.Threading.Tasks.Task.Run(ModelTask);
    }

    protected void ModelTask()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            if (_betriebsartProjekt != _datenstruktur.BetriebsartProjekt)
            {
                _betriebsartProjekt = _datenstruktur.BetriebsartProjekt;
                ModelSetValues();
            }

            ModelThread((double)stopWatch.ElapsedMilliseconds / 1000);
            stopWatch.Restart();
            Thread.Sleep(10);
        }
    }
}