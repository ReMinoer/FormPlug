using System.Windows.Forms;

namespace FormPlug.WindowsForm
{
    public partial class AutoPlugFlowLayoutForm : Form
    {
        public AutoPlugFlowLayoutForm(object obj)
        {
            InitializeComponent();

            var autoPlugPanel = new AutoPlugFlowLayoutPanel();
            parentPanel.Controls.Add(autoPlugPanel);

            autoPlugPanel.Connect(obj);
        }
    }
}