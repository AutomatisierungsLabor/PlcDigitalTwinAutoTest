using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace LibWpf;

public static class Extensions
{
    public static void BindingButtonSetContent(this Button element, string stringBindingElement) => element.SetBinding(ContentControl.ContentProperty, stringBindingElement);
    public static void BindingButtonSetClickMode(this Button element, string stringBindingElement) => element.SetBinding(ButtonBase.ClickModeProperty, stringBindingElement);
    public static void BindingButtonSetMargin(this Button element, string stringBindingElement) => element.SetBinding(FrameworkElement.MarginProperty, stringBindingElement);
    public static void BindingButtonSetVisibility(this FrameworkElement element, string stringBindingElement) => element.SetBinding(UIElement.VisibilityProperty, stringBindingElement);
    public static void BindingButtonSetBackground(this FrameworkElement element, string stringBindingElement) => element.SetBinding(Control.BackgroundProperty, stringBindingElement);

    public static void BindingImageSetVisibility(this FrameworkElement element, string stringBindingElement) => element.SetBinding(UIElement.VisibilityProperty, stringBindingElement);
    public static void BindingImageSetMargin(this FrameworkElement element, string stringBindingElement) => element.SetBinding(FrameworkElement.MarginProperty, stringBindingElement);

    public static void BindingTextBlockSetText(this TextBlock element, string stringBindingElement) => element.SetBinding(TextBlock.TextProperty, stringBindingElement);

    public static void BindingSetContent(this ContentControl element, string stringBindingElement) => element.SetBinding(ContentControl.ContentProperty, stringBindingElement);
    public static void BindingSetFilling(this Shape element, string stringBindingElement) => element.SetBinding(Shape.FillProperty, stringBindingElement);
    public static void BindingSetMargin(this Shape element, string stringBindingElement) => element.SetBinding(FrameworkElement.MarginProperty, stringBindingElement);
    public static void BindingSetVisibility(this FrameworkElement element, string stringBindingElement) => element.SetBinding(UIElement.VisibilityProperty, stringBindingElement);
    public static void BindingpSetTransformOrigin(this Shape element, string stringBindingElement) => element.SetBinding(UIElement.RenderTransformOriginProperty, stringBindingElement);
}