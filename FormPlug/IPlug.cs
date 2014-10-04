using System;
using System.Reflection;
using FormPlug.SocketAttributes;

namespace FormPlug
{
    // TODO : Make internal some interfaces
    public interface IPlug
    {
        event EventHandler ValueChanged;

        void Connect(object obj, PropertyInfo property);
        void Connect(object obj, string propertyName);
        void Connect(object obj, PropertyInfo property, SocketAttribute attribute);
        void Connect(object obj, string propertyName, SocketAttribute attribute);
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
}