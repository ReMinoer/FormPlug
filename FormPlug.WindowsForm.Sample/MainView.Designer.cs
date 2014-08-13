namespace FormPlug.WindowsForm.Sample
{
    partial class MainView
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
            this.buttonAutoPlugPanel = new System.Windows.Forms.Button();
            this.buttonPlugablePanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAutoPlugPanel
            // 
            this.buttonAutoPlugPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoPlugPanel.Location = new System.Drawing.Point(12, 12);
            this.buttonAutoPlugPanel.Name = "buttonAutoPlugPanel";
            this.buttonAutoPlugPanel.Size = new System.Drawing.Size(310, 40);
            this.buttonAutoPlugPanel.TabIndex = 0;
            this.buttonAutoPlugPanel.Text = "AutoPlugPanel";
            this.buttonAutoPlugPanel.UseVisualStyleBackColor = true;
            // 
            // buttonPlugablePanel
            // 
            this.buttonPlugablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlugablePanel.Location = new System.Drawing.Point(12, 58);
            this.buttonPlugablePanel.Name = "buttonPlugablePanel";
            this.buttonPlugablePanel.Size = new System.Drawing.Size(310, 40);
            this.buttonPlugablePanel.TabIndex = 1;
            this.buttonPlugablePanel.Text = "PlugablePanel";
            this.buttonPlugablePanel.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.buttonPlugablePanel);
            this.Controls.Add(this.buttonAutoPlugPanel);
            this.Name = "MainView";
            this.Text = "FormPlug - Windows Form Samples";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAutoPlugPanel;
        private System.Windows.Forms.Button buttonPlugablePanel;
    }
}