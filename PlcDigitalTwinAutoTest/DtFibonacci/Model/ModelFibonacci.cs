﻿using LibDatenstruktur;

namespace DtFibonacci.Model;

public class ModelFibonacci : BasePlcDtAt.BaseModel.BaseModel
{
    public bool P1 { get; set; }
    public bool S1 { get; set; }

    private readonly DatenRangieren _datenRangieren;

    public ModelFibonacci(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelSetValues() { }
    protected override void ModelThread(double dT) => _datenRangieren?.Rangieren();
}