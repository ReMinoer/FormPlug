using System;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Sample
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            buttonAutoPlugPanel.Click += ButtonAutoPlugPanelOnClick;
            buttonPlugablePanel.Click += ButtonPlugablePanelOnClick;
        }

        static private void ButtonAutoPlugPanelOnClick(object sender, EventArgs eventArgs)
        {
            var view = new AutoPlugPanelView();
            view.ShowDialog();
        }

        static private void ButtonPlugablePanelOnClick(object sender, EventArgs eventArgs)
        {
            var view = new PlugablePanelView();
            view.ShowDialog();
        }
    }
}