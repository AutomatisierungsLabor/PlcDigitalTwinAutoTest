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

 

    public static void ButtonViz(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, System.Windows.Input.ICommand cmd, object cmdParameter, string bindingClick , DependencyProperty visibilityProperty, Grid grid)
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


    /*
                         <Button Grid.Column="2" Grid.ColumnSpan="2" Grid.Row="17" Grid.RowSpan="2"   Command="{Binding BtnSchalter}" CommandParameter="15" Margin="45,5,0,5">
                        <StackPanel>
                            <Image Source="Bilder/SchiebeSchalterOn.JPG" Visibility="{Binding SichtbarEin[15]}" Height="46" />
                            <Image Source="Bilder/SchiebeSchalterOff.JPG" Visibility="{Binding SichtbarAus[15]}" />
                        </StackPanel>
                    </Button>
     
     */


    public static void ButtonOnOffViz(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize,
        string sourceOn, string bindingOn, string sourceOff, string bindingOff,
        Thickness margin, System.Windows.Input.ICommand cmd, string cmdParameter, string bindingClick , DependencyProperty visibilityProperty, Grid grid)
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