using System.Threading;

namespace BasePlcDtAt.BaseModel;

public abstract class BaseModel
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ModelThread();

    private readonly CancellationTokenSource _cancellationTokenSource;

    protected BaseModel(CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");
        _cancellationTokenSource = cancellationTokenSource;
        System.Threading.Tasks.Task.Run(ModelTask);
    }

    protected void ModelTask()
    {
        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            ModelThread();
            Thread.Sleep(10);
        }
    }
}