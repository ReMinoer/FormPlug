using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.TestHelper
{
    static public class PlugTestHelper
    {
        static public void PlugTest<TObject, TPlug, TValue, TAttribute, TControl>(TValue initValue, TValue newValue,
                                                                                  Action initAction = null,
                                                                                  Action endAction = null)
            where TPlug : Plug<TValue, TControl, TAttribute>, new() where TObject : new()
            where TAttribute : SocketAttribute, new() where TControl : new()
        {
            if (initValue.Equals(newValue))
                Assert.Inconclusive("initValue & newValue can't be equals !");

            var obj = new TObject();

            PropertyInfo[] tab =
                obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            bool ok = false;
            foreach (PropertyInfo property in tab)
            {
                Type type = property.PropertyType;
                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Socket<>))
                    continue;
                if (type.GenericTypeArguments[0] != typeof(TValue))
                    continue;

                var socket = (Socket<TValue>)property.GetValue(obj);
                if (!(socket.Attribute is TAttribute))
                    continue;

                PlugValueChangedWithSocket<TPlug, TValue, TControl>(socket, initValue, newValue, initAction, endAction);
                SocketValueChangedWithSocket<TPlug, TValue, TControl>(socket, initValue, newValue, initAction, endAction);
                ok = true;
                break;
            }

            if (!ok)
                Assert.Inconclusive(
                    "{0} doesn't contains property of this type Socket<{1}> with Attribute property of type {2}",
                    typeof(TObject).Name, typeof(TValue).Name, typeof(TAttribute).Name);

            ok = false;
            foreach (PropertyInfo propertyType in tab)
            {
                if (propertyType.GetCustomAttribute<TAttribute>() == null)
                    continue;

                PlugValueChangedWithAttribute<TPlug, TValue, TControl>(obj, propertyType, initValue, newValue,
                    initAction, endAction);
                SocketValueChangedWithAttribute<TPlug, TValue, TControl>(obj, propertyType, initValue, newValue,
                    initAction, endAction);
                ok = true;
                break;
            }

            if (!ok)
                Assert.Inconclusive("{0} doesn't contains property with attribute of this type {1}",
                    typeof(TObject).Name, typeof(TAttribute).Name);
        }

        static private void PlugValueChangedWithSocket<TPlug, TValue, TControl>(Socket<TValue> socket, TValue initValue,
                                                                                TValue newValue,
                                                                                Action initAction = null,
                                                                                Action endAction = null)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            try
            {
                if (initAction != null)
                    initAction();

                socket.Value = initValue;

                var plug = new TPlug();
                plug.Connect(socket);

                plug.Value = newValue;

                Assert.AreEqual(socket.Value, newValue);
            }
            finally
            {
                if (endAction != null)
                    endAction();
            }
        }

        static private void PlugValueChangedWithAttribute<TPlug, TValue, TControl>(object obj, PropertyInfo propertyInfo,
                                                                                   TValue initValue, TValue newValue,
                                                                                   Action initAction = null,
                                                                                   Action endAction = null)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            try
            {
                if (initAction != null)
                    initAction();

                propertyInfo.SetValue(obj, initValue);

                var plug = new TPlug();
                plug.Connect(obj, propertyInfo);

                plug.Value = newValue;

                Assert.AreEqual(propertyInfo.GetValue(obj), newValue);
            }
            finally
            {
                if (endAction != null)
                    endAction();
            }
        }

        static private void SocketValueChangedWithSocket<TPlug, TValue, TControl>(Socket<TValue> socket,
                                                                                  TValue initValue, TValue newValue,
                                                                                  Action initAction = null,
                                                                                  Action endAction = null)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            try
            {
                if (initAction != null)
                    initAction();

                socket.Value = initValue;

                var plug = new TPlug();
                plug.Connect(socket);

                socket.Value = newValue;

                Assert.AreEqual(plug.Value, newValue);
            }
            finally
            {
                if (endAction != null)
                    endAction();
            }
        }

        static private void SocketValueChangedWithAttribute<TPlug, TValue, TControl>(object obj,
                                                                                     PropertyInfo propertyInfo,
                                                                                     TValue initValue, TValue newValue,
                                                                                     Action initAction = null,
                                                                                     Action endAction = null)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            try
            {
                if (initAction != null)
                    initAction();

                propertyInfo.SetValue(obj, initValue);

                var plug = new TPlug();
                plug.Connect(obj, propertyInfo);

                propertyInfo.SetValue(obj, newValue);

                Assert.AreEqual(plug.Value, newValue);
            }
            finally
            {
                if (endAction != null)
                    endAction();
            }
        }
    }
}