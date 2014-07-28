using System;

namespace FormPlug
{
    public interface IPlug
    {
        event EventHandler PlugValueChanged;
    }

    public interface IPlug<T> : IPlug
    {
        T PluggedValue { get; set; }
    }
}