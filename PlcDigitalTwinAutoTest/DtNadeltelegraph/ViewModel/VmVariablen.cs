using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtNadeltelegraph.ViewModel;

public partial class VmNadeltelegraph
{


    [ObservableProperty] private ClickMode _clickModeBuchstabeA;
    [ObservableProperty] private ClickMode _clickModeBuchstabeB;
    [ObservableProperty] private ClickMode _clickModeBuchstabeD;
    [ObservableProperty] private ClickMode _clickModeBuchstabeE;
    [ObservableProperty] private ClickMode _clickModeBuchstabeF;
    [ObservableProperty] private ClickMode _clickModeBuchstabeG;
    [ObservableProperty] private ClickMode _clickModeBuchstabeH;
    [ObservableProperty] private ClickMode _clickModeBuchstabeI;
    [ObservableProperty] private ClickMode _clickModeBuchstabeK;
    [ObservableProperty] private ClickMode _clickModeBuchstabeL;
    [ObservableProperty] private ClickMode _clickModeBuchstabeM;
    [ObservableProperty] private ClickMode _clickModeBuchstabeN;
    [ObservableProperty] private ClickMode _clickModeBuchstabeO;
    [ObservableProperty] private ClickMode _clickModeBuchstabeP;
    [ObservableProperty] private ClickMode _clickModeBuchstabeR;
    [ObservableProperty] private ClickMode _clickModeBuchstabeS;
    [ObservableProperty] private ClickMode _clickModeBuchstabeT;
    [ObservableProperty] private ClickMode _clickModeBuchstabeV;
    [ObservableProperty] private ClickMode _clickModeBuchstabeW;
    [ObservableProperty] private ClickMode _clickModeBuchstabeY;



    [ObservableProperty] private double _winkelZeiger1;
    [ObservableProperty] private double _winkelZeiger2;
    [ObservableProperty] private double _winkelZeiger3;
    [ObservableProperty] private double _winkelZeiger4;
    [ObservableProperty] private double _winkelZeiger5;

    [ObservableProperty] private string _asciiCode;

    [ObservableProperty] private Visibility _visibilityLinieRechtsOben1;
    [ObservableProperty] private Visibility _visibilityLinieRechtsOben2;
    [ObservableProperty] private Visibility _visibilityLinieRechtsOben3;
    [ObservableProperty] private Visibility _visibilityLinieRechtsOben4;

    [ObservableProperty] private Visibility _visibilityLinieRechtsUnten1;
    [ObservableProperty] private Visibility _visibilityLinieRechtsUnten2;
    [ObservableProperty] private Visibility _visibilityLinieRechtsUnten3;
    [ObservableProperty] private Visibility _visibilityLinieRechtsUnten4;

    [ObservableProperty] private Visibility _visibilityLinieLinksOben1;
    [ObservableProperty] private Visibility _visibilityLinieLinksOben2;
    [ObservableProperty] private Visibility _visibilityLinieLinksOben3;
    [ObservableProperty] private Visibility _visibilityLinieLinksOben4;

    [ObservableProperty] private Visibility _visibilityLinieLinksUnten1;
    [ObservableProperty] private Visibility _visibilityLinieLinksUnten2;
    [ObservableProperty] private Visibility _visibilityLinieLinksUnten3;
    [ObservableProperty] private Visibility _visibilityLinieLinksUnten4;

}