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

        public FlowLayoutPanel ParentPanel { get { return parentPanel; } }
        public Button ExternalButton { get { return externalButton; } }
    }
}