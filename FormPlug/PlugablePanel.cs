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
                foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (!(attribute is SocketAttribute))
                        continue;

                    AddLabel(panel, propertyInfo.Name);
                    AddPlug(panel, obj, propertyInfo, attribute as SocketAttribute);
                }
        }

        protected abstract TPanel CreatePanel(TParent parent);
        protected abstract void AddLabel(TPanel panel, string text);
        protected abstract void AddPlug(TPanel panel, object obj, PropertyInfo propertyInfo, SocketAttribute attribute);
    }
}