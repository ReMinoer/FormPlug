using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormPlug.WindowsForm.Plugs;

namespace FormPlug.WindowsForm.Sample
{
    public partial class PlugablePanelView : Form
    {
        private PlugableViewData _data;

        public PlugablePanelView()
        {
            InitializeComponent();

            _data = new PlugableViewData();

            var plugableView = new PlugableView(this);
            plugableView.Connect(_data);
        }

        private class PlugableView : PlugablePanel<PlugablePanelView, Control, PlugableViewData>
        {
            public PlugableView(PlugablePanelView panel)
                : base(panel) {}

            protected override void CreatePlugs(PlugablePanelView panel, PlugableViewData obj,
                                                ReadOnlyDictionary<string, PropertyInfo> properties)
            {
                var number = new NumericPlug<int>(panel.numericUpDown1);
                number.Connect(obj, properties["Number"]);
                Plugs.Add(number);
            }
        }

        private class PlugableViewData
        {
            [NumericSocket(Minimum = -6, Maximum = 6, Increment = 2)]
            public int Number { get; set; }
        }
    }
}
