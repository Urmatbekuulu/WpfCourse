using System.Collections.ObjectModel;
using System.Windows;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
    public class MainViewModel {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public MainViewModel() {
            Property1 = nameof(Property1);
            Property2 = nameof(Property2);
            Items = new ObservableCollection<Item>();
            for (int i = 0; i < 100; i++) {
                Items.Add(new Item { Id = i, Name = "Item" + i });
            }
        }
    }
    public class Item {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}