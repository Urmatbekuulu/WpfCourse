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
        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e) {
           
            if(e.Key==Key.Back || e.Key == Key.Delete) return;
            if (e.Source.Equals(textBox1) && textBox1.Text.Length>=slider.Value 
                || e.Source.Equals(textBox2) && textBox2.Text.Length>=slider.Value) e.Handled = true;
        }
    }
}