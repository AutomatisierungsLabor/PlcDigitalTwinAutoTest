using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtTiefgarage.ViewModel;

public partial class VmTiefgarage
{
    [ObservableProperty] private Brush _brushB1;
    [ObservableProperty] private Brush _brushB2;

    [ObservableProperty] private ClickMode _clickModePkw1;
    [ObservableProperty] private ClickMode _clickModePkw2;
    [ObservableProperty] private ClickMode _clickModePkw3;
    [ObservableProperty] private ClickMode _clickModePkw4;

    [ObservableProperty] private ClickMode _clickModeDrinnenParken;
    [ObservableProperty] private ClickMode _clickModeDraussenParken;

    [ObservableProperty] private Thickness _thicknessPkw1;
    [ObservableProperty] private Thickness _thicknessPkw2;
    [ObservableProperty] private Thickness _thicknessPkw3;
    [ObservableProperty] private Thickness _thicknessPkw4;

    [ObservableProperty] private Thickness _thicknessMensch1;
    [ObservableProperty] private Thickness _thicknessMensch2;
    [ObservableProperty] private Thickness _thicknessMensch3;
    [ObservableProperty] private Thickness _thicknessMensch4;

    [ObservableProperty] private string _stringAnzahlAutos;
    [ObservableProperty] private string _stringAnzahlPersonen;


}