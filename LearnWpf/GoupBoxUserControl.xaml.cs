using System.Windows;
using System.Windows.Controls;

namespace LearnXAML; 

public partial class GridBoxUserControl : UserControl {
    public GridBoxUserControl() {
        InitializeComponent();
    }
        
    public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
        nameof(Caption), typeof(object), typeof(GridBoxUserControl), new PropertyMetadata(default(object)));

    public object Caption {
        get { return (object)GetValue(CaptionProperty); }
        set { SetValue(CaptionProperty, value); }
    }
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content), typeof(object), typeof(GridBoxUserControl), new PropertyMetadata(default(object)));

    public object Content {
        get { return (object)GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }
}