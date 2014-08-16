namespace FormPlug.WindowsForm.Sample
{
    partial class PlugablePanelView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.folderDialogButton1 = new FormPlug.WindowsForm.Controls.FolderDialogButton();
            this.fileDialogButton1 = new FormPlug.WindowsForm.Controls.FileDialogButton();
            this.colorDialogButton1 = new FormPlug.WindowsForm.Controls.ColorDialogButton();
            this.imageDialogButton1 = new FormPlug.WindowsForm.Controls.ImageDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(12, 35);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(137, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(12, 61);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(137, 20);
            this.numericUpDown2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 10);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(219, 170);
            this.textBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 186);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // folderDialogButton1
            // 
            this.folderDialogButton1.Folder = null;
            this.folderDialogButton1.Location = new System.Drawing.Point(11, 248);
            this.folderDialogButton1.MaximumSize = new System.Drawing.Size(400, 30);
            this.folderDialogButton1.MinimumSize = new System.Drawing.Size(100, 30);
            this.folderDialogButton1.Name = "folderDialogButton1";
            this.folderDialogButton1.Size = new System.Drawing.Size(200, 30);
            this.folderDialogButton1.TabIndex = 8;
            // 
            // fileDialogButton1
            // 
            this.fileDialogButton1.File = null;
            this.fileDialogButton1.Location = new System.Drawing.Point(11, 212);
            this.fileDialogButton1.MaximumSize = new System.Drawing.Size(400, 30);
            this.fileDialogButton1.MinimumSize = new System.Drawing.Size(100, 30);
            this.fileDialogButton1.Name = "fileDialogButton1";
            this.fileDialogButton1.Size = new System.Drawing.Size(200, 30);
            this.fileDialogButton1.TabIndex = 7;
            // 
            // colorDialogButton1
            // 
            this.colorDialogButton1.Color = System.Drawing.Color.Empty;
            this.colorDialogButton1.Location = new System.Drawing.Point(12, 140);
            this.colorDialogButton1.MaximumSize = new System.Drawing.Size(125, 40);
            this.colorDialogButton1.MinimumSize = new System.Drawing.Size(125, 40);
            this.colorDialogButton1.Name = "colorDialogButton1";
            this.colorDialogButton1.Size = new System.Drawing.Size(125, 40);
            this.colorDialogButton1.TabIndex = 6;
            // 
            // imageDialogButton1
            // 
            this.imageDialogButton1.Image = null;
            this.imageDialogButton1.Location = new System.Drawing.Point(218, 186);
            this.imageDialogButton1.Name = "imageDialogButton1";
            this.imageDialogButton1.Size = new System.Drawing.Size(156, 90);
            this.imageDialogButton1.TabIndex = 10;
            // 
            // PlugablePanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 288);
            this.Controls.Add(this.imageDialogButton1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.folderDialogButton1);
            this.Controls.Add(this.fileDialogButton1);
            this.Controls.Add(this.colorDialogButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "PlugablePanelView";
            this.Text = "PlugablePanelView";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private Controls.ColorDialogButton colorDialogButton1;
        private Controls.FileDialogButton fileDialogButton1;
        private Controls.FolderDialogButton folderDialogButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Controls.ImageDialogButton imageDialogButton1;
    }
}