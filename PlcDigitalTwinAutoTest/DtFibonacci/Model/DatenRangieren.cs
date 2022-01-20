using LibDatenstruktur;

namespace DtFibonacci.Model;

public class DatenRangieren

{
    private readonly ModelFibonacci _modelFibonacci;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelFibonacci fibonacci, Datenstruktur datenstruktur)
    {
        _modelFibonacci = fibonacci;
        _datenstruktur = datenstruktur;
    }

    public void Rangieren()
    {
        _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelFibonacci.S1);
        (_modelFibonacci.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}