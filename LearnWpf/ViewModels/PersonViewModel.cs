using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LearnXAML.Commands;
using LearnXAML.Models;

namespace LearnXAML.ViewModels; 

public class PersonViewModel:INotifyPropertyChanged {

    private Person _person;

    public Person Person {
        get { return _person; }
        set {
            _person = value;
            OnPropertyChanged(nameof(Person));
        }
    }
    public ICommand AddCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    public ObservableCollection<Person> People { get; set; } = new();
    public PersonViewModel() {

        AddCommand = new Command(AddCommandExecute, CanAddCommandExecute);
        RemoveCommand = new Command(RemoveCommandExecute, CanRemoveCommandExecute);
        Person = new();
        for (int i = 0; i < 100; i++) {
            People.Add(new Person {
                FirstName = $"FirstName#{i}",
                LastName = $"LastName#{i}",
                Age = i
            });
        }
    }

    private bool CanAddCommandExecute(object? parametr) {
        return true;
    }
    private void AddCommandExecute(object? parametr) {
        People.Add(Person);
        Person = new();
    }
    private bool CanRemoveCommandExecute(object? parametr) {
        if (parametr is null) return false;
        var index = (int)parametr;
        if (index<0 || index>=People.Count ) return false;
        return true;
    }
    private void RemoveCommandExecute(object? parametr) {
        if(parametr is null) return;
        People.RemoveAt((int) parametr);
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