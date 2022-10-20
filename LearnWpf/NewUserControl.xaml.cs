using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace LearnXAML; 

public partial class NewUserControl : UserControl {
    public NewUserControl() {
        InitializeComponent();
    }

    private void UIElement_OnMouseEnter(object sender, MouseEventArgs e) {
        var popup = e.Source as Popup;
        popup.IsOpen = false;
    }

    private void UIElement_OnMouseLeave(object sender, MouseEventArgs e) {
        var pupup = e.Source as Popup;
        pupup.IsOpen = false;
    }
}