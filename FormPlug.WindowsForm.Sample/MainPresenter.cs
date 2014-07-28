using System;
using System.Windows.Forms;
using FormPlug.Annotations;
using FormPlug.WindowsForm.Sockets;

namespace FormPlug.WindowsForm.Sample
{
    public class MainPresenter
    {
        [UsedImplicitly, Socket]
        public int Integer
        {
            get { return _integer; }
            set
            {
                _integer = value;
                IntegerValueChanged(this, EventArgs.Empty);
            }
        }
        private readonly Socket<int> _socketInteger;

        private readonly TestObject _test;
        private readonly IMainView _view;
        private int _integer;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _test = new TestObject();
            _socketInteger = new Socket<int> {Value = 0};

            var plugablePanel = new PlugableFlowLayoutPanel(_view.ParentPanel);
            plugablePanel.ConnectObject(_test);

            _view.ParentPanel.Controls.Add(new IntegerPlug(this, "Integer"));
            _view.ParentPanel.Controls.Add(new IntegerPlug(_socketInteger));

            _view.ExternalButton.Click += ExternalButtonOnClick;
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;

        private void ExternalButtonOnClick(object sender, EventArgs eventArgs)
        {
            _test.Reset();
            _socketInteger.Value = 0;
            Integer = 0;
        }
    }

    public interface IMainView
    {
        FlowLayoutPanel ParentPanel { get; }
        Button ExternalButton { get; }
    }
}