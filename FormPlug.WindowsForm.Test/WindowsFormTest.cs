using System;
using System.Drawing;
using System.Windows.Forms;
using FormPlug.TestHelper;
using FormPlug.WindowsForm.Controls;
using FormPlug.WindowsForm.Plugs;
using NUnit.Framework;

namespace FormPlug.WindowsForm.Test
{
    [TestFixture]
    public class WindowsFormPlugTest
    {
        [Test]
        public void BooleanPlug()
        {
            PlugTestHelper.PlugTest<TestObject, BooleanPlug, bool, BooleanSocketAttribute, CheckBox>(false, true);
        }

        [Test]
        public void ColorPlug()
        {
            PlugTestHelper.PlugTest<TestObject, ColorPlug, Color, ColorSocketAttribute, ColorDialogButton>(Color.White,
                Color.Black);
        }

        [Test]
        public void DateTimePlug()
        {
            PlugTestHelper.PlugTest<TestObject, DateTimePlug, DateTime, DateTimeSocketAttribute, DateTimePicker>(
                DateTime.Now, DateTime.Now.AddDays(1));
        }

        [Test]
        public void EnumPlug()
        {
            PlugTestHelper.PlugTest<TestObject, EnumPlug<TestEnum>, TestEnum, EnumSocketAttribute, ComboBox>(
                TestEnum.No, TestEnum.Yes);
        }

        [Test]
        public void FilePlug()
        {
            PlugTestHelper.PathPlugTest<TestObject, FilePlug, FileSocketAttribute, FileDialogButton>("txt");
        }

        [Test]
        public void FolderPlug()
        {
            PlugTestHelper.PlugTest<TestObject, FolderPlug, string, FolderSocketAttribute, FolderDialogButton>(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        [Test]
        public void ImagePlug()
        {
            PlugTestHelper.PathPlugTest<TestObject, ImagePlug, ImageSocketAttribute, ImageDialogButton>("jpg");
        }

        [Test]
        public void NumericPlug()
        {
            PlugTestHelper.PlugTest<TestObject, NumericPlug<int>, int, NumericSocketAttribute, NumericUpDown>(0, 1);
        }

        [Test]
        public void TextPlug()
        {
            PlugTestHelper.PlugTest<TestObject, TextPlug, string, TextSocketAttribute, TextBox>("", "text");
        }
    }
}