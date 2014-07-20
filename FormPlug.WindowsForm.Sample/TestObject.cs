using System;
using FormPlug.Annotations;

namespace FormPlug.WindowsForm.Sample
{
    internal class TestObject
    {
        [PlugableInt(Minimum = 0, Maximum = 10, Increment = 1)]
        public int IntValue
        {
            get { return _intValue; }
            set
            {
                _intValue = value;
                IntValueExternalChange.Invoke(this, new EventArgs());
            }
        }

        [PlugableInt(Minimum = -10, Maximum = 0, Increment = 2)]
        public int IntValue2
        {
            get { return _intValue2; }
            set
            {
                _intValue2 = value;
                IntValue2ExternalChange.Invoke(this, new EventArgs());
            }
        }

        private int _intValue;
        private int _intValue2;

        [UsedImplicitly]
        public event EventHandler IntValueExternalChange;
        [UsedImplicitly]
        public event EventHandler IntValue2ExternalChange;
    }
}