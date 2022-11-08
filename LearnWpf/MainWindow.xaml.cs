using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using LearnXAML.CustomControls;
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
            
        }
        private void TrafficControl_OnColorChangedEvent(object? sender, CustomTraffic.TrafficEventArgs e) {
            string oldColorName ="", newColorName = "";
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(kc);
                var oldColor = (System.Windows.Media.Color)e.OldColor;
                var newColor = (System.Windows.Media.Color)e.NewColor;
                
                if (known.A==oldColor.A && known.B == oldColor.B && known.G == oldColor.G && known.R == oldColor.R ) oldColorName = known.Name;
                if (known.A==newColor.A && known.B == newColor.B && known.G == newColor.G && known.R == newColor.R) newColorName = known.Name;
            }
            //MessageBox.Show($"Old color is {oldColorName}\n New color is {newColorName}");
        }

       
    }
}