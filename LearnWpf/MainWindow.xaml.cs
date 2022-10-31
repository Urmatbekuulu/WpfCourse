using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public PropertyDescriptor PropertyDescriptor { get; set; }
        public string TestString {
            get { return (string)GetValue(TestStringProperty); }
            set { SetValue(TestStringProperty, value); }
        }
        public static readonly DependencyProperty TestStringProperty = DependencyProperty.Register(
            nameof(TestString), typeof(string)
            , typeof(MainWindow),
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: default(string),
                flags: FrameworkPropertyMetadataOptions.AffectsMeasure
                ,propertyChangedCallback:new PropertyChangedCallback(OnTestStringChanged)
                ,coerceValueCallback:new CoerceValueCallback(CoerceStringTesting)
                
            )
        );
        public int MaxLength {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value);}
        }
        
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
            name: nameof(MaxLength)
            ,propertyType: typeof(int)
            ,ownerType: typeof(MainWindow)
            , typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: default(int),
                flags: FrameworkPropertyMetadataOptions.AffectsMeasure),
            validateValueCallback: new ValidateValueCallback(IsValidMaxLength));
        
        public MainWindow() {
            
            InitializeComponent();
            
            PropertyDescriptor =
                DependencyPropertyDescriptor.FromProperty(ToggleButton.IsCheckedProperty, typeof(ToggleButton));
            PropertyDescriptor.AddValueChanged(toggleButton, OnIsCheckedPropertyChanged);
        }
       
        public EventHandler OnIsCheckedPropertyChanged = (object source,EventArgs args) => {
            var toggleButSource = source as ToggleButton;
            MessageBox.Show($"{(toggleButSource.IsChecked.Value?"The button's state is pressed" :"The toggle button's state is normal")}");
        };

        private static void OnTestStringChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args) {
            dependencyObject.CoerceValue(TestStringProperty);
        }
        private static object CoerceStringTesting(DependencyObject depObj, object value) {
            MainWindow mainWindow = (MainWindow)depObj;
            string currentString = (string)value;
            if (mainWindow.MaxLength == 0)
                return currentString;
            if (mainWindow.MaxLength < currentString.Length)
                return mainWindow.TestString.Substring(0,mainWindow.MaxLength);
            return currentString;
        }
        public static bool IsValidMaxLength(object value) {
            return (int)value >= 0;
        }
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            PropertyDescriptor.RemoveValueChanged(toggleButton, OnIsCheckedPropertyChanged);
        }
        
    }
}