using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LearnXAML.Models; 
public class Person:INotifyPropertyChanged {
    private int _age;
    public int Age {
        get {
            return _age;
        }
        set {
            _age = value;
            OnPropertyChanged(nameof(Age));
        }
    }

    private string? _firstName;
    public string? FirstName {
        get { return _firstName; }
        set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
    }

    private string? _lastName;
    public string? LastName {
        get { return _lastName; }
        set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
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