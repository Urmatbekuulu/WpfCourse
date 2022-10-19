using System.Collections.Generic;
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
        public DependencyObject? OriginalSource { get; set; }
        public MainWindow() {
            InitializeComponent();
            InitializeTreeView();
            if (ResearchWindow != null) ResearchWindow.ElementHovered += ElementHoveredHandler;
        } 
        private void InitializeTreeView() {
            ResearchWindow = new ResearchWindow();
            ResearchWindow.Show();
            var treeViewItem = CreateNode(ResearchWindow);
            treeView.Items.Add(treeViewItem);
            TreeViewItem viewItem =(TreeViewItem)treeView.Items[0];
            FillTreeView(VisualTreeHelper.GetChild(ResearchWindow,0),viewItem);
        }
        private void FillTreeView(DependencyObject? element,TreeViewItem? itemCollection) {
           
            if(element is null || itemCollection is null) return;
            var treeViewItem = CreateNode(element);
            itemCollection.Items.Add(treeViewItem);
            var item = itemCollection.Items.GetItemAt(itemCollection.Items.Count - 1);
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element);i++) {
                FillTreeView(VisualTreeHelper.GetChild(element,i),(TreeViewItem)item);
            }
        }
        private void ElementHoveredHandler(object sender,MouseEventArgs e) {
            if(!Keyboard.IsKeyDown(Key.LeftCtrl) || !Keyboard.IsKeyDown(Key.LeftShift)) return;
            OriginalSource = (e.OriginalSource as DependencyObject);
            if (OriginalSource is null) return; 
            FindAndSelectOriginalSource(treeView.Items[0] as TreeViewItem);
        }
        private void FindAndSelectOriginalSource(TreeViewItem? item) {
           if(item is null) return;
           item.IsExpanded = true;
           if (item.Tag.Equals(OriginalSource)) {
               item.Focus();
               item.IsSelected = true;
               return;
           }
           foreach (var element in item.Items) {
               FindAndSelectOriginalSource(element as TreeViewItem);
           }
        }
        private TreeViewItem CreateNode(DependencyObject? element) {
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
