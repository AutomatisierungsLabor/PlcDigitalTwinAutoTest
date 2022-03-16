using System.Collections.ObjectModel;
using LibDatenstruktur;

namespace DtNadeltelegraph.Model;

public class ModelNadeltelegraph : BasePlcDtAt.BaseModel.BaseModel
{
    public byte Zeichen { get; set; }
    public bool P0 { get; set; }
    public bool P1L { get; set; }
    public bool P1R { get; set; }
    public bool P2L { get; set; }
    public bool P2R { get; set; }
    public bool P3L { get; set; }
    public bool P3R { get; set; }
    public bool P4L { get; set; }
    public bool P4R { get; set; }
    public bool P5L { get; set; }
    public bool P5R { get; set; }

    public ObservableCollection<Zeiger> AlleZeiger = new();

    private readonly DatenRangieren _datenRangieren;

    public ModelNadeltelegraph(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        Zeichen = 32;
        for (var i = 0; i < 10; i++) AlleZeiger.Add(new Zeiger());
    }
    protected override void ModelThread() => _datenRangieren?.Rangieren();
}