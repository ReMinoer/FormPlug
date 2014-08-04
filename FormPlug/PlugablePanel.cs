using System;
using System.Collections.Generic;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    // TODO : Find solution for directly add control to group
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

                    TLabel label = CreateLabel(socket.Attribute.Name ?? propertyInfo.Name);

                    Type type = typeof(PlugablePanel<TParent, TPanel, TGroup, TLabel, TControl>);
                    MethodInfo method = type.GetMethod("CreatePlugFromSocket",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    MethodInfo genericMethod = method.MakeGenericMethod(genericType);

                    TControl control;
                    try
                    {
                        control = (TControl)genericMethod.Invoke(this, new object[] {socket});
                    }
                    catch (TargetInvocationException e)
                    {
                        if (e.InnerException is InvalidCastException)
                            throw new ArgumentException(
                                string.Format("Attribute {0} is unvalid for the property {1} of type Socket<{2}>",
                                    socket.Attribute.GetType().Name, propertyInfo.Name, genericType.Name));
                        throw e.InnerException;
                    }

                    AddEntry(label, control, panel, socket.Attribute.Group);
                }
                else
                    foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        if (!(attribute is SocketAttribute))
                            continue;

                        var socketAttribute = attribute as SocketAttribute;

                        TLabel label = CreateLabel(socketAttribute.Name ?? propertyInfo.Name);

                        TControl control;
                        try
                        {
                            control = CreatePlugFromSocketAttribute(obj, propertyInfo, socketAttribute);
                        }
                        catch (ArgumentException)
                        {
                            throw new ArgumentException(
                                string.Format("Attribute {0} is unvalid for the property {1} of type {2}",
                                    attribute.GetType().Name, propertyInfo.Name, propertyInfo.PropertyType.Name));
                        }

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
            var plug = (IPlug<T, TControl>)GetAssociatePlug<T>(socket.Attribute);
            plug.Connect(socket as Socket<T>);
            return plug.Control;
        }

        private TControl CreatePlugFromSocketAttribute(object obj, PropertyInfo propertyInfo, SocketAttribute attr)
        {
            IPlug<TControl> plug = GetAssociatePlug(propertyInfo.PropertyType, attr);
            plug.Connect(obj, propertyInfo);
            return plug.Control;
        }

        private IPlug<TControl> GetAssociatePlug(Type genericType, SocketAttribute attribute)
        {
            MethodInfo method = GetType().GetMethod("GetAssociatePlug", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo genericMethod = method.MakeGenericMethod(genericType);

            return (IPlug<TControl>)genericMethod.Invoke(this, new object[] {attribute});
        }

        protected abstract IPlug<TControl> GetAssociatePlug<T>(SocketAttribute attribute);

        protected abstract TPanel CreatePanel();
        protected abstract TGroup CreateGroup(string name);
        protected abstract TLabel CreateLabel(string text);

        protected abstract void AddPanelToParent(TParent parent, TPanel panel);
        protected abstract void AddGroupToPanel(TPanel panel, TGroup group);
        protected abstract void AddPanelToGroup(TGroup group, TPanel panel);
        protected abstract void AddControlToPanel(TPanel panel, TControl control);
        protected abstract void AddLabelToPanel(TPanel panel, TLabel label);
    }

    public abstract class PlugablePanel<TControlBase>
        : PlugablePanel<TControlBase, TControlBase, TControlBase, TControlBase, TControlBase>
    {
        protected PlugablePanel(TControlBase parent)
            : base(parent) {}

        protected abstract void AddControlToControl(TControlBase parent, TControlBase control);

        protected sealed override void AddPanelToParent(TControlBase parent, TControlBase panel)
        {
            AddControlToControl(parent, panel);
        }

        protected sealed override void AddGroupToPanel(TControlBase panel, TControlBase group)
        {
            AddControlToControl(panel, group);
        }

        protected sealed override void AddPanelToGroup(TControlBase group, TControlBase panel)
        {
            AddControlToControl(group, panel);
        }

        protected sealed override void AddControlToPanel(TControlBase panel, TControlBase control)
        {
            AddControlToControl(panel, control);
        }

        protected sealed override void AddLabelToPanel(TControlBase panel, TControlBase label)
        {
            AddControlToControl(panel, label);
        }
    }
}