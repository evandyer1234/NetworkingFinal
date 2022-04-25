
namespace chatroom
{
    partial class Form2
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
            this.LB = new System.Windows.Forms.ListBox();
            this.tb = new System.Windows.Forms.TextBox();
            this.enterbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB
            // 
            this.LB.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LB.ForeColor = System.Drawing.SystemColors.Menu;
            this.LB.FormattingEnabled = true;
            this.LB.ItemHeight = 15;
            this.LB.Location = new System.Drawing.Point(12, 12);
            this.LB.Name = "LB";
            this.LB.Size = new System.Drawing.Size(758, 319);
            this.LB.TabIndex = 0;
            // 
            // tb
            // 
            this.tb.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tb.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.tb.Location = new System.Drawing.Point(12, 364);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(663, 23);
            this.tb.TabIndex = 1;
            // 
            // enterbutton
            // 
            this.enterbutton.Location = new System.Drawing.Point(702, 364);
            this.enterbutton.Name = "enterbutton";
            this.enterbutton.Size = new System.Drawing.Size(75, 23);
            this.enterbutton.TabIndex = 2;
            this.enterbutton.Text = "Enter";
            this.enterbutton.UseVisualStyleBackColor = true;
            this.enterbutton.Click += new System.EventHandler(this.EnterPressed);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Leave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Leavebtn);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enterbutton);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.LB);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Button enterbutton;
        private System.Windows.Forms.Button button1;
    }
}