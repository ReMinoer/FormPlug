using System;
using System.Collections.Generic;
using System.Reflection;

namespace FormPlug
{
    public abstract class PlugablePanel<TParent, TPanel, TGroup, TPlug, TLabel>
    {
        private readonly Dictionary<string, TPanel> _groups;
        private readonly TParent _parent;

        protected PlugablePanel(TParent parent)
        {
            _parent = parent;
            _groups = new Dictionary<string, TPanel>();
        }

        public void ConnectObject(object obj)
        {
            TPanel panel = CreatePanel();
            AddPanelToParent(_parent, panel);

            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Socket<>))
                {
                    var socket = (ISocket)propertyInfo.GetValue(obj);
                    Type genericTypeArgument = propertyType.GenericTypeArguments[0];

                    TLabel label = CreateLabel(socket.Name ?? propertyInfo.Name);
                    TPlug plug = CreatePlugFromSocket(socket, genericTypeArgument);

                    AddEntry(label, plug, panel, socket.Group);
                }
                else
                    foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        if (!(attribute is SocketAttribute))
                            continue;

                        var socketAttribute = attribute as SocketAttribute;

                        TLabel label = CreateLabel(socketAttribute.Name ?? propertyInfo.Name);
                        TPlug plug = CreatePlugFromSocketAttribute(obj, propertyInfo, socketAttribute);

                        AddEntry(label, plug, panel, socketAttribute.Group);
                    }
            }
        }

        private void AddEntry(TLabel label, TPlug plug, TPanel panel, string groupName)
        {
            TPanel targetPanel = panel;

            if (groupName != null)
                if (_groups.ContainsKey(groupName))
                    targetPanel = _groups[groupName];
                else
                {
                    TGroup group = CreateGroup(groupName);
                    AddGroupToPanel(panel, group);
                    TPanel groupPanel = CreatePanel();
                    AddPanelToGroup(group, groupPanel);

                    _groups.Add(groupName, groupPanel);
                    targetPanel = groupPanel;
                }

            AddLabelToPanel(targetPanel, label);
            AddPlugToPanel(targetPanel, plug);
        }

        protected abstract TPanel CreatePanel();
        protected abstract TGroup CreateGroup(string name);
        protected abstract TLabel CreateLabel(string text);
        protected abstract TPlug CreatePlugFromSocket(ISocket socket, Type genericTypeArgument);

        protected abstract TPlug CreatePlugFromSocketAttribute(object obj, PropertyInfo propertyInfo,
                                                               SocketAttribute attribute);

        protected abstract void AddPanelToParent(TParent parent, TPanel panel);
        protected abstract void AddGroupToPanel(TPanel panel, TGroup group);
        protected abstract void AddPanelToGroup(TGroup group, TPanel panel);
        protected abstract void AddPlugToPanel(TPanel panel, TPlug plug);
        protected abstract void AddLabelToPanel(TPanel panel, TLabel label);
    }
}