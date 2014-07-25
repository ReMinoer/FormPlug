using System;
using FormPlug.Annotations;

namespace FormPlug.WindowsForm.Sample
{
    internal class TestObject
    {
        [IntegerSocket(Minimum = 0, Maximum = 10, Increment = 1)]
        private int Integer
        {
            [UsedImplicitly]
            get { return _integer; }
            set
            {
                _integer = value;
                IntegerValueChanged(this, EventArgs.Empty);
            }
        }

        [IntegerSocket(Minimum = -10, Maximum = 0, Increment = 2)]
        private int Integer2
        {
            [UsedImplicitly]
            get { return _integer2; }
            set
            {
                _integer2 = value;
                Integer2ValueChanged(this, EventArgs.Empty);
            }
        }

        private Socket<int> IntegerSocket { get; set; }

        private int _integer;
        private int _integer2;

        public TestObject()
        {
            IntegerSocket = new Socket<int>();
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;
        [UsedImplicitly]
        public event EventHandler Integer2ValueChanged;

        public void Reset()
        {
            Integer = 0;
            Integer2 = 0;
            IntegerSocket.Value = 0;
        }
    }
}