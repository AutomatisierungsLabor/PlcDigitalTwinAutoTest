using System.Windows;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibDisplayPlc.ViewModel;

public partial class VmPlc
{
    public static Brush SetBrush(bool val, Brush farbeTrue, Brush farbeFalse) => val ? farbeTrue : farbeFalse;

    [ObservableProperty] private Brush _brushDa00;
    [ObservableProperty] private Brush _brushDa01;
    [ObservableProperty] private Brush _brushDa02;
    [ObservableProperty] private Brush _brushDa03;
    [ObservableProperty] private Brush _brushDa04;
    [ObservableProperty] private Brush _brushDa05;
    [ObservableProperty] private Brush _brushDa06;
    [ObservableProperty] private Brush _brushDa07;
    [ObservableProperty] private Brush _brushDa10;
    [ObservableProperty] private Brush _brushDa11;
    [ObservableProperty] private Brush _brushDa12;
    [ObservableProperty] private Brush _brushDa13;
    [ObservableProperty] private Brush _brushDa14;
    [ObservableProperty] private Brush _brushDa15;
    [ObservableProperty] private Brush _brushDa16;
    [ObservableProperty] private Brush _brushDa17;

  


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

    [ObservableProperty] private string _stringKommentarDa00;
    [ObservableProperty] private string _stringKommentarDa01;
    [ObservableProperty] private string _stringKommentarDa02;
    [ObservableProperty] private string _stringKommentarDa03;
    [ObservableProperty] private string _stringKommentarDa04;
    [ObservableProperty] private string _stringKommentarDa05;
    [ObservableProperty] private string _stringKommentarDa06;
    [ObservableProperty] private string _stringKommentarDa07;
    [ObservableProperty] private string _stringKommentarDa10;
    [ObservableProperty] private string _stringKommentarDa11;
    [ObservableProperty] private string _stringKommentarDa12;
    [ObservableProperty] private string _stringKommentarDa13;
    [ObservableProperty] private string _stringKommentarDa14;
    [ObservableProperty] private string _stringKommentarDa15;
    [ObservableProperty] private string _stringKommentarDa16;
    [ObservableProperty] private string _stringKommentarDa17;

    [ObservableProperty] private string _stringWertDa0;
    [ObservableProperty] private string _stringWertDa1;


    [ObservableProperty] private Brush _brushDi00;
    [ObservableProperty] private Brush _brushDi01;
    [ObservableProperty] private Brush _brushDi02;
    [ObservableProperty] private Brush _brushDi03;
    [ObservableProperty] private Brush _brushDi04;
    [ObservableProperty] private Brush _brushDi05;
    [ObservableProperty] private Brush _brushDi06;
    [ObservableProperty] private Brush _brushDi07;
    [ObservableProperty] private Brush _brushDi10;
    [ObservableProperty] private Brush _brushDi11;
    [ObservableProperty] private Brush _brushDi12;
    [ObservableProperty] private Brush _brushDi13;
    [ObservableProperty] private Brush _brushDi14;
    [ObservableProperty] private Brush _brushDi15;
    [ObservableProperty] private Brush _brushDi16;
    [ObservableProperty] private Brush _brushDi17;


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

    [ObservableProperty] private string _stringWertAi00;

    [ObservableProperty] private string _stringBezeichnungAi00;
    [ObservableProperty] private string _stringBezeichnungAi01;
    [ObservableProperty] private string _stringBezeichnungAi02;
    [ObservableProperty] private string _stringBezeichnungAi03;
    [ObservableProperty] private string _stringBezeichnungAi04;
    [ObservableProperty] private string _stringBezeichnungAi05;
    [ObservableProperty] private string _stringBezeichnungAi06;
    [ObservableProperty] private string _stringBezeichnungAi07;


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

    [ObservableProperty] private string _stringKommentarDi00;
    [ObservableProperty] private string _stringKommentarDi01;
    [ObservableProperty] private string _stringKommentarDi02;
    [ObservableProperty] private string _stringKommentarDi03;
    [ObservableProperty] private string _stringKommentarDi04;
    [ObservableProperty] private string _stringKommentarDi05;
    [ObservableProperty] private string _stringKommentarDi06;
    [ObservableProperty] private string _stringKommentarDi07;
    [ObservableProperty] private string _stringKommentarDi10;
    [ObservableProperty] private string _stringKommentarDi11;
    [ObservableProperty] private string _stringKommentarDi12;
    [ObservableProperty] private string _stringKommentarDi13;
    [ObservableProperty] private string _stringKommentarDi14;
    [ObservableProperty] private string _stringKommentarDi15;
    [ObservableProperty] private string _stringKommentarDi16;
    [ObservableProperty] private string _stringKommentarDi17;

    [ObservableProperty] private string _stringWertDi0;
    [ObservableProperty] private string _stringWertDi1;
}