using System;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Sample
{
    public class MainPresenter
    {
        private readonly TestObject _test;
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _test = new TestObject();
            PanelGenerator.Create(_view.FlowLayoutPanel, _test);

            _view.ExternalButton.Click += ExternalButtonOnClick;
        }

        private void ExternalButtonOnClick(object sender, EventArgs eventArgs)
        {
            _test.IntValue = 0;
            _test.IntValue2 = 0;
        }
    }

    public interface IMainView
    {
        FlowLayoutPanel FlowLayoutPanel { get; }
        Button ExternalButton { get; }
    }
}