using System;
using System.Windows.Forms;
using FormPlug.Annotations;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm.Sample
{
    public class MainPresenter
    {
        [UsedImplicitly, IntegerSocket(Minimum = 0, Maximum = 10, Increment = 1)]
        public int Integer
        {
            get { return _integer; }
            set
            {
                _integer = value;
                IntegerValueChanged(this, EventArgs.Empty);
            }
        }
        private readonly Socket<int> _integerSocket;

        private readonly TestObject _test;
        private readonly IMainView _view;
        private int _integer;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _test = new TestObject();
            _integerSocket = new Socket<int> {Value = 0};

            var plugablePanel = new PlugableFlowLayoutPanel(_view.ParentPanel);
            plugablePanel.Connect(_test);

            var integerPlug = new IntegerPlug();
            integerPlug.Connect(this, "Integer");
            _view.ParentPanel.Controls.Add(integerPlug);

            var integerPlug2 = new IntegerPlug();
            integerPlug2.Connect(_integerSocket);
            _view.ParentPanel.Controls.Add(integerPlug2);

            _view.ExternalButton.Click += ExternalButtonOnClick;
            _view.DisplayButton.Click += DisplayButtonOnClick;
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;

        private void ExternalButtonOnClick(object sender, EventArgs eventArgs)
        {
            _test.Reset();
            _integerSocket.Value = 0;
            Integer = 0;
        }

        private void DisplayButtonOnClick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show(_test.ToString(), @"TestObject", MessageBoxButtons.OK);
        }
    }

    public interface IMainView
    {
        FlowLayoutPanel ParentPanel { get; }
        Button ExternalButton { get; }
        Button DisplayButton { get; }
    }
}