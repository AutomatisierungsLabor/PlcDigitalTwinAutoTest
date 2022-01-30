using System.Collections.ObjectModel;
using LibDatenstruktur;
using LibTestDatensammlung;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    private readonly Datenstruktur _datenstruktur;

    private  short _zeilenNummerDataGrid;
    private short _anzahlBitEingaenge = 16;
    private short _anzahlBitAusgaenge = 16;
    private ObservableCollection<DataGridZeile> _dataGridZeilen;

    public TestAutomat(Datenstruktur datenstruktur)
    {
        _datenstruktur = datenstruktur;

    }

    public void SetDiagrammZeitbereich(FunctionEventArgs e) => _datenstruktur.DiagrammZeitbereich = e.Parameters[0].ToInteger();
    public void SetDataGridBitAnzahl()
    {
        _anzahlBitEingaenge = 16;   // e.Parameters[0].ToInteger();
        _anzahlBitAusgaenge = 16;   // e.Parameters[1].ToInteger();
    }
    public short GetAnzahlBitAusgaenge() => _anzahlBitAusgaenge;
    public short GetAnzahlBitEingaenge() => _anzahlBitEingaenge;
  
    public void SetReferenzen(short zeilenNummerDataGrid, ObservableCollection<DataGridZeile> dataGridZeilen)
    {
        _zeilenNummerDataGrid = zeilenNummerDataGrid;
        _dataGridZeilen=dataGridZeilen;
    }
}