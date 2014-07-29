using System;
using System.Globalization;
using System.Text;
using FormPlug.Annotations;

namespace FormPlug.WindowsForm.Sample
{
    internal class TestObject
    {
        [IntegerSocket(Minimum = 0, Maximum = 10, Increment = 1, Group = "SocketAttribute", Name = "Int")]
        private int Integer
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

        [TextSocket(Group = "SocketAttribute", Name = "String")]
        private string String
        {
            [UsedImplicitly]
            get { return _string; }
            set
            {
                _string = value;
                if (StringValueChanged != null)
                    StringValueChanged(this, EventArgs.Empty);
            }
        }

        private Socket<int> IntegerSocket { get; set; }
        private Socket<string> StringSocket { get; set; }

        private int _integer;
        private string _string;

        public TestObject()
        {
            IntegerSocket = new Socket<int> {Group = "Socket<T>", Name = "Int", Value = 0};
            StringSocket = new Socket<string> {Group = "Socket<T>", Name = "String", Value = ""};
            Reset();
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;
        [UsedImplicitly]
        public event EventHandler StringValueChanged;

        public void Reset()
        {
            Integer = 0;
            String = "";

            IntegerSocket.Value = 0;
            StringSocket.Value = "";
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(Integer.ToString(CultureInfo.InvariantCulture));
            result.AppendLine(String);
            result.AppendLine(IntegerSocket.Value.ToString(CultureInfo.InvariantCulture));
            result.AppendLine(StringSocket.Value);
            return result.ToString();
        }
    }
}