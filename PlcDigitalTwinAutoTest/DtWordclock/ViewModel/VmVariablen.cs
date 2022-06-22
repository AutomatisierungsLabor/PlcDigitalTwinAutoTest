using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtWordclock.ViewModel;

public partial class VmWordclock
{



    [ObservableProperty] private Brush _brushEins;
    [ObservableProperty] private Brush _brushZwei;
    [ObservableProperty] private Brush _brushDrei;
    [ObservableProperty] private Brush _brushVier;
    [ObservableProperty] private Brush _brushFuenfMinute;  
    [ObservableProperty] private Brush _brushFuenfStunde;
    [ObservableProperty] private Brush _brushSechs;
    [ObservableProperty] private Brush _brushSieben;
    [ObservableProperty] private Brush _brushAcht;
    [ObservableProperty] private Brush _brushNeun;
    [ObservableProperty] private Brush _brushZehnMinute;
    [ObservableProperty] private Brush _brushZehnStunde;
    [ObservableProperty] private Brush _brushElf;
    [ObservableProperty] private Brush _brushZwoelf;
    [ObservableProperty] private Brush _brushZwanzig;

    [ObservableProperty] private Brush _brushEs;
    [ObservableProperty] private Brush _brushIst;
    [ObservableProperty] private Brush _brushBald;
    [ObservableProperty] private Brush _brushGleich;
    [ObservableProperty] private Brush _brushVor;
    [ObservableProperty] private Brush _brushNach;
    [ObservableProperty] private Brush _brushUhr;
    [ObservableProperty] private Brush _brushHalb;
    [ObservableProperty] private Brush _brushViertel;


    [ObservableProperty] private ClickMode _clickAktuelleZeitUebernehmen;

    [ObservableProperty] private double _doubleGeschwindigkeit;
    [ObservableProperty] private double _doubleWinkelSekundenZeiger;
    [ObservableProperty] private double _doubleWinkelMinutenZeiger;
    [ObservableProperty] private double _doubleWinkelStundenZeiger;
}