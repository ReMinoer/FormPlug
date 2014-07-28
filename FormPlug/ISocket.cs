using System;

namespace FormPlug
{
    public interface ISocket
    {
        string Name { get; set; }
        string Group { get; set; }
        event EventHandler ValueChanged;
    }

    public interface ISocket<T> : ISocket
    {
        T Value { get; set; }
    }
}