using System;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    // TODO : Plug for generic dialog, list
    public abstract class Plug<TValue, TControl, TAttribute> : IPlug<TValue, TControl>
        where TAttribute : SocketAttribute where TControl : new()
    {
        protected abstract TAttribute DefaultAttribute { get; }

        [UsedImplicitly]
        private IPlugger _plugger;

        protected Plug()
        {
            Control = new TControl();
        }

        public TControl Control { get; private set; }

        public void Connect(Socket<TValue> socket)
        {
            if (!IsTypeValid(socket.Value.GetType()))
                throw new ArgumentException(string.Format("The generic type of Socket<{0}> is unvalid for {1}",
                    socket.Value.GetType().Name, GetType().Name));

            InitializeControl();
            UseAttribute(DefaultAttribute);

            if (socket.Attribute != null)
            {
                var attribute = socket.Attribute as TAttribute;
                if (attribute == null)
                    throw new ArgumentException(string.Format("Socket<{0}>.Attribute isn't of type {1}",
                        typeof(TValue).Name, typeof(TAttribute).Name));

                UseAttribute(attribute);
            }

            _plugger = new SocketPlugger<TValue, TControl>(this, socket);
        }

        public void Connect(object obj, PropertyInfo property)
        {
            if (!IsTypeValid(property.PropertyType))
                throw new ArgumentException(string.Format("The type {0} of property {1} is unvalid for {2}",
                    property.PropertyType.Name, property.Name, GetType().Name));

            InitializeControl();
            UseAttribute(DefaultAttribute);

            var attribute = (TAttribute)property.GetCustomAttribute(typeof(TAttribute));
            if (attribute == null)
                throw new ArgumentException(string.Format("The property {0} doesn't have attribute of type {1}",
                    property.Name, typeof(TAttribute).Name));

            UseAttribute(attribute);

            _plugger = new PropertyPlugger<TValue, TControl>(this, obj, property);
        }

        public void Connect(object obj, string propertyName)
        {
            Connect(obj, obj.GetType().GetProperty(propertyName));
        }

        public abstract TValue Value { get; set; }
        public abstract event EventHandler ValueChanged;

        protected virtual bool IsTypeValid(Type type)
        {
            return type == typeof(TValue);
        }

        static public implicit operator TControl(Plug<TValue, TControl, TAttribute> value)
        {
            return value.Control;
        }

        protected abstract void InitializeControl();
        protected abstract void UseAttribute(TAttribute attribute);
    }
}