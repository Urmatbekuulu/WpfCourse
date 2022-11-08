using System;
using System.Windows.Input;

namespace LearnXAML.Commands; 

public class Command:ICommand {
    private Action<object> executeAction;
    private Func<object, bool> canExecute;

    public Command(Action<object> executeAction, Func<object,bool> canExecute) {
        this.executeAction = executeAction;
        this.canExecute = canExecute;
    }
    public bool CanExecute(object? parameter) {
        return canExecute(parameter);
    }

    public void Execute(object? parameter) {
        executeAction(parameter);
    }

    public event EventHandler? CanExecuteChanged {
        add { CommandManager.RequerySuggested += value; }  
        remove { CommandManager.RequerySuggested -= value; }  
    }
}