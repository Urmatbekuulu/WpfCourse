using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            TrafficControl.ChangeColorOfTraffic();
        }
        private void TrafficControl_OnColorChangedEvent(object? sender, CustomTrafficControl.TrafficEventArgs e) {
            string oldColorName, newColorName;
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(kc);
                if (known==e.OldColor ) oldColorName = known.Name;
                if (known == e.NewColor) newColorName = known.Name;
            }
            MessageBox.Show($"Old color is {e.OldColor}\n New color is {e.NewColor}");
        }
    }
}