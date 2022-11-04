using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LearnXAML;

public class Cell : Control {
    
    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
        nameof(Image), typeof(ImageSource), typeof(Cell), new PropertyMetadata(default(ImageSource)));
    public ImageSource Image {
        get { return (ImageSource)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }
    
    static Cell()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Cell), new FrameworkPropertyMetadata(typeof(Cell)));
    }
}