using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Windows.Media.Color;


namespace LearnXAML;

public class Cell : Control {

    public static readonly DependencyProperty CurrentColorProperty = DependencyProperty.Register(
        nameof(CurrentColor), typeof(Color), typeof(Cell), new PropertyMetadata(Colors.Black));

    public Color CurrentColor {
        get { return (Color)GetValue(CurrentColorProperty); }
        set { SetValue(CurrentColorProperty, value); }
    }

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