using System;
using System.Windows.Input;

namespace LearnXAML.Commands; 

public class Command:ICommand {
    private Action<object> executeMethod;
    private Func<object, bool> canExecuteMethod;

    public Command(Action<object> executeMethod,Func<object,bool> canExecuteMethod) {
        this.executeMethod = executeMethod;
        this.canExecuteMethod = canExecuteMethod;
    }
    public bool CanExecute(object? parameter) {
        return canExecuteMethod(parameter);
    }

    public void Execute(object? parameter) {
        executeMethod(parameter);
    }

    public event EventHandler? CanExecuteChanged {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}