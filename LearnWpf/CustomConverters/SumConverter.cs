using System;
using System.Globalization;
using System.Windows.Data;

namespace LearnXAML.CustomConverters; 

public class SumConverter:IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        
        if(!int.TryParse((string)values[0], out int var1)) var1 = 0;
        if(!int.TryParse((string)values[1], out int var2)) var2 = 0;
        
        return (var1+var2).ToString();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}