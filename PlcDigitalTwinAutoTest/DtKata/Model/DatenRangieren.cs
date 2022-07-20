﻿using LibDatenstruktur;

namespace DtKata.Model;

public class DatenRangieren

{
    private readonly ModelKata _kata;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelKata kata, Datenstruktur datenstruktur)
    {
        _kata = kata;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
        switch (_datenstruktur.BetriebsartProjekt)
        {
            case BetriebsartProjekt.LaborPlatte: (_kata.S1, _kata.S2, _kata.S3, _kata.S4, _kata.S5, _kata.S6, _kata.S7, _kata.S8) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0); break;
            case BetriebsartProjekt.Simulation: _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _kata.S1, _kata.S2, _kata.S3, _kata.S4, _kata.S5, _kata.S6, _kata.S7, _kata.S8); break;
        }

        (_kata.P1, _kata.P2, _kata.P3, _kata.P4, _kata.P5, _kata.P6, _kata.P7, _kata.P8) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}