using System.Windows.Forms;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm
{
    // TODO : Fix margin between element in panel
    public class PlugableFlowLayoutPanel : PlugablePanel<Control>
    {
        public PlugableFlowLayoutPanel(Control parent)
            : base(parent) {}

        protected override IPlug<Control> GetAssociatePlug<T>(SocketAttribute attribute)
        {
            if (attribute is BooleanSocketAttribute)
                return new BooleanPlug();

            if (attribute is NumericSocketAttribute)
                return new NumericPlug<T>();

            if (attribute is TextSocketAttribute)
                return new TextPlug();

            if (attribute is EnumSocketAttribute)
                return new EnumPlug<T>();

            if (attribute is ColorSocketAttribute)
                return new ColorPlug();

            if (attribute is DateTimeSocketAttribute)
                return new DateTimePlug();

            if (attribute is FileSocketAttribute)
                return new FilePlug();

            if (attribute is FolderSocketAttribute)
                return new FolderPlug();

            return null;
        }

        protected override Control CreatePanel()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill
            };
        }

        protected override Control CreateGroup(string name)
        {
            return new GroupBox {Text = name, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink};
        }

        protected override Control CreateLabel(string text)
        {
            return new Label {Text = text, Padding = new Padding(0,4,0,0)};
        }

        protected override void AddControlToControl(Control parent, Control control)
        {
            parent.Controls.Add(control);
        }
    }
}