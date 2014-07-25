using System;
using FormPlug.Annotations;

namespace FormPlug.WindowsForm.Sample
{
    internal class TestObject
    {
        [IntegerSocket(Minimum = 0, Maximum = 10, Increment = 1)]
        public int Integer
        {
            [UsedImplicitly]
            get { return _integer; }
            set
            {
                _integer = value;
                IntegerValueChanged.Invoke(this, EventArgs.Empty);
            }
        }

        [IntegerSocket(Minimum = -10, Maximum = 0, Increment = 2)]
        public int Integer2
        {
            [UsedImplicitly]
            get { return _integer2; }
            set
            {
                _integer2 = value;
                Integer2ValueChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private int _integer;
        private int _integer2;

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;
        [UsedImplicitly]
        public event EventHandler Integer2ValueChanged;
    }
}