
namespace chatroom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.submit = new System.Windows.Forms.Button();
            this.testlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.port2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.portui = new System.Windows.Forms.NumericUpDown();
            this.UserBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.messbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portui)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.submit.Location = new System.Drawing.Point(46, 244);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 3;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.enterchat);
            // 
            // testlabel
            // 
            this.testlabel.AutoSize = true;
            this.testlabel.Location = new System.Drawing.Point(255, 322);
            this.testlabel.Name = "testlabel";
            this.testlabel.Size = new System.Drawing.Size(0, 15);
            this.testlabel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.port2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB);
            this.groupBox1.Controls.Add(this.portui);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(46, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 206);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Username";
            // 
            // TB
            // 
            this.TB.Location = new System.Drawing.Point(6, 39);
            this.TB.Name = "TB";
            this.TB.Size = new System.Drawing.Size(159, 23);
            this.TB.TabIndex = 10;
            this.TB.Text = "DefaultUser";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(6, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Partner Port";
            // 
            // port2
            // 
            this.port2.Location = new System.Drawing.Point(6, 147);
            this.port2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.port2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.port2.Name = "port2";
            this.port2.Size = new System.Drawing.Size(120, 23);
            this.port2.TabIndex = 14;
            this.port2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // portui
            // 
            this.portui.Location = new System.Drawing.Point(6, 92);
            this.portui.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.portui.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portui.Name = "portui";
            this.portui.Size = new System.Drawing.Size(120, 23);
            this.portui.TabIndex = 11;
            this.portui.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UserBox
            // 
            this.UserBox.FormattingEnabled = true;
            this.UserBox.ItemHeight = 15;
            this.UserBox.Location = new System.Drawing.Point(11, 21);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(181, 169);
            this.UserBox.TabIndex = 11;
            this.UserBox.DoubleClick += new System.EventHandler(this.requestUser);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Join";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.refresh);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Accept";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.YesButton);
            // 
            // messbox
            // 
            this.messbox.Location = new System.Drawing.Point(11, 303);
            this.messbox.Name = "messbox";
            this.messbox.Size = new System.Drawing.Size(100, 23);
            this.messbox.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(126, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "enter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.bp);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.UserBox);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.messbox);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(592, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 348);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connect Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Message";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(142, 244);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.usersub);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(852, 515);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.testlabel);
            this.Controls.Add(this.submit);
            this.MaximumSize = new System.Drawing.Size(868, 868);
            this.MinimumSize = new System.Drawing.Size(635, 39);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portui)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label testlabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB;
        private System.Windows.Forms.NumericUpDown portui;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown port2;
        private System.Windows.Forms.ListBox UserBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox messbox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
    }
}

