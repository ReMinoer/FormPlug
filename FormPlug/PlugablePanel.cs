using System;
using System.Reflection;

namespace FormPlug
{
    public abstract class PlugablePanel<TParent, TPanel>
    {
        private readonly TParent _parent;

        protected PlugablePanel(TParent parent)
        {
            _parent = parent;
        }

        public void CreatePanel(object obj)
        {
            TPanel panel = CreatePanel(_parent);

            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Socket<>))
                {
                    var socket = (ISocket)propertyInfo.GetValue(obj);
                    Type genericTypeArgument = propertyType.GenericTypeArguments[0];

                    AddLabel(panel, propertyInfo.Name);
                    AddSocket(panel, socket, genericTypeArgument);
                }
                else
                    foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                    {
                        if (!(attribute is SocketAttribute))
                            continue;

                        AddLabel(panel, propertyInfo.Name);
                        AddSocketAttribute(panel, obj, propertyInfo, attribute as SocketAttribute);
                    }
            }
        }

        protected abstract TPanel CreatePanel(TParent parent);
        protected abstract void AddLabel(TPanel panel, string text);
        protected abstract void AddSocket(TPanel panel, ISocket socket, Type genericTypeArgument);

        protected abstract void AddSocketAttribute(TPanel panel, object obj, PropertyInfo propertyInfo,
                                                   SocketAttribute attribute);
    }
}