using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    public abstract class PlugablePanel<TPanel, TGroup, TLabel, TControl>
    {
        private readonly TPanel _panel;
        private Dictionary<string, TGroup> _groups;

        protected PlugablePanel(TPanel panel)
        {
            _panel = panel;
            _groups = new Dictionary<string, TGroup>();
        }

        public void Connect(object obj)
        {
            _groups = new Dictionary<string, TGroup>();
            ClearPanel(_panel);

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

                    Type type = typeof(PlugablePanel<TPanel, TGroup, TLabel, TControl>);
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

                    AddEntry(label, control, _panel, socket.Attribute.Group);
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
                                    attribute.GetType().Name, propertyInfo.Name, propertyType.Name));
                        }

                        AddEntry(label, control, _panel, socketAttribute.Group);
                    }
            }
        }

        public void Connect<T>(SocketAdapter<T> socketAdapter)
        {
            _groups = new Dictionary<string, TGroup>();
            ClearPanel(_panel);

            PropertyInfo[] propertyInfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var pair in socketAdapter.SocketAttributes)
            {
                PropertyInfo propertyInfo = pair.Key;
                SocketAttribute attribute = pair.Value;

                TLabel label = CreateLabel(attribute.Name ?? propertyInfo.Name);

                TControl control;
                try
                {
                    control = CreatePlugFromSocketAttribute(socketAdapter.Object, propertyInfo, attribute);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException(
                        string.Format("Attribute {0} is unvalid for the property {1} of type {2}",
                            attribute.GetType().Name, propertyInfo.Name, propertyInfo.PropertyType.Name));
                }

                AddEntry(label, control, _panel, attribute.Group);
            }
        }

        private void AddEntry(TLabel label, TControl control, TPanel panel, string groupName)
        {
            if (groupName != null)
            {
                TGroup targetGroup;

                if (_groups.ContainsKey(groupName))
                    targetGroup = _groups[groupName];
                else
                {
                    TGroup group = CreateGroup(groupName);
                    AddGroupToPanel(panel, group);

                    _groups.Add(groupName, group);
                    targetGroup = group;
                }

                AddLabelToGroup(targetGroup, label);
                AddControlToGroup(targetGroup, control);
            }
            else
            {
                AddLabelToPanel(panel, label);
                AddControlToPanel(panel, control);
            }
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

        static public implicit operator TPanel(PlugablePanel<TPanel, TGroup, TLabel, TControl> value)
        {
            return value._panel;
        }

        protected abstract void ClearPanel(TPanel panel);

        protected abstract TGroup CreateGroup(string name);
        protected abstract TLabel CreateLabel(string text);

        protected abstract void AddGroupToPanel(TPanel panel, TGroup group);

        protected abstract void AddControlToPanel(TPanel panel, TControl control);
        protected abstract void AddLabelToPanel(TPanel panel, TLabel label);

        protected abstract void AddControlToGroup(TGroup group, TControl control);
        protected abstract void AddLabelToGroup(TGroup group, TLabel label);
    }

    public abstract class PlugablePanel<TControlBase>
        : PlugablePanel<TControlBase, TControlBase, TControlBase, TControlBase>
    {
        protected PlugablePanel(TControlBase panel)
            : base(panel) {}

        protected abstract void AddControlToControl(TControlBase parent, TControlBase control);

        protected override void AddGroupToPanel(TControlBase panel, TControlBase group)
        {
            AddControlToControl(panel, group);
        }

        protected override void AddControlToPanel(TControlBase panel, TControlBase control)
        {
            AddControlToControl(panel, control);
        }

        protected override void AddLabelToPanel(TControlBase panel, TControlBase label)
        {
            AddControlToControl(panel, label);
        }

        protected override void AddControlToGroup(TControlBase group, TControlBase control)
        {
            AddControlToControl(group, control);
        }

        protected override void AddLabelToGroup(TControlBase group, TControlBase label)
        {
            AddControlToControl(group, label);
        }
    }
}