using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Controls;

namespace DtNadeltelegraph.ViewModel;

public partial class VmNadeltelegraph
{
    public byte TasterAsciiCode;

    [ICommand]
    private void ButtonTaster(string taster)
    {
        TasterAsciiCode = 0;

        ClickModeBuchstabeA = TasterGedrueckt(taster, 'A', ClickModeBuchstabeA);
        ClickModeBuchstabeB = TasterGedrueckt(taster, 'B', ClickModeBuchstabeB);
        ClickModeBuchstabeD = TasterGedrueckt(taster, 'D', ClickModeBuchstabeD);
        ClickModeBuchstabeE = TasterGedrueckt(taster, 'E', ClickModeBuchstabeE);
        ClickModeBuchstabeF = TasterGedrueckt(taster, 'F', ClickModeBuchstabeF);
        ClickModeBuchstabeG = TasterGedrueckt(taster, 'G', ClickModeBuchstabeG);
        ClickModeBuchstabeH = TasterGedrueckt(taster, 'H', ClickModeBuchstabeH);
        ClickModeBuchstabeI = TasterGedrueckt(taster, 'I', ClickModeBuchstabeI);
        ClickModeBuchstabeK = TasterGedrueckt(taster, 'K', ClickModeBuchstabeK);
        ClickModeBuchstabeL = TasterGedrueckt(taster, 'L', ClickModeBuchstabeL);
        ClickModeBuchstabeM = TasterGedrueckt(taster, 'M', ClickModeBuchstabeM);
        ClickModeBuchstabeN = TasterGedrueckt(taster, 'N', ClickModeBuchstabeN);
        ClickModeBuchstabeO = TasterGedrueckt(taster, 'O', ClickModeBuchstabeO);
        ClickModeBuchstabeP = TasterGedrueckt(taster, 'P', ClickModeBuchstabeP);
        ClickModeBuchstabeR = TasterGedrueckt(taster, 'R', ClickModeBuchstabeR);
        ClickModeBuchstabeS = TasterGedrueckt(taster, 'S', ClickModeBuchstabeS);
        ClickModeBuchstabeT = TasterGedrueckt(taster, 'T', ClickModeBuchstabeT);
        ClickModeBuchstabeV = TasterGedrueckt(taster, 'V', ClickModeBuchstabeV);
        ClickModeBuchstabeW = TasterGedrueckt(taster, 'W', ClickModeBuchstabeW);
        ClickModeBuchstabeY = TasterGedrueckt(taster, 'Y', ClickModeBuchstabeY);

        _modelNadeltelegraph.AsciiCode = TasterAsciiCode == 0 ? (byte)0x20 : TasterAsciiCode;
    }
    private ClickMode TasterGedrueckt(string taster, char buchstabe, ClickMode clickMode)
    {
        if (taster.Contains(buchstabe.ToString()) && clickMode == ClickMode.Press && TasterAsciiCode == 0) TasterAsciiCode = (byte)buchstabe;
        return clickMode == ClickMode.Press ? ClickMode.Release : ClickMode.Press;
    }
}