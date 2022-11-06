using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace LearnXAML.Themes.Converters; 

public class CellColorConverter :IValueConverter{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        var defaultCellColor = Colors.Black;
        switch (parameter) {
            case "Green": return (Color)value == Colors.Green ? value : defaultCellColor;
            case "Yellow": return (Color)value == Colors.Yellow ? value : defaultCellColor;
            case "Red": return (Color)value == Colors.Red ? value : defaultCellColor;
            default: return defaultCellColor;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}