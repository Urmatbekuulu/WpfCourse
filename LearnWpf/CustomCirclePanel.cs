using System;
using System.Windows;
using System.Windows.Controls;

namespace LearnXAML; 

public class CustomCirclePanel:Panel {
    public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
        nameof(Radius), typeof(double), typeof(CustomCirclePanel), new PropertyMetadata(default(double)));

    public double Radius {
        get { return (double)GetValue(RadiusProperty); }
        set { SetValue(RadiusProperty, value); }
    }
    public CustomCirclePanel():base() {
        
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
       
        double angle = Math.PI/2,r = Radius;
        double deltaAngle = 2*Math.PI/ InternalChildren.Count;
        double x, y;
        foreach (UIElement child in InternalChildren) {
            y = r - r * Math.Sin(angle);
            x = r + r * Math.Cos(angle);
            angle += deltaAngle;
            child.Arrange(new Rect(new Point(x,y),child.DesiredSize)); 
        }
        return finalSize;
    }
}