using System;
using System.Globalization;
using System.Windows.Data;

namespace LearnXAML; 

public class AgeToColorConverter:IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return (int)value%2==0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}