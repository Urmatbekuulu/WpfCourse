using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e) {
            //Traverse the VisualTree until finding the parent of the control 
            //that received focus (i.e., the ListBoxItem the control belongs to)
            UIElement ctl = (UIElement)sender;
            DependencyObject parent = VisualTreeHelper.GetParent(ctl);
            while (parent as ListBoxItem == null) {
                parent = VisualTreeHelper.GetParent(parent);
            }
            //Select the ListBoxItem.
            if (parent != null) {
                ListBoxItem lbi = (ListBoxItem)parent;
                if (!lbi.IsSelected) lbi.IsSelected = true; 
            }

        }
        
    }
    public class Person:IDataErrorInfo,INotifyDataErrorInfo,INotifyPropertyChanged {

        private int age;
        private string? lastName;
        public int Age {
            get { return age;}
            set {
                if (value < 0 || value > 100) throw new ArgumentException("Age must be between 0 and 100");
                age = value;
            } }
        public string? FirstName { get; set; }

        public string? LastName {
            get { return lastName;}
            set {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        #region DataErrorInfoReg
        public string Error {
            get;
        }
        public string this[string columnName] {
            get {
                string result = String.Empty;
                if (columnName == nameof(FirstName)) {
                    if (this.FirstName == "" || string.IsNullOrEmpty(this.FirstName)) {
                        result = "Name cannot be empty";
                    }
                }
                return result;
            }
        }
        #endregion

        #region NotifyDataErrorRegion
        public bool HasErrors {
            get
            {
                try
                {
                    var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
                    if (propErrorsCount != null)
                        return true; 
                    else
                        return false;
                }
                catch { }
                return true;
            }
        }
        public IEnumerable GetErrors(string? propertyName) {
            List<string> errors = new List<string>();
            if (propertyName != null)
            {
                propErrors.TryGetValue(propertyName, out errors);
                return errors;
            }
            return null;
            
        }
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Validate();
        }
        private void Validate()
        {
            Task.Run(() => DataValidation());
        }
        private void DataValidation()
        {
            List<string> listErrors;
            if (propErrors.TryGetValue(LastName, out listErrors) == false)
                listErrors = new List<string>();
            else
                listErrors.Clear();

            if (string.IsNullOrEmpty(LastName))
                listErrors.Add("Name should not be empty!!!");
            propErrors[nameof(LastName)] = listErrors;

            if(listErrors.Count>0)
            {
                OnPropertyErrorsChanged(nameof(LastName));
            }
        }
        private void OnPropertyErrorsChanged(string p)
        {
            if (ErrorsChanged != null)
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(p));
        }
   
        #endregion
    }
}