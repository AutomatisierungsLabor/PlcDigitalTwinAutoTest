using System;
using System.Globalization;
using System.Windows;

namespace LibAutoTestSilk;

public class WorkItemBackgroundConverter : ResourceDictionary
{
    public object IValueConverter_Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return 7;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int val = (int)value;
        return (int)(val * 0.41);
    }

}