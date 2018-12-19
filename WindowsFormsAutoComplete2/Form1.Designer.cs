namespace WindowsFormsAutoComplete2
{
    partial class Form1
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
            this.personalUrisTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // personalUrisTextBox
            // 
            this.personalUrisTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.personalUrisTextBox.Location = new System.Drawing.Point(56, 108);
            this.personalUrisTextBox.Name = "personalUrisTextBox";
            this.personalUrisTextBox.Size = new System.Drawing.Size(597, 26);
            this.personalUrisTextBox.TabIndex = 0;
            this.personalUrisTextBox.TextChanged += new System.EventHandler(this.personalUrisTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.personalUrisTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox personalUrisTextBox;
    }
}

