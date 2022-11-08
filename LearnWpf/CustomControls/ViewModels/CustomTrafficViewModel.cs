using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using LearnXAML.Commands;

namespace LearnXAML.CustomControls.ViewModels; 

public class CustomTrafficViewModel:INotifyPropertyChanged {
    
    public bool IsTwoCellMode { get; set; }
    DispatcherTimer _dispatcherTimer = new DispatcherTimer();

    private Color[] _colorsArray ={
        Colors.Red,Colors.Yellow,Colors.Green,Colors.Yellow
    };

    private int _currentColorIndex;

    public int IntervalSecond {
        set {
            if(value == 0) return;
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(value);
            _dispatcherTimer.Tick += (((sender, args) => ColorChangeCommandExecute()));
            _dispatcherTimer.Start();
        }
    }
    

    private int CurrentColorIndex {
        get { return _currentColorIndex;}
        set {
            _currentColorIndex = value;
            if (value >= _colorsArray.Length) _currentColorIndex = 0;
            SwitchCurrentLight();
            OnPropertyChanged(nameof(TrafficColor));
        } }
    
    public ICommand ChangeColorCommand { get; set; }
    public Color TrafficColor {
        get { return _colorsArray[CurrentColorIndex]; }
    }
    public CustomTrafficViewModel() {
        
        RedCellViewModel = new CellViewModel();
        YellowCellViewModel = new CellViewModel();
        GreenCellViewModel = new CellViewModel();
        CurrentColorIndex = 0;
        ChangeColorCommand = new Command(ColorChangeCommandExecute, CanColorChangeExecute);
    }

    private void SwitchCurrentLight() {
        RedCellViewModel.CellColor = TrafficColor==Colors.Red?TrafficColor:Colors.Black;
        YellowCellViewModel.CellColor = TrafficColor==Colors.Yellow?TrafficColor:Colors.Black;
        GreenCellViewModel.CellColor = TrafficColor==Colors.Green?TrafficColor:Colors.Black;
    }

    private bool CanColorChangeExecute(object? parametr) {
        return true;
    }
    private void ColorChangeCommandExecute(object? parametr=null) {
        var step = IsTwoCellMode?2:1;
        CurrentColorIndex+=step;
    }

    private CellViewModel _redCellViewModel;

    public CellViewModel RedCellViewModel {
        get {
            return _redCellViewModel;
        }
        set {
            _redCellViewModel = value;
            OnPropertyChanged();
        }
    }
    private CellViewModel _yellowCellViewModel;

    public CellViewModel YellowCellViewModel {
        get {
            return _yellowCellViewModel;
        }
        set {
            _yellowCellViewModel = value;
            OnPropertyChanged();
        }
    }
    private CellViewModel _greenCellViewModel;

    public CellViewModel GreenCellViewModel {
        get {
            return _greenCellViewModel;
        }
        set {
            _greenCellViewModel = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}