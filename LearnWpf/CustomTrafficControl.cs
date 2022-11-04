using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Color = System.Drawing.Color;

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
            Color.FromKnownColor(KnownColor.Red)
            ,Color.FromKnownColor(KnownColor.Yellow)
            ,Color.FromKnownColor(KnownColor.Green)
            ,Color.FromKnownColor(KnownColor.Yellow)
        };
        private int _currentColorIndex = 0;
        
        static CustomTrafficControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTrafficControl), new FrameworkPropertyMetadata(typeof(CustomTrafficControl)));
        }
       
        protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0,0,3);
            _dispatcherTimer.Start();
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            ChangeColorOfTraffic();
        }

        public static readonly DependencyProperty TrafficColorProperty = DependencyProperty.Register(
            nameof(TrafficColor), typeof(Color), typeof(CustomTrafficControl), new PropertyMetadata( Color.FromKnownColor(KnownColor.Red)));

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
            _currentColorIndex++;
            if (_currentColorIndex == _colorsArray.Length) _currentColorIndex = 0;
            TrafficColor = _colorsArray[_currentColorIndex];
            ColorChangedEvent?.Invoke(this,new TrafficEventArgs() {
                OldColor = _colorsArray[_currentColorIndex-1<0?0:_currentColorIndex-1],
                NewColor = _colorsArray[_currentColorIndex]
            });
        }
        public class TrafficEventArgs:EventArgs {
            public Color OldColor { get; set; }
            public Color NewColor { get; set; }
            
        }
    }
}
