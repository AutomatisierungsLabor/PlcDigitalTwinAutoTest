using System.Threading;

namespace BasePlcDtAt.BaseModel;

public class Model
{

    private static DatenRangieren _datenRangieren;

    private static void KataTask()
    {
        while (true)
        {
            _datenRangieren.Rangieren();

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    internal void SetDtAutoTests()
    {
        _datenRangieren = new DatenRangieren(this);


        System.Threading.Tasks.Task.Run(KataTask);
    }
}