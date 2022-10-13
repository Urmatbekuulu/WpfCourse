using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using static System.Windows.Media.Brushes;
using static System.Windows.Media.Colors;

namespace LearnXAML.CustomConverters; 

public class ForegroundToBackgroundConverter:IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        var foreground = (SolidColorBrush)value;
        var background = new SolidColorBrush(Color.FromRgb(
            (byte)(((int)foreground.Color.R+128)%255)
            ,(byte)(((int)foreground.Color.R+128)%255)
            ,(byte)(((int)foreground.Color.R+128)%255)
            ));
       
        return background;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return null;
    }
}