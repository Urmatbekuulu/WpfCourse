using System.Windows;
using System.Windows.Input;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void UIElement_OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Key != Key.Escape) return;

            checkBox.IsEnabled = !checkBox.IsEnabled;
            button.IsEnabled = !button.IsEnabled;
            textBox.IsEnabled = !textBox.IsEnabled;
        }
        
    }
}