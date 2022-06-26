using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Contracts;

namespace LibSiebenSegmentAnzeige;


public partial class SiebenSegmentAnzeige
{
    private Brush _colorBackground;
    private Brush _colorSegment;

    public SiebenSegmentAnzeige() => InitializeComponent();


    [Description("(Display) ColorBackground"), Category("Segment Display")]
    public Brush ColorBackground
    {
        get => _colorBackground;
        set
        {
            _colorBackground = value;
            SetValue(ColorBackgroundProperty, _colorBackground);
        }
    }
    public static readonly DependencyProperty ColorBackgroundProperty = DependencyProperty.Register("ColorBackground", typeof(SolidColorBrush), typeof(SiebenSegmentAnzeige), new PropertyMetadata(OnDisplayChanged));


    [Description("(Display) ColorSegment"), Category("Segment Display")]
    public Brush ColorSegment
    {
        get => _colorBackground;
        set
        {
            _colorSegment = value;
            SetValue(ColorSegmentProperty, _colorSegment);
        }
    }
    public static readonly DependencyProperty ColorSegmentProperty = DependencyProperty.Register("ColorSegment", typeof(SolidColorBrush), typeof(SiebenSegmentAnzeige), new PropertyMetadata(OnDisplayChanged));




    [Description("(Display) ShortBitmusterSegmente"), Category("Segment Display")]
    public short ShortBitmusterSegmente
    {
        get => (short)GetValue(ShortBitmusterSegmenteProperty);
        set => SetValue(ShortBitmusterSegmenteProperty, value);
    }

    public static readonly DependencyProperty ShortBitmusterSegmenteProperty = DependencyProperty.Register("ShortBitmusterSegmente", typeof(short), typeof(SiebenSegmentAnzeige), new PropertyMetadata(OnDisplayChanged));


    private static void OnDisplayChanged(DependencyObject obj, DependencyPropertyChangedEventArgs arg)
    {
        if (obj is not SiebenSegmentAnzeige anzeige) return;

        switch (arg.Property.Name)
        {
            case "ColorBackground":
                if (anzeige.HintergrundRechteck != null) anzeige.HintergrundRechteck.Fill = (Brush)arg.NewValue;
                break;

            case "ColorSegment":
                if (anzeige.SegA != null) anzeige.SegA.Fill = (Brush)arg.NewValue;
                if (anzeige.SegB != null) anzeige.SegB.Fill = (Brush)arg.NewValue;
                if (anzeige.SegC != null) anzeige.SegC.Fill = (Brush)arg.NewValue;
                if (anzeige.SegD != null) anzeige.SegD.Fill = (Brush)arg.NewValue;
                if (anzeige.SegE != null) anzeige.SegE.Fill = (Brush)arg.NewValue;
                if (anzeige.SegF != null) anzeige.SegF.Fill = (Brush)arg.NewValue;
                if (anzeige.SegG != null) anzeige.SegG.Fill = (Brush)arg.NewValue;
                if (anzeige.SegDp != null) anzeige.SegDp.Fill = (Brush)arg.NewValue;
                break;

            case "ShortBitmusterSegmente":
                var wert = (short)arg.NewValue;

                var segmentA = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 0);
                var segmentB = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 1);
                var segmentC = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 2);
                var segmentD = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 3);
                var segmentE = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 4);
                var segmentF = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 5);
                var segmentG = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 6);
                var segmentDp = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 7);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (anzeige.SegA != null) anzeige.SegA.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 0));
                    if (anzeige.SegB != null) anzeige.SegB.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 1));
                    if (anzeige.SegC != null) anzeige.SegC.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 2));
                    if (anzeige.SegD != null) anzeige.SegD.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 3));
                    if (anzeige.SegE != null) anzeige.SegE.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 4));
                    if (anzeige.SegF != null) anzeige.SegF.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 5));
                    if (anzeige.SegG != null) anzeige.SegG.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 6));
                    if (anzeige.SegDp != null) anzeige.SegDp.Visibility = BaseFunctions.SetVisibilityEin(LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 7));
                });
                break;
        }
    }
}