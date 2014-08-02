namespace FormPlug.WindowsForm.Controls
{
    partial class ColorDialogButton
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.White;
            this.button.Location = new System.Drawing.Point(4, 4);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(95, 55);
            this.button.TabIndex = 0;
            this.button.Text = "255, 255, 255";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // ColorDialogButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button);
            this.Name = "ColorDialogButton";
            this.Size = new System.Drawing.Size(104, 64);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
    }
}
