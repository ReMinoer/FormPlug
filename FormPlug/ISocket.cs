using System;

namespace FormPlug
{
    public interface ISocket<T>
    {
        T PluggedValue { get; set; }
        event EventHandler InternalChange;
    }
}