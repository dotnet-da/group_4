using System;
using System.Windows.Input;

namespace WpfApp4.Core;

public class Command : ICommand
{
    readonly Action<object> _auszufuehrenderCode;
    readonly Predicate<object> _istAusfuehrbar;

    public Command(Action<object> auszufuehrenderCode) : this(auszufuehrenderCode, null)
    {
    }

    public Command(Action<object> auszufuehrenderCode, Predicate<object> istAusfuehrbar)
    {
        _auszufuehrenderCode = auszufuehrenderCode;
        _istAusfuehrbar = istAusfuehrbar;
    }

    public bool CanExecute(object? parameters)
    {
        return _istAusfuehrbar(parameters!);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object? parameters)
    {
        _auszufuehrenderCode(parameters!);
    }
}