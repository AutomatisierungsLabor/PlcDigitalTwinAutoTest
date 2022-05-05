using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Aa : EaConfig<AaEinstellungen>
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public Aa(ObservableCollection<AaEinstellungen> zeilen) : base(zeilen) { }
    protected override void ConfigTesten(byte[] speicherAbbild)
    {
        ConfigOk = true;
        AnzByte = 0;

        foreach (var zeile in Zeilen)
        {
            if (zeile.Bezeichnung.Length == 0)
            {
                Log.Debug($"AA: Bezeichnung fehlt! -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
                ConfigOk = false;
            }
            if (zeile.Kommentar.Length == 0)
            {
                Log.Debug($"AA: Kommentar fehlt! -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
                ConfigOk = false;
            }

            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (zeile.Type)
            {
                case ConfigPlc.EaTypen.Byte:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.Word:
                case ConfigPlc.EaTypen.SiemensAnalogwertPromille:
                case ConfigPlc.EaTypen.SiemensAnalogwertProzent:
                case ConfigPlc.EaTypen.SiemensAnalogwertSchieberegler:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.DWord:
                    if (zeile.StartBit > 0) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 2, 0xFF)) LogConfigError(zeile);
                    if (LibPlcTools.Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 3, 0xFF)) LogConfigError(zeile);
                    break;
                case ConfigPlc.EaTypen.NichtBelegt:
                default:
                    Log.Debug($"AA: Falsche Type: -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
                    ConfigOk = false;
                    break;
            }
        }

        AnzByte = LibPlcTools.Bytes.MaxBytePositionBestimmen(speicherAbbild);
    }
    private void LogConfigError(AaEinstellungen zeile)
    {
        Log.Debug($"AA: Kollision -> {zeile.Type}; Byte: {zeile.StartByte} Bit: {zeile.StartBit} Kommentar: {zeile.Kommentar} Bezeichnung: {zeile.Bezeichnung}");
        ConfigOk = false;
    }
}

public class AaEinstellungen
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public double MinimalWert { get; set; }
    public double MaximalWert { get; set; }
    public double Schrittweite { get; set; }
    public ConfigPlc.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }

    public AaEinstellungen()
    {
        StartByte = 0;
        StartBit = 0;
        MinimalWert = 0;
        MaximalWert = 0;
        Schrittweite = 0;
        Type = ConfigPlc.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}