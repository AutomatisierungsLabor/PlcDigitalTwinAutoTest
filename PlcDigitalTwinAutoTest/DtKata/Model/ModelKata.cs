﻿using LibDatenstruktur;

namespace DtKata.Model;

public class ModelKata : BasePlcDtAt.BaseModel.BaseModel
{
    public bool S1 { get; set; }
    public bool S2 { get; set; }
    public bool S3 { get; set; }
    public bool S4 { get; set; }
    public bool S5 { get; set; }
    public bool S6 { get; set; }
    public bool S7 { get; set; }
    public bool S8 { get; set; }

    public bool P1 { get; set; }
    public bool P2 { get; set; }
    public bool P3 { get; set; }
    public bool P4 { get; set; }
    public bool P5 { get; set; }
    public bool P6 { get; set; }
    public bool P7 { get; set; }
    public bool P8 { get; set; }

    private readonly DatenRangieren _datenRangieren;

    public ModelKata(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelSetValues() {  
        S3 = true;
        S4 = true;
        S7 = true;
        S8 = true;
    }
    protected override void ModelThread(double dT) => _datenRangieren?.Rangieren();
}