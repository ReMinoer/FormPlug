using System;
using System.Drawing;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    public class ImagePlug : ImagePlugBase<ImageDialogButton>
    {
        protected override string[] Extensions
        {
            set
            {
                var filter = new string[value.Length];
                for (int i = 0; i < value.Length; i++)
                    filter[i] = string.Format("{1} files (*.{0})|*.{0}", value[i],
                        value[i] != "*" ? value[i].ToUpper() : "All");
                Control.Filter = string.Join("|", filter);
            }
        }
        protected override string InitialDirectory { set { Control.InitialDirectory = value; } }
        protected override int Width { set { Control.Size = new Size(value, Control.Size.Height); } }
        protected override int Height { set { Control.Size = new Size(Control.Size.Width, value); } }

        public override string Value { get { return Control.Image; } set { Control.Image = value; } }

        public ImagePlug() {}

        public ImagePlug(ImageDialogButton control)
            : base(control) {}

        public override event EventHandler ValueChanged
        {
            add { Control.ImageChanged += value; }
            remove { Control.ImageChanged -= value; }
        }

        protected override void InitializeControl() {}
    }
}