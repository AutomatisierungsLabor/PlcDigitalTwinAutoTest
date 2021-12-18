using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Windows.Controls.Grid;

namespace LibWpf
{
    public class LibBilder
    {


        public static void BildViz(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string binding, DependencyProperty visibilityProperty, Grid grid)
        {



            var image = new Image()
            {
                Source = new BitmapImage(new Uri(@source, UriKind.Relative)),
                Stretch = Stretch.Fill,
                Margin = margin
            };

            image.SetBinding(visibilityProperty, new Binding(binding));

            SetColumn(image, xPos);
            SetColumnSpan(image, xSpan);
            SetRow(image, yPos);
            SetRowSpan(image, ySpan);

            grid.Children.Add(image);
        }


    }
}
