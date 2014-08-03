using System;
using System.Windows.Forms;
using FormPlug.Annotations;
using FormPlug.Test;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm.Sample
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly TestObject _test;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _test = new TestObject();

            var plugablePanel = new PlugableFlowLayoutPanel(_view.ParentPanel);
            plugablePanel.Connect(_test);

            _view.ExternalButton.Click += ExternalButtonOnClick;
            _view.DisplayButton.Click += DisplayButtonOnClick;
        }

        [UsedImplicitly]
        public event EventHandler IntegerValueChanged;

        private void ExternalButtonOnClick(object sender, EventArgs eventArgs)
        {
            _test.Reset();
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