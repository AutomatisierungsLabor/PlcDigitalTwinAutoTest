using System.Windows.Controls;

namespace BasePlcDtAt;

public partial class BaseUserControl
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    

    public BaseModel.Model Model { get; set; }
    public BaseUserControl()
    {
        InitializeComponent();

        ErrorAnzeigeZeichnen(Grid0);
        ErrorAnzeigeZeichnen(Grid1);
        ErrorAnzeigeZeichnen(Grid2);
        
        Log.Debug("BaseUserControl startet");
    }

    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;
        var index = tc.SelectedIndex;
        BaseModel.Model.BetriebsartUmschalten(index);
    }

}
