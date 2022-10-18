using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            InitializeTreeView();
        }
        private void InitializeTreeView() {
            
            var researchWindow = new ResearchWindow();
            researchWindow.Show();
            var treeViewItem = CreateNode(researchWindow);
            treeView.Items.Add(treeViewItem);
            TreeViewItem viewItem =(TreeViewItem)treeView.Items[0];
            
            FillTreeView(VisualTreeHelper.GetChild(researchWindow,0),viewItem);
          
        }
        private TreeViewItem? CreateNode(DependencyObject? element) {
            var name = (element as FrameworkElement)?.Name;
            return new TreeViewItem() {
                Header = $"Node type is {element.GetType()} " +
                         $"{(string.IsNullOrEmpty(name) ? "" : ": Node name is " + name)}"
            };
        }
        private void FillTreeView(DependencyObject? element,TreeViewItem itemCollection) {
           
            if(element is null || itemCollection is null) return;
            var treeViewItem = CreateNode(element);
            itemCollection.Items.Add(treeViewItem);
            var item = itemCollection.Items.GetItemAt(itemCollection.Items.Count - 1);
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element);i++) {
                FillTreeView(VisualTreeHelper.GetChild(element,i),(TreeViewItem)item);
            }
        }
    }
}