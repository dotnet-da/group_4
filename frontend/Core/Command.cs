using System;
using System.Windows.Input;

namespace frontend.Core;

public class Command : ICommand
{
    readonly Action<object> _executableCode;
    readonly Predicate<object> _isExecutable;

    public Command(Action<object> executableCode) : this(executableCode, null)
    {
    }

    public Command(Action<object> executableCode, Predicate<object> isExecutable)
    {
        _executableCode = executableCode;
        _isExecutable = isExecutable;
    }

    public bool CanExecute(object? parameters)
    {
        return _isExecutable == null ? true : _isExecutable(parameters);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object? parameters)
    {
        _executableCode(parameters!);
    }
}