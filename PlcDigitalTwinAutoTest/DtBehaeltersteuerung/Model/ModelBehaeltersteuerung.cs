using System.Collections.Generic;
using System.Collections.ObjectModel;
using LibDatenstruktur;

namespace DtBehaeltersteuerung.Model;

public class ModelBehaeltersteuerung : BasePlcDtAt.BaseModel.BaseModel
{
    public bool P1 { get; set; }
    public ObservableCollection<Permutation> PermutationList { get; set; }
    public List<Behaelter> AlleMeineBehaelter { get; set; }
    public string AktivePermutation { get; set; }


    private bool _automatikModusAktiv;

    private readonly DatenRangieren _datenRangieren;

    public ModelBehaeltersteuerung(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        var johnsonTrotter = new JohnsonTrotter(4);
        PermutationList = johnsonTrotter.GetPermutations();
        AlleMeineBehaelter = new List<Behaelter> { new(0.2), new(0.4), new(0.6), new(0.8) };
        _datenRangieren = new DatenRangieren(this, datenstruktur);
    }
    protected override void ModelSetValues() { }
    protected override void ModelThread()
    {
        if (AlleMeineBehaelter == null) return;
        var automatikModusNochAktiv = false;

        foreach (var behaelter in AlleMeineBehaelter)
        {
            behaelter.PegelUeberwachen();
            if (behaelter.AutomatikModusAktiv()) automatikModusNochAktiv = true;
        }
        if (!automatikModusNochAktiv) _automatikModusAktiv = false;

        _datenRangieren?.Rangieren();
    }
    internal void AutomatikStarten()
    {
        _automatikModusAktiv = true;
        EndleerreihenfolgeZuordnen(AktivePermutation[0], 1.2);
        EndleerreihenfolgeZuordnen(AktivePermutation[1], 2.4);
        EndleerreihenfolgeZuordnen(AktivePermutation[2], 3.6);
        EndleerreihenfolgeZuordnen(AktivePermutation[3], 4.8);
    }
    private void EndleerreihenfolgeZuordnen(char behaelter, double menge)
    {
        var b = behaelter - '1';
        AlleMeineBehaelter[b].AutomatikmodusStarten(menge);
    }
    public bool AutomatikModusAktiv() => _automatikModusAktiv;
}