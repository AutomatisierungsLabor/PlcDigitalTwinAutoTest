using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BasePlcDtAt
{
  public partial class BaseUserControl
    {
        internal void ErrorAnzeigeZeichnen(Grid grid)
        {

            var label = new Label
            {
                FontSize = 46,
                Foreground = Brushes.Red,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "ein label"
            };
            
            grid.Children.Add(label);
        }

    }
}
