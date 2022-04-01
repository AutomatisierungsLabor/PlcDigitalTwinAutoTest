﻿using System.Diagnostics;
using System.Windows;
using LibDatenstruktur;

namespace DtLap2018_3_Hydraulikaggregat.Model;

public class ModelLap2018 : BasePlcDtAt.BaseModel.BaseModel
{
    public bool B1 { get; set; }    // Sensor Ölstand
    public bool B2 { get; set; }    // Sensor Druck erreicht
    public bool B3 { get; set; }    // Sensor Überdruck (Öffner)
    public bool B4 { get; set; }    // Temperatur Ölbehälter (Öffner)
    public bool B5 { get; set; }    // Druckschalter "Ölfilter" (Öffner) 
    public bool F1 { get; set; }    // Motorstörung (Öffner)
    public bool K1 { get; set; }    // Ventil "Zylinder ausfahren"  
    public bool K2 { get; set; }    // Ventil "Zylinder einfahren" 
    public bool P1 { get; set; }    // Meldeleuchte "Betriebsbereit" 
    public bool P2 { get; set; }    // Meldeleuchte "Sammelstörung" 
    public bool P3 { get; set; }    // Meldeleuchte Störung Motor
    public bool P4 { get; set; }    // Meldeleuchte Überdruck
    public bool P5 { get; set; }    // Meldeleuchte Druck erreicht
    public bool P6 { get; set; }    // Meldeleuchte Ölstand min.
    public bool P7 { get; set; }    // Meldeleuchte "Lüfter Ölkühler"  
    public bool P8 { get; set; }    // Meldeleuchte "Ölfilter wechseln" 
    public bool Q1 { get; set; }    // Netzschütz
    public bool Q2 { get; set; }    // Sternschütz
    public bool Q3 { get; set; }    // Dreieckschütz
    public bool Q4 { get; set; }    // Lüfter(Ölkühler)
    public bool S1 { get; set; }    // Taster Start
    public bool S2 { get; set; }    // Taster Stop
    public bool S3 { get; set; }    // Taster Quittieren
    public bool S4 { get; set; }    // Taster "Zylinder"  

    public double Druck { get; set; }
    public double Pegel { get; set; }
    public Stopwatch Stopwatch { get; set; }

    private const double DruckVerlust = 0.998;
    private const double DruckAnstiegDreieck = 0.03;
    private const double DruckAnstiegStern = 0.01;
    private const double PegelVerlust = 0.999;

    private const double DruckMin = 7;
    private const double DruckMax = 8;
    private const double PegelMin = 0.25;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2018(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        Druck = 0;
        Pegel = 0.8;
        B3 = true;
        B4 = true;
        B5 = true;
        F1 = true;
        S2 = true;

        Stopwatch = new Stopwatch();
        Stopwatch.Restart();
    }
    protected override void ModelThread()
    {

        if (Q1 && Q2) Druck += DruckAnstiegStern;
        if (Q1 && Q3) Druck += DruckAnstiegDreieck;
        Druck *= DruckVerlust;

        if (Druck > 10) Druck = 10;

        if (B2)
        {
            if (Druck < DruckMin) B2 = false;
        }
        else
        {
            if (Druck > DruckMax) B2 = true;
        }

        if (Druck > DruckMin) Pegel *= PegelVerlust;
        B1 = Pegel > PegelMin;

       



        _datenRangieren?.Rangieren();
    }

}