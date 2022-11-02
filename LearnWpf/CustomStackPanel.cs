using System.Windows;
using System.Windows.Controls;

namespace LearnXAML; 

public class CustomStackPanel:Panel {
    public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(
        nameof(Offset), typeof(double), typeof(CustomStackPanel), new PropertyMetadata(default(double)));

    public double Offset {
        get { return (double)GetValue(OffsetProperty); }
        set { SetValue(OffsetProperty, value); }
    }   

    public static readonly DependencyProperty IsHorizontalModeProperty = DependencyProperty.Register(
        nameof(IsHorizontalMode), typeof(bool), typeof(CustomStackPanel), new PropertyMetadata(default(bool)));

    public bool IsHorizontalMode {
        get { return (bool)GetValue(IsHorizontalModeProperty); }
        set { SetValue(IsHorizontalModeProperty, value); }
    }
    public CustomStackPanel() : base() {
        
    }

    protected override Size MeasureOverride(Size availableSize) {
        Size panelDesiredSize = new Size();
        foreach (UIElement child in InternalChildren) {
            child.Measure(availableSize);
            panelDesiredSize = child.DesiredSize;
        }
        return panelDesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize) {
        double x=0, y=0;
        foreach (UIElement child in InternalChildren) {
            child.Arrange(new Rect(new Point(x,y),child.DesiredSize));
            if (IsHorizontalMode) {
                x += child.DesiredSize.Width + Offset;
            }
            else {
                y += child.DesiredSize.Height + Offset;
            }
        }
        return finalSize;
    }
}