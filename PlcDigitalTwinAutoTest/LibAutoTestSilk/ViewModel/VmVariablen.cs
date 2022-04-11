using System.Collections.ObjectModel;
using System.Windows;
using Contracts;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{

    [ObservableProperty] private ObservableCollection<DataGridZeile> _dataGridZeilen = new();
    [ObservableProperty] private short _zeilenNummerDataGrid;
    [ObservableProperty] private string _stringSourceCode;

    [ObservableProperty] private Visibility _visibilityDa00;
    [ObservableProperty] private Visibility _visibilityDa01;
    [ObservableProperty] private Visibility _visibilityDa02;
    [ObservableProperty] private Visibility _visibilityDa03;
    [ObservableProperty] private Visibility _visibilityDa04;
    [ObservableProperty] private Visibility _visibilityDa05;
    [ObservableProperty] private Visibility _visibilityDa06;
    [ObservableProperty] private Visibility _visibilityDa07;
    [ObservableProperty] private Visibility _visibilityDa10;
    [ObservableProperty] private Visibility _visibilityDa11;
    [ObservableProperty] private Visibility _visibilityDa12;
    [ObservableProperty] private Visibility _visibilityDa13;
    [ObservableProperty] private Visibility _visibilityDa14;
    [ObservableProperty] private Visibility _visibilityDa15;
    [ObservableProperty] private Visibility _visibilityDa16;
    [ObservableProperty] private Visibility _visibilityDa17;

    [ObservableProperty] private string _stringBezeichnungDa00;
    [ObservableProperty] private string _stringBezeichnungDa01;
    [ObservableProperty] private string _stringBezeichnungDa02;
    [ObservableProperty] private string _stringBezeichnungDa03;
    [ObservableProperty] private string _stringBezeichnungDa04;
    [ObservableProperty] private string _stringBezeichnungDa05;
    [ObservableProperty] private string _stringBezeichnungDa06;
    [ObservableProperty] private string _stringBezeichnungDa07;
    [ObservableProperty] private string _stringBezeichnungDa10;
    [ObservableProperty] private string _stringBezeichnungDa11;
    [ObservableProperty] private string _stringBezeichnungDa12;
    [ObservableProperty] private string _stringBezeichnungDa13;
    [ObservableProperty] private string _stringBezeichnungDa14;
    [ObservableProperty] private string _stringBezeichnungDa15;
    [ObservableProperty] private string _stringBezeichnungDa16;
    [ObservableProperty] private string _stringBezeichnungDa17;


    [ObservableProperty] private Visibility _visibilityDi00;
    [ObservableProperty] private Visibility _visibilityDi01;
    [ObservableProperty] private Visibility _visibilityDi02;
    [ObservableProperty] private Visibility _visibilityDi03;
    [ObservableProperty] private Visibility _visibilityDi04;
    [ObservableProperty] private Visibility _visibilityDi05;
    [ObservableProperty] private Visibility _visibilityDi06;
    [ObservableProperty] private Visibility _visibilityDi07;
    [ObservableProperty] private Visibility _visibilityDi10;
    [ObservableProperty] private Visibility _visibilityDi11;
    [ObservableProperty] private Visibility _visibilityDi12;
    [ObservableProperty] private Visibility _visibilityDi13;
    [ObservableProperty] private Visibility _visibilityDi14;
    [ObservableProperty] private Visibility _visibilityDi15;
    [ObservableProperty] private Visibility _visibilityDi16;
    [ObservableProperty] private Visibility _visibilityDi17;

    [ObservableProperty] private string _stringBezeichnungDi00;
    [ObservableProperty] private string _stringBezeichnungDi01;
    [ObservableProperty] private string _stringBezeichnungDi02;
    [ObservableProperty] private string _stringBezeichnungDi03;
    [ObservableProperty] private string _stringBezeichnungDi04;
    [ObservableProperty] private string _stringBezeichnungDi05;
    [ObservableProperty] private string _stringBezeichnungDi06;
    [ObservableProperty] private string _stringBezeichnungDi07;
    [ObservableProperty] private string _stringBezeichnungDi10;
    [ObservableProperty] private string _stringBezeichnungDi11;
    [ObservableProperty] private string _stringBezeichnungDi12;
    [ObservableProperty] private string _stringBezeichnungDi13;
    [ObservableProperty] private string _stringBezeichnungDi14;
    [ObservableProperty] private string _stringBezeichnungDi15;
    [ObservableProperty] private string _stringBezeichnungDi16;
    [ObservableProperty] private string _stringBezeichnungDi17;

}