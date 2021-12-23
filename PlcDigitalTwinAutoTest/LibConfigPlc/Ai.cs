using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Ai : EaConfig<AiEinstellungen>
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
    private readonly SharedFunctions _sharedFunctions = new();

    public Ai(ObservableCollection<AiEinstellungen> zeilen) : base(zeilen)
    {
    }
    protected override void ConfigTesten(byte[] speicherAbbild)
    {
        ConfigOk = true;
        AnzByte = 0;

        foreach (var zeile in Zeilen)
        {
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (zeile.Type)
            {
                case ConfigPlc.EaTypen.Ascii:
                case ConfigPlc.EaTypen.BitmusterByte:
                case ConfigPlc.EaTypen.Byte:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (_sharedFunctions.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.Word:
                case ConfigPlc.EaTypen.SiemensAnalogwertPromille:
                case ConfigPlc.EaTypen.SiemensAnalogwertProzent:
                case ConfigPlc.EaTypen.SiemensAnalogwertSchieberegler:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (_sharedFunctions.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    if (_sharedFunctions.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.NichtBelegt: break;
                default: LogConfigError(zeile); break;
            }
        }

        AnzByte = _sharedFunctions.AnzByteEinlesen(speicherAbbild);
    }
    private void LogConfigError(AiEinstellungen zeile)
    {
        Log.Debug("AI: Kollision 'BitmusterByte'; Byte: " + zeile.StartByte + "Bit: " + zeile.StartBit);
        ConfigOk = false;
    }
}

public class AiEinstellungen
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public ConfigPlc.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }

    public AiEinstellungen()
    {
        StartByte = 0;
        StartBit = 0;
        Type = ConfigPlc.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}