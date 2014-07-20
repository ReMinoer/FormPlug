using System.Windows.Forms;

namespace FormPlug.WindowsForm.Sample
{
    internal partial class MainView : Form, IMainView
    {
        private MainPresenter _presenter;

        public MainView()
        {
            InitializeComponent();

            _presenter = new MainPresenter(this);
        }

        public FlowLayoutPanel FlowLayoutPanel { get { return flowLayoutPanel; } }
        public Button ExternalButton { get { return externalButton; } }
    }
}