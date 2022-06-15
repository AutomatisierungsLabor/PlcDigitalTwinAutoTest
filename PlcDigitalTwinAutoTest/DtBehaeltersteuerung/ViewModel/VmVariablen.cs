using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtBehaeltersteuerung.ViewModel;

public partial class VmBehaeltersteuerung
{
    [ObservableProperty] private bool _boolDropdownEnabled;

    [ObservableProperty] private Brush _brushesZuleitung1;
    [ObservableProperty] private Brush _brushesZuleitung2;
    [ObservableProperty] private Brush _brushesZuleitung3;
    [ObservableProperty] private Brush _brushesZuleitung4;

    [ObservableProperty] private Brush _brushesAbleitungOben1;
    [ObservableProperty] private Brush _brushesAbleitungOben2;
    [ObservableProperty] private Brush _brushesAbleitungOben3;
    [ObservableProperty] private Brush _brushesAbleitungOben4;

    [ObservableProperty] private Brush _brushesAbleitungUnten1;
    [ObservableProperty] private Brush _brushesAbleitungUnten2;
    [ObservableProperty] private Brush _brushesAbleitungUnten3;
    [ObservableProperty] private Brush _brushesAbleitungUnten4;

    [ObservableProperty] private Brush _brushesAbleitungGesamt;

    [ObservableProperty] private Brush _brushesB1;
    [ObservableProperty] private Brush _brushesB2;
    [ObservableProperty] private Brush _brushesB3;
    [ObservableProperty] private Brush _brushesB4;
    [ObservableProperty] private Brush _brushesB5;
    [ObservableProperty] private Brush _brushesB6;
    [ObservableProperty] private Brush _brushesB7;
    [ObservableProperty] private Brush _brushesB8;

    [ObservableProperty] private ClickMode _clickModeQ2;
    [ObservableProperty] private ClickMode _clickModeQ4;
    [ObservableProperty] private ClickMode _clickModeQ6;
    [ObservableProperty] private ClickMode _clickModeQ8;

    [ObservableProperty] private Thickness _thicknessFuellstand1;
    [ObservableProperty] private Thickness _thicknessFuellstand2;
    [ObservableProperty] private Thickness _thicknessFuellstand3;
    [ObservableProperty] private Thickness _thicknessFuellstand4;

    [ObservableProperty] private Visibility _visibilityEinQ1;
    [ObservableProperty] private Visibility _visibilityEinQ2;
    [ObservableProperty] private Visibility _visibilityEinQ3;
    [ObservableProperty] private Visibility _visibilityEinQ4;
    [ObservableProperty] private Visibility _visibilityEinQ5;
    [ObservableProperty] private Visibility _visibilityEinQ6;
    [ObservableProperty] private Visibility _visibilityEinQ7;
    [ObservableProperty] private Visibility _visibilityEinQ8;

    [ObservableProperty] private Visibility _visibilityAusQ1;
    [ObservableProperty] private Visibility _visibilityAusQ2;
    [ObservableProperty] private Visibility _visibilityAusQ3;
    [ObservableProperty] private Visibility _visibilityAusQ4;
    [ObservableProperty] private Visibility _visibilityAusQ5;
    [ObservableProperty] private Visibility _visibilityAusQ6;
    [ObservableProperty] private Visibility _visibilityAusQ7;
    [ObservableProperty] private Visibility _visibilityAusQ8;

}