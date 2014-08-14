using System;
using System.Drawing;
using System.Windows.Forms;
using FormPlug.TestHelper;
using FormPlug.WindowsForm.Controls;
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
            PlugTestHelper.PlugTest<TestObject, NumericPlug<int>, int, NumericSocketAttribute, NumericUpDown>(0, 1);
        }

        [TestMethod]
        public void TextPlug()
        {
            PlugTestHelper.PlugTest<TestObject, TextPlug, string, TextSocketAttribute, TextBox>("", "text");
        }

        [TestMethod]
        public void BooleanPlug()
        {
            PlugTestHelper.PlugTest<TestObject, BooleanPlug, bool, BooleanSocketAttribute, CheckBox>(false, true);
        }

        [TestMethod]
        public void EnumPlug()
        {
            PlugTestHelper.PlugTest<TestObject, EnumPlug<TestEnum>, TestEnum, EnumSocketAttribute, ComboBox>(
                TestEnum.No, TestEnum.Yes);
        }

        [TestMethod]
        public void ColorPlug()
        {
            PlugTestHelper.PlugTest<TestObject, ColorPlug, Color, ColorSocketAttribute, ColorDialogButton>(Color.White,
                Color.Black);
        }

        [TestMethod]
        public void DateTimePlug()
        {
            PlugTestHelper.PlugTest<TestObject, DateTimePlug, DateTime, DateTimeSocketAttribute, DateTimePicker>(
                DateTime.Now, DateTime.Now.AddDays(1));
        }

        [TestMethod]
        public void FilePlug()
        {
            PlugTestHelper.PathPlugTest<TestObject, FilePlug, FileSocketAttribute, FileDialogButton>("txt");
        }

        [TestMethod]
        public void FolderPlug()
        {
            PlugTestHelper.PlugTest<TestObject, FolderPlug, string, FolderSocketAttribute, FolderDialogButton>(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        [TestMethod]
        public void ImagePlug()
        {
            PlugTestHelper.PathPlugTest<TestObject, ImagePlug, ImageSocketAttribute, ImageDialogButton>("jpg");
        }
    }
}