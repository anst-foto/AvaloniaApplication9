using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication9.ViewModels;

public class ОсновноеОкноМодельПредставления : 蒙古新字
{
    [Reactive] public bool ЕслиОпасность {get; set;}
    [Reactive] public bool ЕслиПредупреждение {get; set;}
    
    public ReactiveCommand<Unit, Unit> Command { get; }
    
    public bool IsFoo => ЕслиОпасность || ЕслиПредупреждение;

    public ОсновноеОкноМодельПредставления()
    {
        ЕслиОпасность = true;
        ЕслиПредупреждение = false;
        
        Command = ReactiveCommand.Create(execute:() =>
        {
            ЕслиОпасность = !ЕслиОпасность;
            ЕслиПредупреждение = !ЕслиПредупреждение;
        }, 
            this.WhenAnyValue(
            p1 => p1.ЕслиОпасность,
            p2 => p2.ЕслиПредупреждение,
            (x, y) => x || y));
    }
}