using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace LibWpf;

public static class Extensions
{

    public static void ButtonBindingClickMode(this Button element, string stringBindingElement) => element.SetBinding(ButtonBase.ClickModeProperty, stringBindingElement);
    public static void ButtonBindingContent(this Button element, string stringBindingElement) => element.SetBinding(ContentControl.ContentProperty, stringBindingElement);
    public static void ButtonBindingMargin(this Button element, string stringBindingElement) => element.SetBinding(FrameworkElement.MarginProperty, stringBindingElement);

    public static void ContentControlBindingContent(this ContentControl element, string stringBindingElement) => element.SetBinding(ContentControl.ContentProperty, stringBindingElement);


    public static void FrameworkElementBindingVisibility(this FrameworkElement element, string stringBindingElement) => element.SetBinding(UIElement.VisibilityProperty, stringBindingElement);
    public static void FrameworkElementBindingBackground(this FrameworkElement element, string stringBindingElement) => element.SetBinding(Control.BackgroundProperty, stringBindingElement);
    public static void FrameworkElementBindingMargin(this FrameworkElement element, string stringBindingElement) => element.SetBinding(FrameworkElement.MarginProperty, stringBindingElement);
    public static void FrameworkElementBindingForeground(this FrameworkElement element, string stringBindingElement) => element.SetBinding(Control.ForegroundProperty, stringBindingElement);


    public static void SliderBindingValue(this RangeBase element, string stringBindingElement) => element.SetBinding(RangeBase.ValueProperty, stringBindingElement);

    public static void ShapeBindingTransformOrigin(this Shape element, string stringBindingElement) => element.SetBinding(UIElement.RenderTransformOriginProperty, stringBindingElement);
    public static void ShapeBindingFilling(this Shape element, string stringBindingElement) => element.SetBinding(Shape.FillProperty, stringBindingElement);
    public static void ShapeBindingMargin(this Shape element, string stringBindingElement) => element.SetBinding(FrameworkElement.MarginProperty, stringBindingElement);


    public static void TextBlockBindingText(this TextBlock element, string stringBindingElement) => element.SetBinding(TextBlock.TextProperty, stringBindingElement);
}