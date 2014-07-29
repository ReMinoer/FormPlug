using System;
using System.Collections.Generic;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    public abstract class PlugablePanel<TParent, TPanel, TGroup, TLabel, TControl>
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

                    Type type = typeof(PlugablePanel<TParent, TPanel, TGroup, TLabel, TControl>);
                    MethodInfo method = type.GetMethod("CreatePlugFromSocket",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo genericMethod = method.MakeGenericMethod(genericType);
                    var control = (TControl)genericMethod.Invoke(this, new object[] {socket});

                    AddEntry(label, control, panel, socket.Group);
                }
                else
                    foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        if (!(attribute is SocketAttribute))
                            continue;

                        var socketAttribute = attribute as SocketAttribute;

                        TLabel label = CreateLabel(socketAttribute.Name ?? propertyInfo.Name);
                        TControl control = CreatePlugFromSocketAttribute(obj, propertyInfo);

                        AddEntry(label, control, panel, socketAttribute.Group);
                    }
            }
        }

        private void AddEntry(TLabel label, TControl control, TPanel panel, string groupName)
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
            AddControlToPanel(targetPanel, control);
        }

        [UsedImplicitly]
        private TControl CreatePlugFromSocket<T>(ISocket socket)
        {
            var plug = (IPlug<T, TControl>)GetAssociatePlug<T>();
            plug.Connect(socket as Socket<T>);
            return plug.Control;
        }

        private TControl CreatePlugFromSocketAttribute(object obj, PropertyInfo propertyInfo)
        {
            IPlug<TControl> plug = GetAssociatePlug(propertyInfo.PropertyType);
            plug.Connect(obj, propertyInfo);
            return plug.Control;
        }

        private IPlug<TControl> GetAssociatePlug(Type genericType)
        {
            MethodInfo method = GetType().GetMethod("GetAssociatePlug", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo genericMethod = method.MakeGenericMethod(genericType);

            return (IPlug<TControl>)genericMethod.Invoke(this, new object[0]);
        }

        protected abstract IPlug<TControl> GetAssociatePlug<T>();

        protected abstract TPanel CreatePanel();
        protected abstract TGroup CreateGroup(string name);
        protected abstract TLabel CreateLabel(string text);

        protected abstract void AddPanelToParent(TParent parent, TPanel panel);
        protected abstract void AddGroupToPanel(TPanel panel, TGroup group);
        protected abstract void AddPanelToGroup(TGroup group, TPanel panel);
        protected abstract void AddControlToPanel(TPanel panel, TControl control);
        protected abstract void AddLabelToPanel(TPanel panel, TLabel label);
    }

    public abstract class PlugablePanel<TBaseControl>
        : PlugablePanel<TBaseControl, TBaseControl, TBaseControl, TBaseControl, TBaseControl>
    {
        protected PlugablePanel(TBaseControl parent)
            : base(parent) {}

        protected abstract void AddControlToControl(TBaseControl parent, TBaseControl control);

        protected override sealed void AddPanelToParent(TBaseControl parent, TBaseControl panel)
        {
            AddControlToControl(parent, panel);
        }

        protected override sealed void AddGroupToPanel(TBaseControl panel, TBaseControl group)
        {
            AddControlToControl(panel, group);
        }

        protected override sealed void AddPanelToGroup(TBaseControl group, TBaseControl panel)
        {
            AddControlToControl(group, panel);
        }

        protected override sealed void AddControlToPanel(TBaseControl panel, TBaseControl control)
        {
            AddControlToControl(panel, control);
        }

        protected override sealed void AddLabelToPanel(TBaseControl panel, TBaseControl label)
        {
            AddControlToControl(panel, label);
        }
    }
}