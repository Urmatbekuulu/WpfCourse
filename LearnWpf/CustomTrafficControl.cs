using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Color = System.Windows.Media.Color;

namespace LearnXAML
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:LearnXAML"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:LearnXAML;assembly=LearnXAML"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class CustomTrafficControl : Control {
        
        public event EventHandler<TrafficEventArgs> ColorChangedEvent;
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        
        private Color[] _colorsArray ={
            Colors.Red,Colors.Yellow,Colors.Green,Colors.Yellow
        };
        private int _currentColorIndex = 0;
        
        static CustomTrafficControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTrafficControl), new FrameworkPropertyMetadata(typeof(CustomTrafficControl)));
        }
       protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);
            if(IntervalSecond<=0) return;
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(IntervalSecond);
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Start();
       }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            ChangeColorOfTraffic();
        }

        public static readonly DependencyProperty IntervalSecondProperty = DependencyProperty.Register(
            nameof(IntervalSecond), typeof(int), typeof(CustomTrafficControl), new PropertyMetadata(default(int)));

        public int IntervalSecond {
            get { return (int)GetValue(IntervalSecondProperty); }
            set { SetValue(IntervalSecondProperty, value); }
        }

        public static readonly DependencyProperty IsTwoCellModeProperty = DependencyProperty.Register(
            nameof(IsTwoCellMode), typeof(bool), typeof(CustomTrafficControl), new PropertyMetadata(default(bool)));

        public bool IsTwoCellMode {
            get { return (bool)GetValue(IsTwoCellModeProperty); }
            set { SetValue(IsTwoCellModeProperty, value); }
        }

        public static readonly DependencyProperty TrafficColorProperty = DependencyProperty.Register(
            nameof(TrafficColor), typeof(Color), typeof(CustomTrafficControl), new PropertyMetadata( Colors.Red, new PropertyChangedCallback(TrafficColorChangedCallback)));

        private static void TrafficColorChangedCallback(DependencyObject dpo,DependencyPropertyChangedEventArgs args) {
            var trafficControl = dpo as CustomTrafficControl;
            if(trafficControl is null) return;
            trafficControl.ColorChangedEvent.Invoke(trafficControl,new TrafficEventArgs() {
                NewColor = args.OldValue,
                OldColor = args.NewValue
            });
            
        }
        public Color TrafficColor {
            get { return (Color)GetValue(TrafficColorProperty); }
            set { SetValue(TrafficColorProperty, value); }
        }
        public static readonly DependencyProperty CellStyleProperty = DependencyProperty.Register(
            nameof(CellStyle), typeof(Style), typeof(CustomTrafficControl), new PropertyMetadata(default(Style)));

        public Style CellStyle {
            get { return (Style)GetValue(CellStyleProperty); }
            set { SetValue(CellStyleProperty, value); }
        }

      public void ChangeColorOfTraffic(){
          var step = IsTwoCellMode?2:1;
            _currentColorIndex+=step;
            if (_currentColorIndex == _colorsArray.Length) _currentColorIndex = 0;
            TrafficColor = _colorsArray[_currentColorIndex];
           
        }
        public class TrafficEventArgs:EventArgs {
            public object OldColor { get; set; }
            public object NewColor { get; set; }
            
        }
    }
}
