using System.Windows.Controls;
using LibDatenstruktur;

namespace BasePlcDtAt;

public partial class BaseUserControl
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
    public BaseUserControl()
    {
        InitializeComponent();

        Log.Debug("BasePlcDtAt BaseUserControl startet");
    }
    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;
        
        
        /*
        switch (tc.SelectedIndex)
        {
            case 0:    Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.LaborPlatte; break;
            case 1: Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.Simulation; break;
            case 2:Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.AutomatischerSoftwareTest; break;
            default: break;
        }
        */

       // DisplayPlc.SetBetriebsartProjekt(Datenstruktur);
    }
}