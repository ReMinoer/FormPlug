using System;
using System.Reflection;
using System.Windows.Forms;
using FormPlug.Test;
using FormPlug.WindowsForm.Plugs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.WindowsForm.Test
{
    [TestClass]
    public class WindowsFormPlugTest
    {
        [TestMethod]
        public void NumericPlug()
        {
            PlugTestHelper.PlugTest<TestObject, NumericPlug<int>, int, NumericUpDown>(0, 1);
        }

        [TestMethod]
        public void TextPlug()
        {
            PlugTestHelper.PlugTest<TestObject, TextPlug, string, TextBox>("", "text");
        }

        [TestMethod]
        public void BooleanPlug()
        {
            PlugTestHelper.PlugTest<TestObject, BooleanPlug, bool, CheckBox>(false, true);
        }

        [TestMethod]
        public void EnumPlug()
        {
            PlugTestHelper.PlugTest<TestObject, EnumPlug<TestEnum>, TestEnum, ComboBox>(TestEnum.No, TestEnum.Yes);
        }

        [TestMethod]
        public void DateTimePlug()
        {
            PlugTestHelper.PlugTest<TestObject, DateTimePlug, DateTime, DateTimePicker>(DateTime.Now, DateTime.Today);
        }
    }
}