using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Xml;


namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        
        private void ExaminVisalTreeClicked(object sender, RoutedEventArgs e) {
            listBox.Items.Clear(); 
            PrintVisualTree(this.mainWindow);
        }

        private void ExamineLogicalTreeClicked(object sender, RoutedEventArgs e) {
           listBox.Items.Clear();
            PrintLogicalTree(this);
        }
        public void PrintVisualTree(Visual visual)
        {
            listBox.Items.Add(visual.GetType().ToString());
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                PrintVisualTree((Visual)VisualTreeHelper.GetChild(visual, i));
            }
        }
        public void PrintLogicalTree(object logicalTree)
        {
            var control = logicalTree as FrameworkElement;
            if (control == null) return;
            
            listBox.Items.Add(logicalTree.GetType().ToString()) ;
            if(control==listBox) return;
            foreach (var current in LogicalTreeHelper.GetChildren(control)) {
                
                PrintLogicalTree(current);
            } 
        }
        
        private void HideShowPopup(object sender, RoutedEventArgs e) {
            FindPopupAndChangeVisibility(this.mainWindow);
        }

        private void FindPopupAndChangeVisibility(Visual? visual) {
            if(visual is null) return;
            var popup = visual as Popup;
            if (popup is not null) {
                popup.IsOpen = !popup.IsOpen;
                return;
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                FindPopupAndChangeVisibility((Visual)VisualTreeHelper.GetChild(visual, i));
            }
        }
    }
}