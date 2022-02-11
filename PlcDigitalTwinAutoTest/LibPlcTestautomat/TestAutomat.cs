using Contracts;
using LibDatenstruktur;
using SoftCircuits.Silk;
using System.Diagnostics;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    private readonly Datenstruktur _datenstruktur;
    private readonly Stopwatch _stopwatch;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private Action<DataGridZeile> _cbUpdateDataGrid;

    private short _zeilenNummerDataGrid;
    private short _anzahlBitEingaenge = 16;
    private short _anzahlBitAusgaenge = 16;

    public TestAutomat(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _cancellationTokenSource = cancellationTokenSource;
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }

    public void SetCallbackDatagridUpdaten(Action<DataGridZeile> callBack) => _cbUpdateDataGrid = callBack;
    public void SetDiagrammZeitbereich(FunctionEventArgs args) => _datenstruktur.DiagrammZeitbereich = args.Parameters[0].ToInteger();
    public void SetDataGridBitAnzahl()
    {
        _anzahlBitEingaenge = 16;   // e.Parameters[0].ToInteger();
        _anzahlBitAusgaenge = 16;   // e.Parameters[1].ToInteger();
    }
    public short GetAnzahlBitAusgaenge() => _anzahlBitAusgaenge;
    public short GetAnzahlBitEingaenge() => _anzahlBitEingaenge;
    public void SetReferenzen(short zeilenNummerDataGrid) => _zeilenNummerDataGrid = zeilenNummerDataGrid;
}