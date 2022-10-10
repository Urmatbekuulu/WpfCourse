using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnXAML {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private int _currentResourcePos;
        private static string _rootPath = "Resources/";
        private string[] _resourceFileNames = new []{"ResourceDictionary1.xaml","ResourceDictionary2.xaml","notvalid file"};

        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e) {
           ChangeToNextValidResource();
        }
        private void ChangeToNextValidResource() {
            for (int nextResourceStep = 1; nextResourceStep <= _resourceFileNames.Length; nextResourceStep++) {
                try {
                    var nextRes = (_currentResourcePos + nextResourceStep) % _resourceFileNames.Length;
                    ChangeToResource(_rootPath+_resourceFileNames[nextRes]);
                    _currentResourcePos = nextRes;
                    break;
                }
                catch{
                    //ignore
                }
            }
        }
        private void ChangeToResource(string resourcePath) {
            ResourceDictionary rd = new ResourceDictionary {
                Source = new Uri(resourcePath,UriKind.RelativeOrAbsolute)
            };
            if (rd is null) throw new Exception("Resource file is not found or not valid");
            
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(rd);
        }
    }
}