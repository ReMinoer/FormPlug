using System;
using System.Reflection;

namespace FormPlug
{
    public interface IPlug
    {
        event EventHandler ValueChanged;

        void Connect(object obj, PropertyInfo property);
        void Connect(object obj, string propertyName);
    }

    public interface IPlug<out TControl> : IPlug
    {
        TControl Control { get; }
    }

    public interface IPlug<TValue, out TControl> : IPlug<TControl>
    {
        TValue Value { get; set; }

        void Connect(Socket<TValue> socket);
    }

    public interface IPlug<TValue, out TControl, TAttribute> : IPlug<TValue, TControl>
        where TAttribute : SocketAttribute {}
}