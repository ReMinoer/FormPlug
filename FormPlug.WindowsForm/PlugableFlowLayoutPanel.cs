using System;
using System.Windows.Forms;
using FormPlug.WindowsForm.Sockets;

namespace FormPlug.WindowsForm
{
    public class PlugableFlowLayoutPanel : PlugablePanel<Control, FlowLayoutPanel, GroupBox, Control, Label>
    {
        public PlugableFlowLayoutPanel(Control parent)
            : base(parent) {}

        protected override IPlug<Control> GetAssociatePlug(Type type)
        {
            if (type == typeof(int))
                return new IntegerPlug();
            if (type == typeof(string))
                return new TextPlug();

            return null;
        }

        protected override FlowLayoutPanel CreatePanel()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill
            };
        }

        protected override GroupBox CreateGroup(string name)
        {
            return new GroupBox {Text = name, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink};
        }

        protected override Label CreateLabel(string text)
        {
            return new Label {Text = text};
        }

        protected override void AddPanelToParent(Control parent, FlowLayoutPanel panel)
        {
            parent.Controls.Add(panel);
        }

        protected override void AddGroupToPanel(FlowLayoutPanel panel, GroupBox group)
        {
            panel.Controls.Add(group);
        }

        protected override void AddPanelToGroup(GroupBox group, FlowLayoutPanel panel)
        {
            group.Controls.Add(panel);
        }

        protected override void AddPlugToPanel(FlowLayoutPanel panel, Control plug)
        {
            panel.Controls.Add(plug);
        }

        protected override void AddLabelToPanel(FlowLayoutPanel panel, Label label)
        {
            panel.Controls.Add(label);
        }
    }
}