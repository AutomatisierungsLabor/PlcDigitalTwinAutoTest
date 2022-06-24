using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace LibSiebenSegmentAnzeige;


public partial class SiebenSegmentAnzeige
{
    private Brush _colorBackground;


    public SiebenSegmentAnzeige()
    {
        InitializeComponent();

    }






    [Description("(Display) ColorBackground"), Category("Segment Display")]
    public Brush ColorBackground
    {
        set
        {
            _colorBackground = value;
            SetValue(ColorBackgroundProperty, _colorBackground);
        }
        get => _colorBackground;
    }
    public static readonly DependencyProperty ColorBackgroundProperty = DependencyProperty.Register("ColorBackground", typeof(SolidColorBrush), typeof(SiebenSegmentAnzeige) ,new PropertyMetadata(OnDisplayChanged));




    [Description("(Display) ShortValue"), Category("Segment Display")]
    public short ShortValue
    {
        get => (short)GetValue(ShortValueProperty);
        set => SetValue(ShortValueProperty, value);
    }

    public static readonly DependencyProperty ShortValueProperty = DependencyProperty.Register("ShortValue", typeof(short), typeof(SiebenSegmentAnzeige) ,new PropertyMetadata(OnDisplayChanged));


    private static void OnDisplayChanged(DependencyObject obj, DependencyPropertyChangedEventArgs arg)
    {
        switch (arg.Property.Name)
        {
            case "ColorBackground": break;
            case "ShortValue": break;
            default:break;
        }

    }
}