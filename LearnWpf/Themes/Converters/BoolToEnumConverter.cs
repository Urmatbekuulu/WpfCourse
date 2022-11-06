using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace LearnXAML.Themes.Converters; 

public class BoolToEnumConverter:IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if ((bool)value) return Visibility.Collapsed;
        return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}