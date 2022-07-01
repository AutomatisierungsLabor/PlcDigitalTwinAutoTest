using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtBerlinUhr.ViewModel;

public partial class VmBerlinUhr
{
    [ObservableProperty] private Brush _brushSegmentSekunde;
    [ObservableProperty] private Brush _brushSegment5Stunden1;
    [ObservableProperty] private Brush _brushSegment5Stunden2;
    [ObservableProperty] private Brush _brushSegment5Stunden3;
    [ObservableProperty] private Brush _brushSegment5Stunden4;
    [ObservableProperty] private Brush _brushSegment1Stunde1;
    [ObservableProperty] private Brush _brushSegment1Stunde2;
    [ObservableProperty] private Brush _brushSegment1Stunde3;
    [ObservableProperty] private Brush _brushSegment1Stunde4;
    [ObservableProperty] private Brush _brushSegment5Minuten1;
    [ObservableProperty] private Brush _brushSegment5Minuten2;
    [ObservableProperty] private Brush _brushSegment5Minuten3;
    [ObservableProperty] private Brush _brushSegment5Minuten4;
    [ObservableProperty] private Brush _brushSegment5Minuten5;
    [ObservableProperty] private Brush _brushSegment5Minuten6;
    [ObservableProperty] private Brush _brushSegment5Minuten7;
    [ObservableProperty] private Brush _brushSegment5Minuten8;
    [ObservableProperty] private Brush _brushSegment5Minuten9;
    [ObservableProperty] private Brush _brushSegment5Minuten10;
    [ObservableProperty] private Brush _brushSegment5Minuten11;
    [ObservableProperty] private Brush _brushSegment1Minute1;
    [ObservableProperty] private Brush _brushSegment1Minute2;
    [ObservableProperty] private Brush _brushSegment1Minute3;
    [ObservableProperty] private Brush _brushSegment1Minute4;

    [ObservableProperty] private ClickMode _clickAktuelleZeitUebernehmen;

    [ObservableProperty] private double _doubleGeschwindigkeit;
    [ObservableProperty] private double _doubleWinkelSekundenZeiger;
    [ObservableProperty] private double _doubleWinkelSekundenZeigerKreisOderSo;
    [ObservableProperty] private double _doubleWinkelMinutenZeiger;
    [ObservableProperty] private double _doubleWinkelStundenZeiger;
}