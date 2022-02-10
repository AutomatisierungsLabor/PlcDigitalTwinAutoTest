using LibPlcTools;
using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Di : EaConfig<DiEinstellungen>
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    public Di(ObservableCollection<DiEinstellungen> zeilen) : base(zeilen) { }
    protected override void ConfigTesten(byte[] speicherAbbild)
    {
        ConfigOk = true;
        AnzByte = 0;

        foreach (var zeile in Zeilen)
        {
            if (zeile.StartByte > 127 || zeile.StartBit > 7)
            {
                Log.Debug("DI: Ungültige Option für Byte/Bit; Byte: " + zeile.StartByte + "Bit: " + zeile.StartBit);
                ConfigOk = false;
            }

            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (zeile.Type)
            {
                case ConfigPlc.EaTypen.Bit:
                    var bitMuster = Bitmuster.BitmusterErzeugen(zeile.StartBit);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, bitMuster)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.Byte:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.Word:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.Ascii:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.BitmusterByte:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.NichtBelegt: break;
                default: LogConfigError(zeile); break;
            }
        }

        AnzByte = Bytes.MaxBytePositionBestimmen(speicherAbbild);
    }

    private void LogConfigError(DiEinstellungen zeile)
    {
        Log.Debug("DI: Kollision 'BitmusterByte'; Byte: " + zeile.StartByte + "Bit: " + zeile.StartBit);
        ConfigOk = false;
    }
}

public class DiEinstellungen
{
    public int LaufendeNr { get; set; }
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public int AnzahlBit { get; set; }
    public ConfigPlc.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }

    public DiEinstellungen()
    {
        LaufendeNr = 0;
        StartByte = 0;
        StartBit = 0;
        AnzahlBit = 0;
        Type = ConfigPlc.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}