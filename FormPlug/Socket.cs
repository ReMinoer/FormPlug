using System;
using FormPlug.Annotations;

namespace FormPlug
{
    // TODO : Create generic method for manage SOcket<T> everywhere or give up
    public class Socket<T> : ISocket<T>
    {
        private T _value;
        public SocketAttribute Attribute { get; set; }

        public T Value
        {
            get { return _value; }
            set
            {
                if (value.Equals(_value))
                    return;

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

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}