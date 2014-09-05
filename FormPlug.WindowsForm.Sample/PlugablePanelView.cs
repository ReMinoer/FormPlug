using System;
using System.Drawing;
using System.Windows.Forms;
using FormPlug.TestHelper;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm.Sample
{
    public partial class PlugablePanelView : Form
    {
        private readonly Data _data;

        public PlugablePanelView()
        {
            InitializeComponent();

            _data = new Data();

            var plugableView = new PlugablePanel(this);
            plugableView.Connect(_data);
        }

        private class Data
        {
            private bool Bool { get; set; }
            private int Int { get; set; }
            private float Float { get; set; }
            private string String { get; set; }
            private string BigString { get; set; }
            private TestEnum Enum { get; set; }
            private Color Color { get; set; }
            private DateTime DateTime { get; set; }
            private string File { get; set; }
            private string Folder { get; set; }
            private string Image { get; set; }

            public Data()
            {
                Reset();
            }

            public void Reset()
            {
                Bool = false;
                Int = 0;
                Float = 0;
                String = "";
                BigString = "";
                Enum = TestEnum.Yes;
                Color = Color.White;
                DateTime = DateTime.Now;
                File = "";
                Folder = "";
                Image = "";
            }
        }

        private class PlugablePanel : PlugablePanel<PlugablePanelView, Data, Control>
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