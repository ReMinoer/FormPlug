using System;
using System.Windows.Forms;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm
{
    // TODO : Fix margin between element in panel
    public class PlugableFlowLayoutPanel : PlugablePanel<Control>
    {
        public PlugableFlowLayoutPanel(Control parent)
            : base(parent) {}

        protected override IPlug<Control> GetAssociatePlug<T>()
        {
            Type type = typeof(T);

            if (type == typeof(bool))
                return new BooleanPlug();

            if (type == typeof(int) || type == typeof(double) || type == typeof(float) || type == typeof(decimal))
                return new NumericPlug<T>();

            if (type == typeof(string))
                return new TextPlug();

            if (type.IsEnum)
                return new EnumPlug<T>();

            if (type == typeof(DateTime))
                return new DateTimePlug();

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
            return new Label {Text = text};
        }

        protected override void AddControlToControl(Control parent, Control control)
        {
            parent.Controls.Add(control);
        }
    }
}