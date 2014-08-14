using System.Windows.Forms;
using FormPlug.WindowsForm.Controls;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm
{
    public class AutoPlugFlowLayoutPanel : AutoPlugPanel<Control>
    {
        public AutoPlugFlowLayoutPanel()
            : base(
                new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Dock = DockStyle.Fill
                }) {}

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

            if (attribute is ImageSocketAttribute)
                return new ImagePlug();

            return null;
        }

        protected override void ClearPanel(Control panel)
        {
            panel.Controls.Clear();
        }

        protected override Control CreateGroup(string name)
        {
            return new FlowLayoutGroupPanel
            {
                Text = name,
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
        }

        protected override Control CreateLabel(string text)
        {
            return new Label {Text = text, Padding = new Padding(0, 4, 0, 0)};
        }

        protected override void AddControlToControl(Control parent, Control control)
        {
            parent.Controls.Add(control);
        }
    }
}