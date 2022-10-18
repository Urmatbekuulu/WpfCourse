using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private static bool showPopupInLogicalTree = false;

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
            listBox.Items.Add(visual.GetType().ToString()) ;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                PrintVisualTree((Visual)VisualTreeHelper.GetChild(visual, i));
            }
        }
        public void PrintLogicalTree(object logicalTree)
        {
            var control = logicalTree as FrameworkElement;
            if (control == null || (logicalTree is Popup) && !showPopupInLogicalTree) return;
            
            listBox.Items.Add(logicalTree.GetType().ToString()) ;
            if(control==listBox) return;
            foreach (var current in LogicalTreeHelper.GetChildren(control)) {
                
                PrintLogicalTree(current);
            } 
        }
        
        private void VisibilityControlOfPopup(object sender, RoutedEventArgs e) {
            showPopupInLogicalTree = !showPopupInLogicalTree;
            listBox.Items.Clear();
            PrintLogicalTree(this);
        }
    }
}