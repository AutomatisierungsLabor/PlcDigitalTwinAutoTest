using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibButton
{

    /*
      <Button 
    Grid.Column="3" Grid.Row="4" Grid.RowSpan="2"  
    Content="S1" 
    ClickMode="{Binding ClkMode[11]}" 
    Command="{Binding BtnTaster}" 
    CommandParameter="11" 
    FontSize="20pt" 
    Margin="0,10,0,10"  />
                   
     Schweregrad	Code	Beschreibung	Projekt	Datei	Zeile	Unterdrückungszustand
Fehler	CS0029	Der Typ "string" kann nicht implizit in "System.Windows.Input.ICommand" konvertiert werden.	LibWpf	K:\git\PlcDigitalTwinAutoTest\PlcDigitalTwinAutoTest\LibWpf\LibButton.cs	39	Aktiv

     */

    public static void ButtonViz(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, System.Windows.Input.ICommand cmd, string cmdParameter, string bindingClick , DependencyProperty visibilityProperty, Grid grid)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter,
        };

        
        //button.SetBinding(backgroundProperty, new Binding($"ManVisuAnzeigen.FarbeTastenToggeln{bez} [{ par }]"));
        button.SetBinding(ButtonBase.ClickModeProperty, new Binding(bindingClick));
        //button.SetBinding(visibilityProperty, new Binding($"ManVisuAnzeigen.Visibility{bez} [{ par }]"));
        

        SetColumn(button, xPos);
        SetColumnSpan(button, xSpan);
        SetRow(button, yPos);
        SetRowSpan(button, ySpan);


        grid.Children.Add(button);
    }

}