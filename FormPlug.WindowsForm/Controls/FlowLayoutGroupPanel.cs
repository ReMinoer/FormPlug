using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    internal class FlowLayoutGroupPanel : GroupBox
    {
        public FlowDirection FlowDirection
        {
            get { return _panel.FlowDirection; }
            set { _panel.FlowDirection = value; }
        }

        public bool WrapContents { get { return _panel.WrapContents; } set { _panel.WrapContents = value; } }
        private readonly FlowLayoutPanel _panel;

        public FlowLayoutGroupPanel()
        {
            _panel = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill
            };
            Controls.Add(_panel);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control != _panel)
                _panel.Controls.Add(e.Control);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e.Control != _panel)
                _panel.Controls.Remove(e.Control);
        }
    }
}