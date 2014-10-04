using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using FormPlug.SocketAttributes;

namespace FormPlug
{
    public class SocketAdapter<T>
    {
        public T Object { get; private set; }

        public ReadOnlyDictionary<PropertyInfo, SocketAttribute> SocketAttributes
        {
            get { return new ReadOnlyDictionary<PropertyInfo, SocketAttribute>(_socketAttributes); }
        }

        private readonly Dictionary<PropertyInfo, SocketAttribute> _socketAttributes;

        public SocketAdapter(T obj)
        {
            Object = obj;
            _socketAttributes = new Dictionary<PropertyInfo, SocketAttribute>();
        }

        public void AddProperty(string name, SocketAttribute socketAttribute)
        {
            PropertyInfo[] propertyInfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (propertyInfos.All(p => p.Name != name))
                throw new ArgumentException(string.Format("{0} is not a property of {1}", name, typeof(T).Name));

            PropertyInfo propertyInfo = propertyInfos.First(p => p.Name == name);

            _socketAttributes.Add(propertyInfo, socketAttribute);
        }
    }
}