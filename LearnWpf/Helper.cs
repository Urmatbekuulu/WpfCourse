using System.Windows;

namespace LearnXAML;

public class Helper {
    
    public static readonly DependencyProperty ParentDataContextProperty = DependencyProperty.RegisterAttached(
        "ParentDataContext", 
        typeof(MainViewModel)
        ,typeof(Helper)
        , new FrameworkPropertyMetadata(
        defaultValue: default(MainViewModel),
        flags: FrameworkPropertyMetadataOptions.Inherits));
    public static MainViewModel GetParentDataContext(UIElement element) {
        return (MainViewModel)element.GetValue(ParentDataContextProperty);
    }

    public static void SetParentDataContext(UIElement element, MainViewModel value) {
        element.SetValue(ParentDataContextProperty, value);
    }
}

