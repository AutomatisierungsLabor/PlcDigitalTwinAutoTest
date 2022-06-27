using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.ViewModel;

public partial class VmPlc
{
    public VmDatenpunkte[] DaCollection { get; set; } = new VmDatenpunkte[50];
    public VmDatenpunkte[] DiCollection { get; set; } = new VmDatenpunkte[50];

    private void AlleDpInitialisieren()
    {
        for (var i = 0; i < 50; i++)
        {
            DaCollection[i] = new VmDatenpunkte(Brushes.Black, "", "", Visibility.Collapsed);
            DiCollection[i] = new VmDatenpunkte(Brushes.Black, "", "", Visibility.Collapsed);
        }
    }
    private void AlleDpAktualisieren()
    {
        (BrushDa00, StringBezeichnungDa00, StringKommentarDa00, VisibilityDa00) = DaCollection[0].GetDatenpunkt();
        (BrushDa01, StringBezeichnungDa01, StringKommentarDa01, VisibilityDa01) = DaCollection[1].GetDatenpunkt();
        (BrushDa02, StringBezeichnungDa02, StringKommentarDa02, VisibilityDa02) = DaCollection[2].GetDatenpunkt();
        (BrushDa03, StringBezeichnungDa03, StringKommentarDa03, VisibilityDa03) = DaCollection[3].GetDatenpunkt();
        (BrushDa04, StringBezeichnungDa04, StringKommentarDa04, VisibilityDa04) = DaCollection[4].GetDatenpunkt();
        (BrushDa05, StringBezeichnungDa05, StringKommentarDa05, VisibilityDa05) = DaCollection[5].GetDatenpunkt();
        (BrushDa06, StringBezeichnungDa06, StringKommentarDa06, VisibilityDa06) = DaCollection[6].GetDatenpunkt();
        (BrushDa07, StringBezeichnungDa07, StringKommentarDa07, VisibilityDa07) = DaCollection[7].GetDatenpunkt();
        (BrushDa10, StringBezeichnungDa10, StringKommentarDa10, VisibilityDa10) = DaCollection[10].GetDatenpunkt();
        (BrushDa11, StringBezeichnungDa11, StringKommentarDa11, VisibilityDa11) = DaCollection[11].GetDatenpunkt();
        (BrushDa12, StringBezeichnungDa12, StringKommentarDa12, VisibilityDa12) = DaCollection[12].GetDatenpunkt();
        (BrushDa13, StringBezeichnungDa13, StringKommentarDa13, VisibilityDa13) = DaCollection[13].GetDatenpunkt();
        (BrushDa14, StringBezeichnungDa14, StringKommentarDa14, VisibilityDa14) = DaCollection[14].GetDatenpunkt();
        (BrushDa15, StringBezeichnungDa15, StringKommentarDa15, VisibilityDa15) = DaCollection[15].GetDatenpunkt();
        (BrushDa16, StringBezeichnungDa16, StringKommentarDa16, VisibilityDa16) = DaCollection[16].GetDatenpunkt();
        (BrushDa17, StringBezeichnungDa17, StringKommentarDa17, VisibilityDa17) = DaCollection[17].GetDatenpunkt();
        (BrushDa20, StringBezeichnungDa20, StringKommentarDa20, VisibilityDa20) = DaCollection[20].GetDatenpunkt();
        (BrushDa21, StringBezeichnungDa21, StringKommentarDa21, VisibilityDa21) = DaCollection[21].GetDatenpunkt();
        (BrushDa22, StringBezeichnungDa22, StringKommentarDa22, VisibilityDa22) = DaCollection[22].GetDatenpunkt();
        (BrushDa23, StringBezeichnungDa23, StringKommentarDa23, VisibilityDa23) = DaCollection[23].GetDatenpunkt();
        (BrushDa24, StringBezeichnungDa24, StringKommentarDa24, VisibilityDa24) = DaCollection[24].GetDatenpunkt();
        (BrushDa25, StringBezeichnungDa25, StringKommentarDa25, VisibilityDa25) = DaCollection[25].GetDatenpunkt();
        (BrushDa26, StringBezeichnungDa26, StringKommentarDa26, VisibilityDa26) = DaCollection[26].GetDatenpunkt();
        (BrushDa27, StringBezeichnungDa27, StringKommentarDa27, VisibilityDa27) = DaCollection[27].GetDatenpunkt();
        (BrushDa30, StringBezeichnungDa30, StringKommentarDa30, VisibilityDa30) = DaCollection[30].GetDatenpunkt();
        (BrushDa31, StringBezeichnungDa31, StringKommentarDa31, VisibilityDa31) = DaCollection[31].GetDatenpunkt();
        (BrushDa32, StringBezeichnungDa32, StringKommentarDa32, VisibilityDa32) = DaCollection[32].GetDatenpunkt();
        (BrushDa33, StringBezeichnungDa33, StringKommentarDa33, VisibilityDa33) = DaCollection[33].GetDatenpunkt();
        (BrushDa34, StringBezeichnungDa34, StringKommentarDa34, VisibilityDa34) = DaCollection[34].GetDatenpunkt();
        (BrushDa35, StringBezeichnungDa35, StringKommentarDa35, VisibilityDa35) = DaCollection[35].GetDatenpunkt();
        (BrushDa36, StringBezeichnungDa36, StringKommentarDa36, VisibilityDa36) = DaCollection[36].GetDatenpunkt();
        (BrushDa37, StringBezeichnungDa37, StringKommentarDa37, VisibilityDa37) = DaCollection[37].GetDatenpunkt();
        (BrushDa40, StringBezeichnungDa40, StringKommentarDa40, VisibilityDa40) = DaCollection[40].GetDatenpunkt();
        (BrushDa41, StringBezeichnungDa41, StringKommentarDa41, VisibilityDa41) = DaCollection[41].GetDatenpunkt();
        (BrushDa42, StringBezeichnungDa42, StringKommentarDa42, VisibilityDa42) = DaCollection[42].GetDatenpunkt();
        (BrushDa43, StringBezeichnungDa43, StringKommentarDa43, VisibilityDa43) = DaCollection[43].GetDatenpunkt();
        (BrushDa44, StringBezeichnungDa44, StringKommentarDa44, VisibilityDa44) = DaCollection[44].GetDatenpunkt();
        (BrushDa45, StringBezeichnungDa45, StringKommentarDa45, VisibilityDa45) = DaCollection[45].GetDatenpunkt();
        (BrushDa46, StringBezeichnungDa46, StringKommentarDa46, VisibilityDa46) = DaCollection[46].GetDatenpunkt();
        (BrushDa47, StringBezeichnungDa47, StringKommentarDa47, VisibilityDa47) = DaCollection[47].GetDatenpunkt();

        (BrushDi00, StringBezeichnungDi00, StringKommentarDi00, VisibilityDi00) = DiCollection[0].GetDatenpunkt();
        (BrushDi01, StringBezeichnungDi01, StringKommentarDi01, VisibilityDi01) = DiCollection[1].GetDatenpunkt();
        (BrushDi02, StringBezeichnungDi02, StringKommentarDi02, VisibilityDi02) = DiCollection[2].GetDatenpunkt();
        (BrushDi03, StringBezeichnungDi03, StringKommentarDi03, VisibilityDi03) = DiCollection[3].GetDatenpunkt();
        (BrushDi04, StringBezeichnungDi04, StringKommentarDi04, VisibilityDi04) = DiCollection[4].GetDatenpunkt();
        (BrushDi05, StringBezeichnungDi05, StringKommentarDi05, VisibilityDi05) = DiCollection[5].GetDatenpunkt();
        (BrushDi06, StringBezeichnungDi06, StringKommentarDi06, VisibilityDi06) = DiCollection[6].GetDatenpunkt();
        (BrushDi07, StringBezeichnungDi07, StringKommentarDi07, VisibilityDi07) = DiCollection[7].GetDatenpunkt();
        (BrushDi10, StringBezeichnungDi10, StringKommentarDi10, VisibilityDi10) = DiCollection[10].GetDatenpunkt();
        (BrushDi11, StringBezeichnungDi11, StringKommentarDi11, VisibilityDi11) = DiCollection[11].GetDatenpunkt();
        (BrushDi12, StringBezeichnungDi12, StringKommentarDi12, VisibilityDi12) = DiCollection[12].GetDatenpunkt();
        (BrushDi13, StringBezeichnungDi13, StringKommentarDi13, VisibilityDi13) = DiCollection[13].GetDatenpunkt();
        (BrushDi14, StringBezeichnungDi14, StringKommentarDi14, VisibilityDi14) = DiCollection[14].GetDatenpunkt();
        (BrushDi15, StringBezeichnungDi15, StringKommentarDi15, VisibilityDi15) = DiCollection[15].GetDatenpunkt();
        (BrushDi16, StringBezeichnungDi16, StringKommentarDi16, VisibilityDi16) = DiCollection[16].GetDatenpunkt();
        (BrushDi17, StringBezeichnungDi17, StringKommentarDi17, VisibilityDi17) = DiCollection[17].GetDatenpunkt();
        (BrushDi20, StringBezeichnungDi20, StringKommentarDi20, VisibilityDi20) = DiCollection[20].GetDatenpunkt();
        (BrushDi21, StringBezeichnungDi21, StringKommentarDi21, VisibilityDi21) = DiCollection[21].GetDatenpunkt();
        (BrushDi22, StringBezeichnungDi22, StringKommentarDi22, VisibilityDi22) = DiCollection[22].GetDatenpunkt();
        (BrushDi23, StringBezeichnungDi23, StringKommentarDi23, VisibilityDi23) = DiCollection[23].GetDatenpunkt();
        (BrushDi24, StringBezeichnungDi24, StringKommentarDi24, VisibilityDi24) = DiCollection[24].GetDatenpunkt();
        (BrushDi25, StringBezeichnungDi25, StringKommentarDi25, VisibilityDi25) = DiCollection[25].GetDatenpunkt();
        (BrushDi26, StringBezeichnungDi26, StringKommentarDi26, VisibilityDi26) = DiCollection[26].GetDatenpunkt();
        (BrushDi27, StringBezeichnungDi27, StringKommentarDi27, VisibilityDi27) = DiCollection[27].GetDatenpunkt();
        (BrushDi30, StringBezeichnungDi30, StringKommentarDi30, VisibilityDi30) = DiCollection[30].GetDatenpunkt();
        (BrushDi31, StringBezeichnungDi31, StringKommentarDi31, VisibilityDi31) = DiCollection[31].GetDatenpunkt();
        (BrushDi32, StringBezeichnungDi32, StringKommentarDi32, VisibilityDi32) = DiCollection[32].GetDatenpunkt();
        (BrushDi33, StringBezeichnungDi33, StringKommentarDi33, VisibilityDi33) = DiCollection[33].GetDatenpunkt();
        (BrushDi34, StringBezeichnungDi34, StringKommentarDi34, VisibilityDi34) = DiCollection[34].GetDatenpunkt();
        (BrushDi35, StringBezeichnungDi35, StringKommentarDi35, VisibilityDi35) = DiCollection[35].GetDatenpunkt();
        (BrushDi36, StringBezeichnungDi36, StringKommentarDi36, VisibilityDi36) = DiCollection[36].GetDatenpunkt();
        (BrushDi37, StringBezeichnungDi37, StringKommentarDi37, VisibilityDi37) = DiCollection[37].GetDatenpunkt();
        (BrushDi40, StringBezeichnungDi30, StringKommentarDi40, VisibilityDi40) = DiCollection[40].GetDatenpunkt();
        (BrushDi41, StringBezeichnungDi31, StringKommentarDi41, VisibilityDi41) = DiCollection[41].GetDatenpunkt();
        (BrushDi42, StringBezeichnungDi32, StringKommentarDi42, VisibilityDi42) = DiCollection[42].GetDatenpunkt();
        (BrushDi43, StringBezeichnungDi33, StringKommentarDi43, VisibilityDi43) = DiCollection[43].GetDatenpunkt();
        (BrushDi44, StringBezeichnungDi34, StringKommentarDi44, VisibilityDi44) = DiCollection[44].GetDatenpunkt();
        (BrushDi45, StringBezeichnungDi35, StringKommentarDi45, VisibilityDi45) = DiCollection[45].GetDatenpunkt();
        (BrushDi46, StringBezeichnungDi36, StringKommentarDi46, VisibilityDi46) = DiCollection[46].GetDatenpunkt();
        (BrushDi47, StringBezeichnungDi37, StringKommentarDi47, VisibilityDi47) = DiCollection[47].GetDatenpunkt();
    }
}
public class VmDatenpunkte
{
    public Brush DpFarbe;
    public string DpBezeichnung;
    public string DpKommentar;
    public Visibility DpVisibility;

    public (Brush farbe, string bezeichnung, string kommentar, Visibility visibility) GetDatenpunkt() => (DpFarbe, DpBezeichnung, DpKommentar, DpVisibility);
    public VmDatenpunkte(Brush farbe, string stringBezeichnung, string stringKommentar, Visibility visibility)
    {
        DpFarbe = farbe;
        DpBezeichnung = stringBezeichnung;
        DpKommentar = stringKommentar;
        DpVisibility = visibility;
    }
}