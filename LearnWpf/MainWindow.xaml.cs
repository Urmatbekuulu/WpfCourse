using System.Windows;
using System.Windows.Controls;

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

            var treeViewItem = CreateNode(researchWindow);
            treeView.Items.Add(treeViewItem);
            
            TreeViewItem viewItem =(TreeViewItem)treeView.Items[0];

            foreach (var element in LogicalTreeHelper.GetChildren(researchWindow)) {
                FillTreeView(element as FrameworkElement,viewItem );
            }
        }
        private TreeViewItem? CreateNode(FrameworkElement element) {
            return new TreeViewItem() {
                Header = $"Node type is {element.GetType()} " +
                         $"{(string.IsNullOrEmpty(element.Name) ? "" : ": Node name is " + element.Name)}"
            };
        }
        private void FillTreeView(FrameworkElement? element,TreeViewItem itemCollection) {
           
            if(element is null) return;
            
            var children = LogicalTreeHelper.GetChildren(element);
            var treeViewItem = CreateNode(element);
            itemCollection.Items.Add(treeViewItem);
            var item = itemCollection.Items.GetItemAt(itemCollection.Items.Count - 1);
            foreach (var current in children) {
                FillTreeView(current as FrameworkElement,(TreeViewItem)item);
            }
        }
    }
}