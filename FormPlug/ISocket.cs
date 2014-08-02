using System;

namespace FormPlug
{
    public interface ISocket
    {
        SocketAttribute Attribute { get; set; }
        event EventHandler ValueChanged;
    }

    public interface ISocket<T> : ISocket
    {
        T Value { get; set; }
    }
}