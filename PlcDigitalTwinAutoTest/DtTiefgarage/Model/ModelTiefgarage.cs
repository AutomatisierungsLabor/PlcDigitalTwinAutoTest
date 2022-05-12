using System.Collections.Generic;
using LibDatenstruktur;

namespace DtTiefgarage.Model;

public class ModelTiefgarage : BasePlcDtAt.BaseModel.BaseModel
{
    public bool B1 { get; set; }
    public bool B2 { get; set; }
    public bool AllesInParkposition { get; set; }
    public int AnzahlAutos { get; set; }
    public int AnzahlPersonen { get; set; }
    public List<FahrzeugPerson> AllePkwPersonen { get; set; }



    private readonly DatenRangieren _datenRangieren;


    public ModelTiefgarage(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {

        AllesInParkposition = true;
        AllePkwPersonen = new List<FahrzeugPerson>
        {
            new(FahrzeugPerson.Rolle.Fahrzeug, AnzahlAutos ++),
            new(FahrzeugPerson.Rolle.Fahrzeug, AnzahlAutos ++),
            new(FahrzeugPerson.Rolle.Fahrzeug, AnzahlAutos ++),
            new(FahrzeugPerson.Rolle.Fahrzeug, AnzahlAutos ++),

            new(FahrzeugPerson.Rolle.Person, AnzahlPersonen ++),
            new(FahrzeugPerson.Rolle.Person, AnzahlPersonen ++),
            new(FahrzeugPerson.Rolle.Person, AnzahlPersonen ++),
            new(FahrzeugPerson.Rolle.Person, AnzahlPersonen ++)
        };

        _datenRangieren = new DatenRangieren(this, datenstruktur);


    }
    protected override void ModelThread()
    {

        B1 = false;
        B2 = false;
        AllesInParkposition = true;

        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (AllesInParkposition != null && AllePkwPersonen.Count > 0)
        {
            foreach (var fp in AllePkwPersonen)
            {
                var (b1, b2, park) = fp.Bewegen();

                B1 |= b1;
                B2 |= b2;
                AllesInParkposition &= park;
            }
        }


        _datenRangieren?.Rangieren();
    }

    internal void DrinnenParken()
    {
        foreach (var fp in AllePkwPersonen) fp.DrinnenParken();
    }
    internal void DraussenParken()
    {
        foreach (var fp in AllePkwPersonen) fp.DraussenParken();
    }
}