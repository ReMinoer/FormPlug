using System;
using FormPlug.Annotations;

namespace FormPlug
{
    public class Socket<T> : ISocket<T>
    {
        private T _value;
        public SocketAttribute Attribute { get; set; }

        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (ValueChanged != null)
                    ValueChanged(this, EventArgs.Empty);
            }
        }

        [UsedImplicitly]
        public event EventHandler ValueChanged;

        static public implicit operator T(Socket<T> value)
        {
            return value.Value;
        }
    }
}