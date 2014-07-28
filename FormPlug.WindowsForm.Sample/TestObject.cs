using System;
using FormPlug.Annotations;

namespace FormPlug.WindowsForm.Sample
{
    internal class TestObject
    {
        [IntegerSocket(Minimum = 0, Maximum = 10, Increment = 1, Group = "SocketAttribute", Name = "Int")]
        public int Integer
        {
            [UsedImplicitly]
            get { return _integer; }
            set
            {
                _integer = value;
                if (IntegerValueChanged != null)
                    IntegerValueChanged(this, EventArgs.Empty);
            }
        }

        public Socket<int> IntegerSocket { get; set; }

        private int _integer;

        public TestObject()
        {
            IntegerSocket = new Socket<int> {Group = "Socket<T>", Name = "Int", Value = 0};
            Reset();
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;

        public void Reset()
        {
            Integer = 0;
            IntegerSocket.Value = 0;
        }
    }
}