using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //task1
            Binding binding = new Binding(nameof(textBox.Text));
            binding.Source = textBox;
            textBlcok.SetBinding(TextBlock.TextProperty,binding);

            Binding editableBinding = new Binding(nameof(checkBox.IsChecked)) {
                Source = checkBox,
            };
            textBox.SetBinding(TextBoxBase.IsReadOnlyProperty, editableBinding);
            //task2
            Binding selfBinding = new Binding(nameof(border.Width));
            selfBinding.RelativeSource = RelativeSource.Self;
            border.SetBinding(Border.HeightProperty, selfBinding);
            //task3
            Binding titleBinding = new Binding(nameof(titleEditor.Text));
            titleBinding.Source = titleEditor;
            this.SetBinding(Window.TitleProperty, titleBinding);

        }
    }
}