using System.Collections.ObjectModel;

namespace LibConfigPlc;

public abstract class EaConfig<T>
{
    public bool ConfigOk { get; set; }
    public int AnzZeilen { get; set; }
    public int AnzByte { get; set; }
    public ObservableCollection<T> Zeilen { get; set; }

    protected EaConfig(ObservableCollection<T> zeilen)
    {
        ConfigOk = true;
        Zeilen = zeilen;
        AnzZeilen = zeilen.Count;
        ConfigTesten();
    }

    protected abstract void ConfigTesten();
}