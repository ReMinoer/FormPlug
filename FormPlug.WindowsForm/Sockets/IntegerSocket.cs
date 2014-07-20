using System;
using System.Reflection;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Sockets
{
    internal class IntegerSocket : NumericUpDown, ISocket<int>
    {
        private readonly Plug<int> _plug;

        public IntegerSocket(ref object obj, PropertyInfo property, PlugableIntAttribute attr)
        {
            _plug = new Plug<int>(this, ref obj, property);

            Minimum = attr.Minimum;
            Maximum = attr.Maximum;
            Increment = attr.Increment;
        }

        public int PluggedValue { get { return (int)Value; } set { Value = value; } }

        public event EventHandler InternalChange { add { ValueChanged += value; } remove { ValueChanged -= value; } }
    }
}