﻿using System;
using System.Reflection;
using System.Windows.Forms;
using FormPlug.WindowsForm.Sockets;

namespace FormPlug.WindowsForm
{
    public class PlugableFlowLayoutPanel : PlugablePanel<Control, FlowLayoutPanel>
    {
        public PlugableFlowLayoutPanel(Control parent)
            : base(parent) {}

        protected override FlowLayoutPanel CreatePanel(Control parent)
        {
            var panel = new FlowLayoutPanel {FlowDirection = FlowDirection.TopDown};
            parent.Controls.Add(panel);
            return panel;
        }

        protected override void AddLabel(FlowLayoutPanel panel, string text)
        {
            panel.Controls.Add(new Label {Text = text});
        }

        protected override void AddSocket(FlowLayoutPanel panel, ISocket socket, Type genericTypeArgument)
        {
            if (genericTypeArgument == typeof(int))
                panel.Controls.Add(new IntegerPlug(socket as Socket<int>));
        }

        protected override void AddSocketAttribute(FlowLayoutPanel panel, object obj, PropertyInfo propertyInfo,
                                                   SocketAttribute attribute)
        {
            if (attribute is IntegerSocketAttribute)
                panel.Controls.Add(new IntegerPlug(obj, propertyInfo));
        }
    }
}