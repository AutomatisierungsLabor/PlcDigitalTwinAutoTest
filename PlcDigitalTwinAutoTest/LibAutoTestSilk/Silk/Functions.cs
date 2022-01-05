using LibPlcTools;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public void Runtime_Function(object sender, FunctionEventArgs e)
    {
        switch (e.Name)
        {
            case "BitmusterBlinktTesten": BitmusterBlinktTesten(e); break;
            case "BitmusterTesten": BitmusterTesten(e); break;
            case "GetDigitaleAusgaenge": GetDa(e); break;
            case "IncrementDataGridId": IncrementDataGridId(); break;
            case "KommentarAnzeigen": KommentarAnzeigen(e); break;
            case "Plc2Dec": Plc2Dec(e); break;
            case "ResetStopwatch": ResetStopwatch(); break;
            case "SetAnalogerEingang": SetAi(e); break;
            case "SetDataGridBitAnzahl": SetDataGridBitAnzahl(); break; // Anzeige mit 16 bit 
            case "SetDiagrammZeitbereich": SetDiagrammZeitbereich(e); break;
            case "SetDigitaleEingaenge": SetDi(e); break;
            case "Sleep": Sleep(e); break;
            case "TestAblauf": TestAblauf(e); break;
            case "UpdateAnzeige": UpdateAnzeige(e); break;
            case "VersionAnzeigen": VersionAnzeigen(); break;
        }
    }
    private void Plc2Dec(FunctionEventArgs e)
    {
        var zahl = e.Parameters[0].ToString();
        var plcZahl = new Uint(zahl);
        e.ReturnValue.SetValue((int)plcZahl.GetDec());
    }
}