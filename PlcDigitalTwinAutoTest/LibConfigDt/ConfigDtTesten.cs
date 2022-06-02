using Contracts;
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
        if (DtConfig.AnalogeAusgaenge.EaConfig == null)
        {
            DtConfig.AnalogeAusgaenge.ConfigOk = true;
            DtConfig.AnalogeAusgaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.AnalogeAusgaenge.ConfigOk, DtConfig.AnalogeAusgaenge.AnzByte) = EaConfigTesten("Aa", DtConfig.AnalogeAusgaenge.EaConfig);
        }
    }
    private void AiTesten()
    {
        if (DtConfig.AnalogeEingaenge.EaConfig == null)
        {
            DtConfig.AnalogeEingaenge.ConfigOk = true;
            DtConfig.AnalogeEingaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.AnalogeEingaenge.ConfigOk, DtConfig.AnalogeEingaenge.AnzByte) = EaConfigTesten("Ai", DtConfig.AnalogeEingaenge.EaConfig);
        }
    }
    private void DaTesten()
    {
        if (DtConfig.DigitaleAusgaenge.EaConfig == null)
        {
            DtConfig.DigitaleAusgaenge.ConfigOk = true;
            DtConfig.DigitaleAusgaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.DigitaleAusgaenge.ConfigOk, DtConfig.DigitaleAusgaenge.AnzByte) = EaConfigTesten("Da", DtConfig.DigitaleAusgaenge.EaConfig);
        }
    }
    private void DiTesten()
    {
        if (DtConfig.DigitaleEingaenge.EaConfig == null)
        {
            DtConfig.DigitaleEingaenge.ConfigOk = true;
            DtConfig.DigitaleEingaenge.AnzByte = 0;
        }
        else
        {
            (DtConfig.DigitaleEingaenge.ConfigOk, DtConfig.DigitaleEingaenge.AnzByte) = EaConfigTesten("Di", DtConfig.DigitaleEingaenge.EaConfig);
        }
    }
    private static (bool ConfigOk, int AnzByte) EaConfigTesten(string bez, IEnumerable<EaConfig> eaConfigs)
    {
        var speicherAbbild = new byte[256];
        var configProblem = 0;

        foreach (var zeile in eaConfigs)
        {
            zeile.EaConfigError = EaConfigError.None;
            if (zeile.StartByte > 127) configProblem |= LogConfigError($"{bez} Ungültige Option für Byteposition: ", zeile, EaConfigError.UngueltigesStartByte);
            if (zeile.StartBit > 7) configProblem |= LogConfigError($"{bez} Ungültige Option für Bitposition: ", zeile, EaConfigError.UngueltigesStartBit);
            if (zeile.Bezeichnung.Length == 0) configProblem |= LogConfigError($"{bez} Bezeichnung fehlt: ", zeile, EaConfigError.BezeichnungFehlt);
            if (zeile.Kommentar.Length == 0) configProblem |= LogConfigError($"{bez} Kommentar fehlt: ", zeile, EaConfigError.KommentarFehlt);

            if (zeile.EaConfigError != EaConfigError.None) continue;    // Es wird nur ein einziger Fehler erkannt!

            switch (zeile.Type)
            {
                case EaTypen.Bit:
                    var bitMuster = Bitmuster.BitmusterErzeugen(zeile.StartBit);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, bitMuster)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile, EaConfigError.BitKollision);
                    break;

                case EaTypen.Ascii:
                case EaTypen.BitmusterByte:
                case EaTypen.Byte:
                    if (zeile.StartBit > 0) configProblem |= LogConfigError($"{bez} Startbit != 0: ", zeile, EaConfigError.UngueltigesStartBit);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile, EaConfigError.ByteKollision);
                    break;

                case EaTypen.Word:
                case EaTypen.SiemensAnalogwertPromille:
                case EaTypen.SiemensAnalogwertProzent:
                case EaTypen.SiemensAnalogwertSchieberegler:
                    if (zeile.StartBit > 0) configProblem |= LogConfigError($"{bez} Startbit != 0: ", zeile, EaConfigError.UngueltigesStartBit);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) configProblem |= LogConfigError(bez, zeile, EaConfigError.ByteKollision);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile, EaConfigError.ByteKollision);
                    break;


                case EaTypen.DWord:
                    if (zeile.StartBit > 0) configProblem |= LogConfigError($"{bez} Startbit != 0: ", zeile, EaConfigError.UngueltigesStartBit);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) configProblem |= LogConfigError(bez, zeile, EaConfigError.ByteKollision);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile, EaConfigError.ByteKollision);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 2, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile, EaConfigError.ByteKollision);
                    if (Bytes.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 3, 0xFF)) configProblem |= LogConfigError($"{bez} Kollission: ", zeile, EaConfigError.ByteKollision);
                    break;

                case EaTypen.NichtBelegt:
                    configProblem |= LogConfigError(bez, zeile, EaConfigError.NichtBelegt);
                    break;
                case EaTypen.TestErrorAusgeben:
                default:
                    configProblem |= LogConfigError(bez, zeile, EaConfigError.UnbekannterFehler);
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
    private static byte LogConfigError(string bez, EaConfig eaConfig, EaConfigError error)
    {
        eaConfig.EaConfigError = error;
        Log.Debug($"{bez} {eaConfig.Type}; Byte: {eaConfig.StartByte} Bit: {eaConfig.StartBit} Kommentar: {eaConfig.Kommentar} Bezeichnung: {eaConfig.Bezeichnung}");
        return 1;
    }
}