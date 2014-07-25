using System;

namespace FormPlug
{
    public interface IPlug<T>
    {
        T PluggedValue { get; set; }
        event EventHandler PlugValueChanged;
    }
}