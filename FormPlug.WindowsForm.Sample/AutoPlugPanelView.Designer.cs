namespace FormPlug.WindowsForm.Sample
{
    partial class AutoPlugPanelView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.externalButton = new System.Windows.Forms.Button();
            this.parentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.displayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // externalButton
            // 
            this.externalButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.externalButton.Location = new System.Drawing.Point(107, 375);
            this.externalButton.Name = "externalButton";
            this.externalButton.Size = new System.Drawing.Size(108, 29);
            this.externalButton.TabIndex = 1;
            this.externalButton.Text = "External change";
            this.externalButton.UseVisualStyleBackColor = true;
            // 
            // parentPanel
            // 
            this.parentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parentPanel.AutoScroll = true;
            this.parentPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.parentPanel.Location = new System.Drawing.Point(0, 0);
            this.parentPanel.Name = "parentPanel";
            this.parentPanel.Size = new System.Drawing.Size(472, 369);
            this.parentPanel.TabIndex = 2;
            // 
            // displayButton
            // 
            this.displayButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.displayButton.Location = new System.Drawing.Point(221, 375);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(108, 29);
            this.displayButton.TabIndex = 3;
            this.displayButton.Text = "Display TestObject";
            this.displayButton.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 416);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.parentPanel);
            this.Controls.Add(this.externalButton);
            this.Name = "MainView";
            this.Text = "FormPlug - Windows Form Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button externalButton;
        private System.Windows.Forms.FlowLayoutPanel parentPanel;
        private System.Windows.Forms.Button displayButton;
    }
}

