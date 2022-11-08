using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Windows.Media.Color;


namespace LearnXAML.CustomControls;

public class Cell : Control {

    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
        nameof(Image), typeof(ImageSource), typeof(Cell), new PropertyMetadata(default(ImageSource)));

    public ImageSource Image {
        get { return (ImageSource)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }

    static Cell() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Cell), new FrameworkPropertyMetadata(typeof(Cell)));
    }
}