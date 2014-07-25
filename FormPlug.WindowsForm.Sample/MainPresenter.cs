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
                IntegerValueChanged.Invoke(this, EventArgs.Empty);
            }
        }
        private readonly TestObject _test;
        private readonly IMainView _view;
        private int _integer;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _test = new TestObject();

            var plugablePanel = new PlugableFlowLayoutPanel(_view.ParentPanel);
            plugablePanel.CreatePanel(_test);

            _view.ParentPanel.Controls.Add(new IntegerPlug(this, "Integer"));

            _view.ExternalButton.Click += ExternalButtonOnClick;
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;

        private void ExternalButtonOnClick(object sender, EventArgs eventArgs)
        {
            _test.Integer = 0;
            _test.Integer2 = 0;
            Integer = 0;
        }
    }

    public interface IMainView
    {
        FlowLayoutPanel ParentPanel { get; }
        Button ExternalButton { get; }
    }
}