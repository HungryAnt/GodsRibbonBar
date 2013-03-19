namespace TestWindow
{
    partial class FormWithRibbonMenu
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
            this.ribbonBarControl = new TestWindow.Ribbon.RibbonBarControl();
            this.SuspendLayout();
            // 
            // ribbonBarControl
            // 
            this.ribbonBarControl.Location = new System.Drawing.Point(12, 1);
            this.ribbonBarControl.Name = "ribbonBarControl";
            this.ribbonBarControl.RibbonBar = null;
            this.ribbonBarControl.Size = new System.Drawing.Size(567, 137);
            this.ribbonBarControl.TabIndex = 0;
            // 
            // FormWithRibbonMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 225);
            this.Controls.Add(this.ribbonBarControl);
            this.Name = "FormWithRibbonMenu";
            this.Text = "FormWithRibbonMenu";
            this.Load += new System.EventHandler(this.FormWithRibbonMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TestWindow.Ribbon.RibbonBarControl ribbonBarControl;

    }
}