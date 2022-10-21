using System.Collections.ObjectModel;
using System.Windows;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public ObservableCollection<Person> People { get; set; } = new ();
        public MainWindow() {
            InitializeComponent();
            for (int i = 0; i < 100; i++) {
                People.Add(new Person {
                    FirstName = $"FirstName#{i}",
                    LastName = $"LastName#{i}",
                    Age = i
                });
            }

            this.DataContext = this;
        }
    }
    public class Person {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
    }
}