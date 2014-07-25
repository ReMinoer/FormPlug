﻿using System;
using System.Reflection;
using System.Windows.Forms;
using FormPlug.Annotations;

namespace FormPlug.WindowsForm.Sockets
{
    public class IntegerPlug : NumericUpDown, IPlug<int>
    {
        [UsedImplicitly]
        private readonly IPlugger _plugger;

        public IntegerPlug(Socket<int> socket)
        {
            _plugger = new SocketPlugger<int>(this, socket);
        }

        public IntegerPlug(object obj, PropertyInfo property)
        {
            _plugger = new PropertyPlugger<int>(this, obj, property);

            var attr = (IntegerSocketAttribute)property.GetCustomAttribute(typeof(IntegerSocketAttribute));
            if (attr == null)
                return;

            Minimum = attr.Minimum;
            Maximum = attr.Maximum;
            Increment = attr.Increment;
        }

        public IntegerPlug(object obj, string propertyName)
            : this(obj, obj.GetType().GetProperty(propertyName)) {}

        public int PluggedValue { get { return (int)Value; } set { Value = value; } }
        public event EventHandler PlugValueChanged { add { ValueChanged += value; } remove { ValueChanged -= value; } }
    }
}