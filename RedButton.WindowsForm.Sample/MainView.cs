using System.Windows.Forms;

namespace RedButton.WindowsForm.Sample
{
    internal partial class MainView : Form, IMainView
    {
        private MainPresenter _presenter;

        public MainView()
        {
            _presenter = new MainPresenter(this);

            InitializeComponent();
        }
    }
}