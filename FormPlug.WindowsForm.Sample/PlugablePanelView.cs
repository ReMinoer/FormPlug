using System.Windows.Forms;
using FormPlug.TestHelper;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm.Sample
{
    public partial class PlugablePanelView : Form
    {
        private TestObject _data;

        public PlugablePanelView()
        {
            InitializeComponent();

            _data = new TestObject();

            var plugableView = new PlugablePanel(this);
            plugableView.Connect(_data);
        }

        private class PlugablePanel : PlugablePanel<PlugablePanelView, TestObject, Control>
        {
            public PlugablePanel(PlugablePanelView panel)
                : base(panel) {}

            protected override void CreatePlugs(PlugablePanelView panel)
            {
                AddPlug<BooleanPlug>(panel.checkBox1, "Bool");
                AddPlug<NumericPlug<int>>(panel.numericUpDown1, "Int");
                AddPlug<NumericPlug<float>>(panel.numericUpDown2, "Float");
                AddPlug<TextPlug>(panel.textBox1, "String");
                AddPlug<TextPlug>(panel.textBox2, "BigString");
                AddPlug<EnumPlug<TestEnum>>(panel.comboBox1, "Enum");
                AddPlug<ColorPlug>(panel.colorDialogButton1, "Color");
                AddPlug<DateTimePlug>(panel.dateTimePicker1, "DateTime");
                AddPlug<FilePlug>(panel.fileDialogButton1, "File");
                AddPlug<FolderPlug>(panel.folderDialogButton1, "Folder");
                AddPlug<ImagePlug>(panel.imageDialogButton1, "Image");
            }
        }
    }
}