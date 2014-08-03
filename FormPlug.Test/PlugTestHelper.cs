using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.Test
{
    static public class PlugTestHelper
    {
        static public void PlugTest<TObject, TPlug, TValue, TAttribute, TControl>(TValue initValue, TValue newValue,
                                                                                  Action initAction = null,
                                                                                  Action endAction = null)
            where TPlug : Plug<TValue, TControl, TAttribute>, new() where TObject : new()
            where TAttribute : SocketAttribute where TControl : new()
        {
            if (initValue.Equals(newValue))
                Assert.Inconclusive("initValue & newValue can't be equals !");

            PlugValueChangedWithSocket<TPlug, TValue, TControl>(initValue, newValue, initAction, endAction);
            SocketValueChangedWithSocket<TPlug, TValue, TControl>(initValue, newValue, initAction, endAction);

            var obj = new TObject();

            PropertyInfo[] tab = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (PropertyInfo propertyType in tab)
                if (propertyType.GetCustomAttribute<TAttribute>() != null)
                {
                    PlugValueChangedWithAttribute<TPlug, TValue, TControl>(obj, propertyType, initValue, newValue,
                        initAction, endAction);
                    SocketValueChangedWithAttribute<TPlug, TValue, TControl>(obj, propertyType, initValue, newValue,
                        initAction, endAction);
                    return;
                }

            Assert.Inconclusive("{0} doesn't contains property with attribute of this type {1}", typeof(TObject).Name,
                typeof(TAttribute).Name);
        }

        static private void PlugValueChangedWithSocket<TPlug, TValue, TControl>(TValue initValue, TValue newValue,
                                                                                Action initAction = null,
                                                                                Action endAction = null)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            try
            {
                if (initAction != null)
                    initAction();

                var socket = new Socket<TValue> {Value = initValue};

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

        static private void SocketValueChangedWithSocket<TPlug, TValue, TControl>(TValue initValue, TValue newValue,
                                                                                  Action initAction = null,
                                                                                  Action endAction = null)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            try
            {
                if (initAction != null)
                    initAction();

                var socket = new Socket<TValue> {Value = initValue};

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