using System.Windows;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    public VmDatenpunkte[] DaCollection { get; set; } = new VmDatenpunkte[20];
    public VmDatenpunkte[] DiCollection { get; set; } = new VmDatenpunkte[20];

    private void AlleDpFuellen()
    {
        for (var i = 0; i < 20; i++)
        {
            DaCollection[i] = new VmDatenpunkte("", Visibility.Collapsed);
            DiCollection[i] = new VmDatenpunkte("", Visibility.Collapsed);
        }
    }
    private void AlleDpAktualisieren()
    {
        (StringBezeichnungDa00, VisibilityDa00) = DaCollection[0].GetDatenpunkt();
        (StringBezeichnungDa01, VisibilityDa01) = DaCollection[1].GetDatenpunkt();
        (StringBezeichnungDa02, VisibilityDa02) = DaCollection[2].GetDatenpunkt();
        (StringBezeichnungDa03, VisibilityDa03) = DaCollection[3].GetDatenpunkt();
        (StringBezeichnungDa04, VisibilityDa04) = DaCollection[4].GetDatenpunkt();
        (StringBezeichnungDa05, VisibilityDa05) = DaCollection[5].GetDatenpunkt();
        (StringBezeichnungDa06, VisibilityDa06) = DaCollection[6].GetDatenpunkt();
        (StringBezeichnungDa07, VisibilityDa07) = DaCollection[7].GetDatenpunkt();
        (StringBezeichnungDa10, VisibilityDa10) = DaCollection[10].GetDatenpunkt();
        (StringBezeichnungDa11, VisibilityDa11) = DaCollection[11].GetDatenpunkt();
        (StringBezeichnungDa12, VisibilityDa12) = DaCollection[12].GetDatenpunkt();
        (StringBezeichnungDa13, VisibilityDa13) = DaCollection[13].GetDatenpunkt();
        (StringBezeichnungDa14, VisibilityDa14) = DaCollection[14].GetDatenpunkt();
        (StringBezeichnungDa15, VisibilityDa15) = DaCollection[15].GetDatenpunkt();
        (StringBezeichnungDa16, VisibilityDa16) = DaCollection[16].GetDatenpunkt();
        (StringBezeichnungDa17, VisibilityDa17) = DaCollection[17].GetDatenpunkt();

        (StringBezeichnungDi00, VisibilityDi00) = DiCollection[0].GetDatenpunkt();
        (StringBezeichnungDi01, VisibilityDi01) = DiCollection[1].GetDatenpunkt();
        (StringBezeichnungDi02, VisibilityDi02) = DiCollection[2].GetDatenpunkt();
        (StringBezeichnungDi03, VisibilityDi03) = DiCollection[3].GetDatenpunkt();
        (StringBezeichnungDi04, VisibilityDi04) = DiCollection[4].GetDatenpunkt();
        (StringBezeichnungDi05, VisibilityDi05) = DiCollection[5].GetDatenpunkt();
        (StringBezeichnungDi06, VisibilityDi06) = DiCollection[6].GetDatenpunkt();
        (StringBezeichnungDi07, VisibilityDi07) = DiCollection[7].GetDatenpunkt();
        (StringBezeichnungDi10, VisibilityDi10) = DiCollection[10].GetDatenpunkt();
        (StringBezeichnungDi11, VisibilityDi11) = DiCollection[11].GetDatenpunkt();
        (StringBezeichnungDi12, VisibilityDi12) = DiCollection[12].GetDatenpunkt();
        (StringBezeichnungDi13, VisibilityDi13) = DiCollection[13].GetDatenpunkt();
        (StringBezeichnungDi14, VisibilityDi14) = DiCollection[14].GetDatenpunkt();
        (StringBezeichnungDi15, VisibilityDi15) = DiCollection[15].GetDatenpunkt();
        (StringBezeichnungDi16, VisibilityDi16) = DiCollection[16].GetDatenpunkt();
        (StringBezeichnungDi17, VisibilityDi17) = DiCollection[17].GetDatenpunkt();
    }
}
public class VmDatenpunkte
{
    public string DpBezeichnung;
    public Visibility DpVisibility;

    public (string bezeichnung, Visibility visibility) GetDatenpunkt() => (DpBezeichnung, DpVisibility);
    public VmDatenpunkte(string stringBezeichnung, Visibility visibility)
    {
        DpBezeichnung = stringBezeichnung;
        DpVisibility = visibility;
    }
}