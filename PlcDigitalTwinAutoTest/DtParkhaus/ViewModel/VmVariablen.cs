using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtParkhaus.ViewModel;

public partial class VmParkhaus
{
    [ObservableProperty] private Brush _brushB00;
    [ObservableProperty] private Brush _brushB01;
    [ObservableProperty] private Brush _brushB02;
    [ObservableProperty] private Brush _brushB03;
    [ObservableProperty] private Brush _brushB04;
    [ObservableProperty] private Brush _brushB05;
    [ObservableProperty] private Brush _brushB06;
    [ObservableProperty] private Brush _brushB07;

    [ObservableProperty] private Brush _brushB10;
    [ObservableProperty] private Brush _brushB11;
    [ObservableProperty] private Brush _brushB12;
    [ObservableProperty] private Brush _brushB13;
    [ObservableProperty] private Brush _brushB14;
    [ObservableProperty] private Brush _brushB15;
    [ObservableProperty] private Brush _brushB16;
    [ObservableProperty] private Brush _brushB17;

    [ObservableProperty] private Brush _brushB20;
    [ObservableProperty] private Brush _brushB21;
    [ObservableProperty] private Brush _brushB22;
    [ObservableProperty] private Brush _brushB23;
    [ObservableProperty] private Brush _brushB24;
    [ObservableProperty] private Brush _brushB25;
    [ObservableProperty] private Brush _brushB26;
    [ObservableProperty] private Brush _brushB27;

    [ObservableProperty] private Brush _brushB30;
    [ObservableProperty] private Brush _brushB31;
    [ObservableProperty] private Brush _brushB32;
    [ObservableProperty] private Brush _brushB33;
    [ObservableProperty] private Brush _brushB34;
    [ObservableProperty] private Brush _brushB35;
    [ObservableProperty] private Brush _brushB36;
    [ObservableProperty] private Brush _brushB37;

    [ObservableProperty] private ClickMode _clickModeZufall;
    
    [ObservableProperty] private ClickMode _clickModePkw00; 
    [ObservableProperty] private ClickMode _clickModePkw01;
    [ObservableProperty] private ClickMode _clickModePkw02;
    [ObservableProperty] private ClickMode _clickModePkw03;
    [ObservableProperty] private ClickMode _clickModePkw04;
    [ObservableProperty] private ClickMode _clickModePkw05;
    [ObservableProperty] private ClickMode _clickModePkw06;
    [ObservableProperty] private ClickMode _clickModePkw07;

    [ObservableProperty] private ClickMode _clickModePkw10;
    [ObservableProperty] private ClickMode _clickModePkw11;
    [ObservableProperty] private ClickMode _clickModePkw12;
    [ObservableProperty] private ClickMode _clickModePkw13;
    [ObservableProperty] private ClickMode _clickModePkw14;
    [ObservableProperty] private ClickMode _clickModePkw15;
    [ObservableProperty] private ClickMode _clickModePkw16;
    [ObservableProperty] private ClickMode _clickModePkw17;

    [ObservableProperty] private ClickMode _clickModePkw20;
    [ObservableProperty] private ClickMode _clickModePkw21;
    [ObservableProperty] private ClickMode _clickModePkw22;
    [ObservableProperty] private ClickMode _clickModePkw23;
    [ObservableProperty] private ClickMode _clickModePkw24;
    [ObservableProperty] private ClickMode _clickModePkw25;
    [ObservableProperty] private ClickMode _clickModePkw26;
    [ObservableProperty] private ClickMode _clickModePkw27;

    [ObservableProperty] private ClickMode _clickModePkw30;
    [ObservableProperty] private ClickMode _clickModePkw31;
    [ObservableProperty] private ClickMode _clickModePkw32;
    [ObservableProperty] private ClickMode _clickModePkw33;
    [ObservableProperty] private ClickMode _clickModePkw34;
    [ObservableProperty] private ClickMode _clickModePkw35;
    [ObservableProperty] private ClickMode _clickModePkw36;
    [ObservableProperty] private ClickMode _clickModePkw37;

    [ObservableProperty] private Visibility _visibilityPkw00;
    [ObservableProperty] private Visibility _visibilityPkw01;
    [ObservableProperty] private Visibility _visibilityPkw02;
    [ObservableProperty] private Visibility _visibilityPkw03;
    [ObservableProperty] private Visibility _visibilityPkw04;
    [ObservableProperty] private Visibility _visibilityPkw05;
    [ObservableProperty] private Visibility _visibilityPkw06;
    [ObservableProperty] private Visibility _visibilityPkw07;

    [ObservableProperty] private Visibility _visibilityPkw10;
    [ObservableProperty] private Visibility _visibilityPkw11;
    [ObservableProperty] private Visibility _visibilityPkw12;
    [ObservableProperty] private Visibility _visibilityPkw13;
    [ObservableProperty] private Visibility _visibilityPkw14;
    [ObservableProperty] private Visibility _visibilityPkw15;
    [ObservableProperty] private Visibility _visibilityPkw16;
    [ObservableProperty] private Visibility _visibilityPkw17;

    [ObservableProperty] private Visibility _visibilityPkw20;
    [ObservableProperty] private Visibility _visibilityPkw21;
    [ObservableProperty] private Visibility _visibilityPkw22;
    [ObservableProperty] private Visibility _visibilityPkw23;
    [ObservableProperty] private Visibility _visibilityPkw24;
    [ObservableProperty] private Visibility _visibilityPkw25;
    [ObservableProperty] private Visibility _visibilityPkw26;
    [ObservableProperty] private Visibility _visibilityPkw27;

    [ObservableProperty] private Visibility _visibilityPkw30;
    [ObservableProperty] private Visibility _visibilityPkw31;
    [ObservableProperty] private Visibility _visibilityPkw32;
    [ObservableProperty] private Visibility _visibilityPkw33;
    [ObservableProperty] private Visibility _visibilityPkw34;
    [ObservableProperty] private Visibility _visibilityPkw35;
    [ObservableProperty] private Visibility _visibilityPkw36;
    [ObservableProperty] private Visibility _visibilityPkw37;


    [ObservableProperty] private string _stringFreieParkplaetze;
    [ObservableProperty] private string _stringFreieParkplaetzeSoll;




}