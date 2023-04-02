
namespace XMLCardParser
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.aboutNameLabel = new System.Windows.Forms.Label();
            this.aboutVersionLabel = new System.Windows.Forms.Label();
            this.aboutMainTextLabel = new System.Windows.Forms.Label();
            this.aboutProgrammerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aboutNameLabel
            // 
            this.aboutNameLabel.AutoSize = true;
            this.aboutNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutNameLabel.Location = new System.Drawing.Point(59, 27);
            this.aboutNameLabel.Name = "aboutNameLabel";
            this.aboutNameLabel.Size = new System.Drawing.Size(196, 37);
            this.aboutNameLabel.TabIndex = 0;
            this.aboutNameLabel.Text = "XMLCardParser";
            // 
            // aboutVersionLabel
            // 
            this.aboutVersionLabel.AutoSize = true;
            this.aboutVersionLabel.Location = new System.Drawing.Point(171, 64);
            this.aboutVersionLabel.Name = "aboutVersionLabel";
            this.aboutVersionLabel.Size = new System.Drawing.Size(79, 15);
            this.aboutVersionLabel.TabIndex = 1;
            this.aboutVersionLabel.Text = "Alpha vesrion";
            // 
            // aboutMainTextLabel
            // 
            this.aboutMainTextLabel.Location = new System.Drawing.Point(29, 106);
            this.aboutMainTextLabel.Name = "aboutMainTextLabel";
            this.aboutMainTextLabel.Size = new System.Drawing.Size(273, 40);
            this.aboutMainTextLabel.TabIndex = 2;
            this.aboutMainTextLabel.Text = "Программа для чтения карточек лесопатологической таксации в формате XML";
            // 
            // aboutProgrammerLabel
            // 
            this.aboutProgrammerLabel.AutoSize = true;
            this.aboutProgrammerLabel.Location = new System.Drawing.Point(88, 174);
            this.aboutProgrammerLabel.Name = "aboutProgrammerLabel";
            this.aboutProgrammerLabel.Size = new System.Drawing.Size(128, 15);
            this.aboutProgrammerLabel.TabIndex = 3;
            this.aboutProgrammerLabel.Text = "2023 Дмитрий Бобров";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 221);
            this.Controls.Add(this.aboutProgrammerLabel);
            this.Controls.Add(this.aboutMainTextLabel);
            this.Controls.Add(this.aboutVersionLabel);
            this.Controls.Add(this.aboutNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 260);
            this.Name = "About";
            this.Text = "О программе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aboutNameLabel;
        private System.Windows.Forms.Label aboutVersionLabel;
        private System.Windows.Forms.Label aboutMainTextLabel;
        private System.Windows.Forms.Label aboutProgrammerLabel;
    }
}