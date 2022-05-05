using LibPlcTools;
using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Da : EaConfig<DaEinstellungen>
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
  
    public Da(ObservableCollection<DaEinstellungen> zeilen) : base(zeilen) { }
    protected override void ConfigTesten(byte[] speicherAbbild)
    {
        ConfigOk = true;
        AnzByte = 0;
        
        foreach (var zeile in Zeilen)
        {
            if (zeile.StartByte > 127 || zeile.StartBit > 7)
            {
                Log.Debug("DA: Ungültige Option für Byte/Bit; Byte: " + zeile.StartByte + "Bit: " + zeile.StartBit);
                ConfigOk = false;
            }
            if (zeile.Bezeichnung.Length == 0)
            {
                Log.Debug($"DA: Bezeichnung fehlt! -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
                ConfigOk = false;
            }
            if (zeile.Kommentar.Length == 0)
            {
                Log.Debug($"DA: Kommentar fehlt! -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
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
                case ConfigPlc.EaTypen.NichtBelegt:
                default: 
                    Log.Debug($"DA: Falsche Type: -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
                    ConfigOk = false;
                    break;
            }
        }

        AnzByte = Bytes.MaxBytePositionBestimmen(speicherAbbild);
    }
    private void LogConfigError(DaEinstellungen zeile)
    {
        Log.Debug($"DA: Kollision -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
        ConfigOk = false;
    }
}

public class DaEinstellungen
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public ConfigPlc.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }


    public DaEinstellungen()
    {
        StartByte = 0;
        StartBit = 0;
        Type = ConfigPlc.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}