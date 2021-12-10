using System.Threading;

namespace BasePlcDtAt.BaseModel;

public abstract class Model
{

    private static DatenRangieren _datenRangieren;

    private void KataTask()
    {
        while (true)
        {
            _datenRangieren.Rangieren();

            DoStuff();

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    protected abstract void DoStuff();
    internal void SetDtAutoTests()
    {
        _datenRangieren = new DatenRangieren(this);


        System.Threading.Tasks.Task.Run(KataTask);
    }
}