using System;
using System.Globalization;
using System.Text;
using FormPlug.Annotations;

namespace FormPlug.Test
{
    public class TestObject
    {
        [BooleanSocket(Group = "SocketAttribute", Name = "Boolean")]
        private bool Boolean
        {
            [UsedImplicitly]
            get { return _boolean; }
            set
            {
                _boolean = value;
                if (BooleanValueChanged != null)
                    BooleanValueChanged(this, EventArgs.Empty);
            }
        }

        [NumericSocket(Minimum = 0, Maximum = 10, Increment = 1, Group = "SocketAttribute", Name = "Int")]
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

        [DateTimeSocket(Group = "SocketAttribute", Name = "Enum")]
        private TestEnum Enum
        {
            [UsedImplicitly]
            get { return _enum; }
            set
            {
                _enum = value;
                if (EnumValueChanged != null)
                    EnumValueChanged(this, EventArgs.Empty);
            }
        }

        [DateTimeSocket(Group = "SocketAttribute", Name = "DateTime")]
        private DateTime DateTime
        {
            [UsedImplicitly]
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                if (DateTimeValueChanged != null)
                    DateTimeValueChanged(this, EventArgs.Empty);
            }
        }

        private Socket<bool> BooleanSocket { get; set; }
        private Socket<int> IntegerSocket { get; set; }
        private Socket<string> StringSocket { get; set; }
        private Socket<TestEnum> EnumSocket { get; set; }
        private Socket<DateTime> DateTimeSocket { get; set; }

        private bool _boolean;
        private DateTime _dateTime;
        private TestEnum _enum;
        private int _integer;
        private string _string;

        public TestObject()
        {
            BooleanSocket = new Socket<bool> {Group = "Socket<T>", Name = "Boolean", Value = false};
            IntegerSocket = new Socket<int> {Group = "Socket<T>", Name = "Int", Value = 0};
            StringSocket = new Socket<string> {Group = "Socket<T>", Name = "String", Value = ""};
            EnumSocket = new Socket<TestEnum> {Group = "Socket<T>", Name = "Enum", Value = TestEnum.Yes};
            DateTimeSocket = new Socket<DateTime> {Group = "Socket<T>", Name = "DateTime", Value = DateTime.Now};
            Reset();
        }

        [UsedImplicitly]
        public event EventHandler BooleanValueChanged;
        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;
        [UsedImplicitly]
        public event EventHandler StringValueChanged;
        [UsedImplicitly]
        public event EventHandler DateTimeValueChanged;
        [UsedImplicitly]
        public event EventHandler EnumValueChanged;

        public void Reset()
        {
            Boolean = false;
            Integer = 0;
            String = "";
            Enum = TestEnum.Yes;
            DateTime = DateTime.Now;

            BooleanSocket.Value = false;
            IntegerSocket.Value = 0;
            StringSocket.Value = "";
            EnumSocket.Value = TestEnum.Yes;
            DateTimeSocket.Value = DateTime.Now;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(Boolean.ToString());
            result.AppendLine(Integer.ToString(CultureInfo.CurrentCulture));
            result.AppendLine(String);
            result.AppendLine(Enum.ToString());
            result.AppendLine(DateTime.ToString(CultureInfo.CurrentCulture));

            result.AppendLine(BooleanSocket.Value.ToString());
            result.AppendLine(IntegerSocket.Value.ToString(CultureInfo.CurrentCulture));
            result.AppendLine(StringSocket.Value);
            result.AppendLine(EnumSocket.Value.ToString());
            result.AppendLine(DateTimeSocket.Value.ToString(CultureInfo.CurrentCulture));

            return result.ToString();
        }
    }
}