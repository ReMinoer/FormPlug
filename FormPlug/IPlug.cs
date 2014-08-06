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

    public interface IPlug<TValue, out TControl, in TAttribute> : IPlug<TValue, TControl>
        where TAttribute : SocketAttribute
    {
        void Connect(object obj, PropertyInfo property, TAttribute attribute);
        void Connect(object obj, string propertyName, TAttribute attribute);
    }
}