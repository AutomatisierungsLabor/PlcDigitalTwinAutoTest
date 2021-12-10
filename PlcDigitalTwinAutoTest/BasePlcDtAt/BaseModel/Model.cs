using System.Threading;

namespace BasePlcDtAt.BaseModel;

public abstract class Model
{
    protected abstract void ModelTaskThread();

    private DatenRangieren _datenRangieren;

    protected Model()
    {
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