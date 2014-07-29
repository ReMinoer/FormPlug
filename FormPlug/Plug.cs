﻿using System;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    public abstract class Plug<TValue, TControl, TAttribute> : IPlug<TValue, TControl>
        where TAttribute : SocketAttribute where TControl : new()
    {
        [UsedImplicitly]
        private IPlugger _plugger;

        protected Plug()
        {
            Control = new TControl();
        }

        public TControl Control { get; private set; }

        public void Connect(Socket<TValue> socket)
        {
            _plugger = new SocketPlugger<TValue, TControl>(this, socket);
        }

        public void Connect(object obj, PropertyInfo property)
        {
            _plugger = new PropertyPlugger<TValue, TControl>(this, obj, property);

            var attribute = (TAttribute)property.GetCustomAttribute(typeof(TAttribute));
            if (attribute == null)
                return;

            UseSocketAttribute(attribute);
        }

        public void Connect(object obj, string propertyName)
        {
            Connect(obj, obj.GetType().GetProperty(propertyName));
        }

        public abstract TValue Value { get; set; }
        public abstract event EventHandler ValueChanged;

        static public implicit operator TControl(Plug<TValue, TControl, TAttribute> value)
        {
            return value.Control;
        }

        protected abstract void UseSocketAttribute(TAttribute attribute);
    }
}