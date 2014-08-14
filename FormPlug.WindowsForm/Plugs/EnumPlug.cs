using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class EnumPlug<T> : EnumPlugBase<T, ComboBox>
    {
        protected override string Output { get { return Control.Text; } set { Control.Text = value; } }
        protected override bool ReadOnly { set { Control.Enabled = !value; } }

        public EnumPlug() {}

        public EnumPlug(ComboBox control)
            : base(control) {}

        public override event EventHandler ValueChanged
        {
            add { Control.SelectedIndexChanged += value; }
            remove { Control.SelectedIndexChanged -= value; }
        }

        protected override void InitializeControl()
        {
            Control.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void InitializeNames(IEnumerable<string> names)
        {
            Control.Items.Clear();
            foreach (string name in names)
                Control.Items.Add(name);
        }
    }
}