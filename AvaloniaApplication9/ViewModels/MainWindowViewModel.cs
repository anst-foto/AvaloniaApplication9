using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication9.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    [Reactive] public bool IsAlarm {get; set;}
    [Reactive] public bool IsWarning {get; set;}
    
    public ReactiveCommand<Unit, Unit> Command { get; }
    
    public bool IsFoo => IsAlarm || IsWarning;

    public MainWindowViewModel()
    {
        IsAlarm = true;
        IsWarning = false;
        
        Command = ReactiveCommand.Create(execute:() =>
        {
            IsAlarm = !IsAlarm;
            IsWarning = !IsWarning;
        }, 
            this.WhenAnyValue(
            p1 => p1.IsAlarm,
            p2 => p2.IsWarning,
            (x, y) => x || y));
    }
}