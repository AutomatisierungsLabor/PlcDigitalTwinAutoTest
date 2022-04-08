using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace LibWpf;

public static class Extensions
{

    public static void BindingButtonSetContent(this Button element, object wpfId) => element.SetBinding(ContentControl.ContentProperty, $"{wpfId}");
    public static void BindingButtonSetClickMode(this Button element, object wpfId) => element.SetBinding(ButtonBase.ClickModeProperty, $"{wpfId}");
    public static void BindingButtonSetVisibility(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.VisibilityProperty, $"{wpfId}");
    public static void BindingButtonSetBackground(this FrameworkElement element, object wpfId) => element.SetBinding(Control.BackgroundProperty, $"{wpfId}");


    public static void BindingSetFilling(this Shape element, object wpfId) => element.SetBinding(Shape.FillProperty, $"{wpfId}");


    public static void BindingImageSetVisibility(this FrameworkElement element, object wpfObject) => element.SetBinding(UIElement.VisibilityProperty, $"{wpfObject}");
   


    public static void BindingSetMargin(this Shape element, object wpfId) => element.SetBinding(FrameworkElement.MarginProperty, $"{wpfId}");


    public static void BindingSetVisibility(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.VisibilityProperty, $"{wpfId}");


    public static void BindingImageSetMargin(this FrameworkElement element, object wpfId) => element.SetBinding(FrameworkElement.MarginProperty, $"{wpfId}");

    public static void BindingSetContent(this ContentControl element, object wpfId) => element.SetBinding(ContentControl.ContentProperty, $"{wpfId}");

    public static void BindingpSetTransformOrigin(this Shape element, object wpfId) => element.SetBinding(UIElement.RenderTransformOriginProperty, $"{wpfId}");





    public static void RipSetBtnContentBinding(this Button element, object wpfId) => element.SetBinding(ContentControl.ContentProperty, $"Text[{(int)wpfId}]");
    public static void RipSetBtnBackgroundBinding(this Button element, object wpfId) => element.SetBinding(Control.BackgroundProperty, $"Farbe[{(int)wpfId}]");
    public static void RipSetContentBinding(this ContentControl element, object wpfId) => element.SetBinding(ContentControl.ContentProperty, $"Text[{(int)wpfId}]");
    public static void RipSetBtnClickModeBinding(this Button element, object wpfId) => element.SetBinding(ButtonBase.ClickModeProperty, $"ClkMode[{(int)wpfId}]");
    public static void RipButtonSetVisibilityEinBinding(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.VisibilityProperty, $"SichtbarEin[{(int)wpfId}]");
    public static void RipSetVisibilityAusBinding(this FrameworkElement element, object wpfId) => element.SetBinding(UIElement.VisibilityProperty, $"SichtbarAus[{(int)wpfId}]");
    public static void RipSetTextBlockBinding(this TextBlock element, object wpfId) => element.SetBinding(TextBlock.TextProperty, $"Text[{(int)wpfId}]");
    public static void RipSetFillingBinding(this Shape element, object wpfId) => element.SetBinding(Shape.FillProperty, $"Farbe[{(int)wpfId}]");
    public static void RipSetMarginBinding(this Shape element, object wpfId) => element.SetBinding(FrameworkElement.MarginProperty, $"Margin[{(int)wpfId}]");
    public static void RipSetTransformOriginBinding(this Shape element, object wpfId) => element.SetBinding(UIElement.RenderTransformOriginProperty, $"TransformOrigin[{(int)wpfId}]");
}