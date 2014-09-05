using System;
using System.Windows.Forms;
using FormPlug.Annotations;
using FormPlug.TestHelper;

namespace FormPlug.WindowsForm.Sample
{
    internal partial class AutoPlugPanelView : Form
    {
        private readonly TestObject _test;

        public AutoPlugPanelView()
        {
            InitializeComponent();

            _test = new TestObject();

            var autoPlugPanel = new AutoPlugFlowLayoutPanel();
            parentPanel.Controls.Add(autoPlugPanel);

            autoPlugPanel.Connect(_test);

            externalButton.Click += ExternalButtonOnClick;
            displayButton.Click += DisplayButtonOnClick;
        }

        private void ExternalButtonOnClick(object sender, EventArgs eventArgs)
        {
            _test.Reset();
        }

        private void DisplayButtonOnClick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show(_test.ToString(), @"TestObject", MessageBoxButtons.OK);
        }
    }
}