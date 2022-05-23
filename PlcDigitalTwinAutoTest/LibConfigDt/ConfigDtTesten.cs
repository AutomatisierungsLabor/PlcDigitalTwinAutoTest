using LibPlcTools;

namespace LibConfigDt;

public partial class ConfigDt
{
    private void JsonAufFehlerTesten()
    {
        TextbausteineTesten();
        AaTesten();
        AiTesten();
        DaTesten();
        DiTesten();
    }
    private void AaTesten()
    {
        if (DtConfig.AnalogeAusgaenge.EaConfigs == null)
        {
            DtConfig.AnalogeAusgaenge.ConfigOk = true;
            DtConfig.AnalogeAusgaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.AnalogeAusgaenge.ConfigOk, DtConfig.AnalogeAusgaenge.AnzByte) = EaConfigTesten("Aa", DtConfig.AnalogeAusgaenge.EaConfigs);
        }
    }
    private void AiTesten()
    {
        if (DtConfig.AnalogeEingaenge.EaConfigs == null)
        {
            DtConfig.AnalogeEingaenge.ConfigOk = true;
            DtConfig.AnalogeEingaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.AnalogeEingaenge.ConfigOk, DtConfig.AnalogeEingaenge.AnzByte) = EaConfigTesten("Ai", DtConfig.AnalogeEingaenge.EaConfigs);
        }
    }
    private void DaTesten()
    {
        if (DtConfig.DigitaleAusgaenge.EaConfigs == null)
        {
            DtConfig.DigitaleAusgaenge.ConfigOk = true;
            DtConfig.DigitaleAusgaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.DigitaleAusgaenge.ConfigOk, DtConfig.DigitaleAusgaenge.AnzByte) = EaConfigTesten("Da", DtConfig.DigitaleAusgaenge.EaConfigs);
        }
    }
    private void DiTesten()
    {
        if (DtConfig.DigitaleEingaenge.EaConfigs == null)
        {
            DtConfig.DigitaleEingaenge.ConfigOk = true;
            DtConfig.DigitaleEingaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.DigitaleEingaenge.ConfigOk, DtConfig.DigitaleEingaenge.AnzByte) = EaConfigTesten("Di", DtConfig.DigitaleEingaenge.EaConfigs);
        }
    }
    private static (bool ConfigOk, int AnzByte) EaConfigTesten(string bez, IEnumerable<EaConfig> eaConfigs)
    {
        var speicherAbbild = new byte[256];
        var configProblem = 0;

        foreach (var zeile in eaConfigs)
        {
            if (zeile.StartByte > 127 || zeile.StartBit > 7) configProblem |= LogConfigError($"{bez} Ungültige Option für Byte/Bit: ", zeile);
            if (zeile.Bezeichnung.Length == 0) configProblem |= LogConfigError($"{bez} Bezeichnung fehlt: ", zeile);
            if (zeile.Kommentar.Length == 0) configProblem |= LogConfigError($"{bez} Kommentar fehlt: ", zeile);

            switch (zeile.Type)
            {
                case EaTypen.Bit:
                    var bitMuster = Bitmuster.BitmusterErzeugen(zeile.StartBit);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, bitMuster)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile);
                    break;

                case EaTypen.Ascii:
                case EaTypen.BitmusterByte:
                case EaTypen.Byte:
                    if (zeile.StartBit > 0) configProblem |= LogConfigError($"{bez} Startbit != 0: ", zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile);
                    break;

                case EaTypen.Word:
                case EaTypen.SiemensAnalogwertPromille:
                case EaTypen.SiemensAnalogwertProzent:
                case EaTypen.SiemensAnalogwertSchieberegler:
                    if (zeile.StartBit > 0) configProblem |= LogConfigError($"{bez} Startbit != 0: ", zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) configProblem |= LogConfigError(bez, zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile);
                    break;


                case EaTypen.DWord:
                    if (zeile.StartBit > 0) configProblem |= LogConfigError($"{bez} Startbit != 0: ", zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) configProblem |= LogConfigError(bez, zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 2, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 3, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile);
                    break;

                case EaTypen.NichtBelegt:
                    configProblem |= LogConfigError(bez, zeile);
                    break;
                default:
                    configProblem |= LogConfigError(bez, zeile);
                    break;
            }
        }

        var anzByte = Bytes.MaxBytePositionBestimmen(speicherAbbild);
        return configProblem == 0 ? (true, anzByte) : (false, anzByte);
    }
    private void TextbausteineTesten()
    {
        if (DtConfig.Textbausteine.Length == 0) return;

        foreach (var textbausteine in DtConfig.Textbausteine)
        {
            if (textbausteine.PrefixH1 == null) Log.Debug("PrefixH1 ist leer");
            if (textbausteine.PrefixH2 == null) Log.Debug("PrefixH2 ist leer");
        }
    }
    private static byte LogConfigError(string bez, EaConfig eaConfig)
    {
        Log.Debug($"{bez} {eaConfig.Type}; Byte: {eaConfig.StartByte} Bit: {eaConfig.StartBit} Kommentar: {eaConfig.Kommentar} Bezeichnung: {eaConfig.Bezeichnung}");
        return 1;
    }
}