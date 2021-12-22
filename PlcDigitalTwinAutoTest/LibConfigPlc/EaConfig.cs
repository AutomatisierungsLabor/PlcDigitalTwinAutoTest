using System.Collections.ObjectModel;

namespace LibConfigPlc;

public abstract class EaConfig<T>
{
    public bool ConfigOk { get; set; }
    public int AnzZeilen { get; set; }
    public int AnzByte { get; set; }
    public ObservableCollection<T> Zeilen { get; set; }

    private readonly byte[] _speicherAbbild = new byte[256];

    protected EaConfig(ObservableCollection<T> zeilen)
    {
        ConfigOk = true;
        Zeilen = zeilen;
        AnzZeilen = zeilen.Count;
        // ReSharper disable once VirtualMemberCallInConstructor
        if (AnzZeilen > 0) ConfigTesten(_speicherAbbild);
        else ConfigOk = false;
    }
    protected abstract void ConfigTesten(byte[] speicherAbbild);
}