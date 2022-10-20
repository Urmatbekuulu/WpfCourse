using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void UIElement_OnPreviewTextInput (object sender, TextCompositionEventArgs e) {
            var textBlock = e.Source as TextBox;
            if(textBlock is null) return;
            if (textBlock.Text.Length >= slider.Value) e.Handled = true;

        }
    }
}