using System;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtNadeltelegraph.ViewModel;

public partial class VmNadeltelegraph
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        //  if (gedrueckt)
        // {
        _modelNadeltelegraph.Zeichen = taster switch
        {
            "A" => (byte)'A',
            "B" => (byte)'B',
            "D" => (byte)'D',
            "E" => (byte)'E',
            "F" => (byte)'F',
            "G" => (byte)'G',
            "H" => (byte)'H',
            "I" => (byte)'I',
            "K" => (byte)'K',
            "L" => (byte)'L',
            "M" => (byte)'M',
            "N" => (byte)'N',
            "O" => (byte)'O',
            "P" => (byte)'P',
            "R" => (byte)'R',
            "S" => (byte)'S',
            "T" => (byte)'T',
            "V" => (byte)'V',
            "W" => (byte)'W',
            "Y" => (byte)'Y',
            _ => throw new ArgumentOutOfRangeException(nameof(taster), taster, null)
        };
        //  }
        //  else
        //  {
        //_modelNadeltelegraph.Zeichen = 0x20;
        //  }
    }


    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "A": _modelNadeltelegraph.P0 = true; break;
            case "B": _modelNadeltelegraph.P0 = false; break;
        }
    }
}