using System;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtParkhaus.ViewModel;

public partial class VmParkhaus
{
    private readonly Random _random = new();

    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "Zufall": _random.NextBytes(_modelParkhaus.BesetzteParkPlaetze); break;
            default:
                var (_, zehner, einer) = LibPlcTools.Bytes.ByteToBcdCode(Convert.ToByte(taster));
                LibPlcTools.Bytes.BitTogglen(_modelParkhaus.BesetzteParkPlaetze, zehner, einer);
                break;
        }
    }
}