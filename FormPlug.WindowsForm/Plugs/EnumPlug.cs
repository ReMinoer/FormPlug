using System;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class EnumPlug<T> : EnumPlugBase<T, ComboBox>
    {
        protected override string Output { get { return Control.Text; } set { Control.Text = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.SelectedIndexChanged += value; }
            remove { Control.SelectedIndexChanged -= value; }
        }

        protected override void InitializeControl()
        {
            Control.DropDownStyle = ComboBoxStyle.DropDownList;

            Control.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(T)))
                Control.Items.Add(name);
        }
    }
}