using System;
using System.Collections.Generic;
using System.Reflection;
using FormPlug.Annotations;

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

        public void Connect(object obj)
        {
            TPanel panel = CreatePanel();
            AddPanelToParent(_parent, panel);

            PropertyInfo[] propertyInfos =
                obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Socket<>))
                {
                    var socket = (ISocket)propertyInfo.GetValue(obj);
                    Type genericType = propertyType.GenericTypeArguments[0];

                    TLabel label = CreateLabel(socket.Name ?? propertyInfo.Name);

                    Type type = typeof(PlugablePanel<TParent, TPanel, TGroup, TPlug, TLabel>);
                    MethodInfo method = type.GetMethod("CreatePlugFromSocket",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo genericMethod = method.MakeGenericMethod(genericType);
                    var plug = (TPlug)genericMethod.Invoke(this, new object[] {socket});

                    AddEntry(label, plug, panel, socket.Group);
                }
                else
                    foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        if (!(attribute is SocketAttribute))
                            continue;

                        var socketAttribute = attribute as SocketAttribute;

                        TLabel label = CreateLabel(socketAttribute.Name ?? propertyInfo.Name);
                        TPlug plug = CreatePlugFromSocketAttribute(obj, propertyInfo);

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

        [UsedImplicitly]
        private TPlug CreatePlugFromSocket<T>(ISocket socket)
        {
            var plug = (IPlug<T, TPlug>)GetAssociatePlug(typeof(T));
            plug.Connect(socket as Socket<T>);
            return plug.Control;
        }

        private TPlug CreatePlugFromSocketAttribute(object obj, PropertyInfo propertyInfo)
        {
            IPlug<TPlug> plug = GetAssociatePlug(propertyInfo.PropertyType);
            plug.Connect(obj, propertyInfo);
            return plug.Control;
        }

        protected abstract IPlug<TPlug> GetAssociatePlug(Type type);

        protected abstract TPanel CreatePanel();
        protected abstract TGroup CreateGroup(string name);
        protected abstract TLabel CreateLabel(string text);

        protected abstract void AddPanelToParent(TParent parent, TPanel panel);
        protected abstract void AddGroupToPanel(TPanel panel, TGroup group);
        protected abstract void AddPanelToGroup(TGroup group, TPanel panel);
        protected abstract void AddPlugToPanel(TPanel panel, TPlug plug);
        protected abstract void AddLabelToPanel(TPanel panel, TLabel label);
    }
}