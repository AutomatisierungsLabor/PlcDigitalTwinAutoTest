﻿using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2018_2_Abfuellanlage.ViewModel;

public partial class VmLap2018
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {  }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        { }
    }
}