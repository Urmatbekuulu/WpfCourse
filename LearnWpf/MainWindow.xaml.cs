using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ResearchWindow ResearchWindow { get; set; }
        public MainWindow() {
            InitializeComponent();
            InitializeTreeView();
            if (ResearchWindow != null) ResearchWindow.ElementHovered += ElementHoveredHandler;
        } 
        private void InitializeTreeView() {
            ResearchWindow = new ResearchWindow();
            ResearchWindow.Show();
            
            var newTreeViewItem = NewTreeViewItem(ResearchWindow);
            treeView.Items.Add(newTreeViewItem);
            
            FillTreeView(VisualTreeHelper.GetChild(ResearchWindow,0),(TreeViewItem)treeView.Items[0]);
        }
        private void FillTreeView(DependencyObject? element,TreeViewItem? itemCollection) {
           
            if(element is null || itemCollection is null) return;
            
            var newTreeViewItem = NewTreeViewItem(element);
            itemCollection.Items.Add(newTreeViewItem);
            var items = itemCollection.Items.GetItemAt(itemCollection.Items.Count - 1);
            
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element);i++) {
                FillTreeView(VisualTreeHelper.GetChild(element,i),(TreeViewItem)items);
            }
        }
        private void ElementHoveredHandler(object sender,MouseEventArgs e) {
            if(!Keyboard.IsKeyDown(Key.LeftCtrl) || !Keyboard.IsKeyDown(Key.LeftShift)) return;
            
            var originalSource = (e.OriginalSource as DependencyObject);
            if (originalSource is null) return; 
            
            FindAndSelectOriginalSource(treeView.Items[0] as TreeViewItem,originalSource);
        }
        private void FindAndSelectOriginalSource(TreeViewItem? item,DependencyObject originalSource) {
           if(item is null) return;
           item.IsExpanded = true;
           
           if (item.Tag.Equals(originalSource)) {
               item.Focus();
               item.IsSelected = true;
               return;
           }
           
           foreach (var element in item.Items) {
               FindAndSelectOriginalSource(element as TreeViewItem,originalSource);
           }
        }
        private TreeViewItem NewTreeViewItem(DependencyObject? element) {
            var name = (element as FrameworkElement)?.Name;
            return new TreeViewItem() {
                Header = $"Node type is {element?.GetType()} " +
                         $"{(string.IsNullOrEmpty(name) ? "" : ": Node name is " + name)}",
                Tag = element
            };
        }
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            ResearchWindow.Close();
        }
    }
}
