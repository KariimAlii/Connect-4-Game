namespace Client
{
    partial class Player
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
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.namebox = new System.Windows.Forms.TextBox();
            this.numberbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.room3 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.room2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.room1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBox
            // 
            this.StatusBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(567, 230);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(2);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(158, 24);
            this.StatusBox.TabIndex = 18;
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ConnectionLabel.Location = new System.Drawing.Point(611, 205);
            this.ConnectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(78, 20);
            this.ConnectionLabel.TabIndex = 17;
            this.ConnectionLabel.Text = "Status";
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DisconnectBtn.BackColor = System.Drawing.Color.IndianRed;
            this.DisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisconnectBtn.Location = new System.Drawing.Point(583, 152);
            this.DisconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(124, 45);
            this.DisconnectBtn.TabIndex = 16;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ConnectBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConnectBtn.Location = new System.Drawing.Point(583, 96);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(124, 45);
            this.ConnectBtn.TabIndex = 15;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(197, 67);
            this.namebox.Margin = new System.Windows.Forms.Padding(4);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(201, 24);
            this.namebox.TabIndex = 19;
            // 
            // numberbox
            // 
            this.numberbox.Location = new System.Drawing.Point(197, 120);
            this.numberbox.Margin = new System.Windows.Forms.Padding(4);
            this.numberbox.Name = "numberbox";
            this.numberbox.Size = new System.Drawing.Size(201, 24);
            this.numberbox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(102, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(98, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Number";
            // 
            // room3
            // 
            this.room3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.room3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.room3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.room3.Location = new System.Drawing.Point(570, 262);
            this.room3.Margin = new System.Windows.Forms.Padding(4);
            this.room3.Name = "room3";
            this.room3.Size = new System.Drawing.Size(88, 28);
            this.room3.TabIndex = 26;
            this.room3.Text = "Room 3";
            this.room3.UseVisualStyleBackColor = false;
            this.room3.Visible = false;
            this.room3.Click += new System.EventHandler(this.room3_Click);
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(43, 26);
            this.listBox3.Margin = new System.Windows.Forms.Padding(4);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(139, 132);
            this.listBox3.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 79);
            this.panel1.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(132, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(510, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Welcome To Connect 4 Game";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(29, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(428, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Please Enter your Name And Number";
            // 
            // room2
            // 
            this.room2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.room2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.room2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.room2.Location = new System.Drawing.Point(337, 262);
            this.room2.Margin = new System.Windows.Forms.Padding(4);
            this.room2.Name = "room2";
            this.room2.Size = new System.Drawing.Size(88, 28);
            this.room2.TabIndex = 25;
            this.room2.Text = "Room 2";
            this.room2.UseVisualStyleBackColor = false;
            this.room2.Visible = false;
            this.room2.Click += new System.EventHandler(this.room2_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(47, 26);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(139, 132);
            this.listBox2.TabIndex = 27;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(45, 26);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 132);
            this.listBox1.TabIndex = 24;
            // 
            // room1
            // 
            this.room1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.room1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.room1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.room1.Location = new System.Drawing.Point(98, 262);
            this.room1.Margin = new System.Windows.Forms.Padding(4);
            this.room1.Name = "room1";
            this.room1.Size = new System.Drawing.Size(88, 28);
            this.room1.TabIndex = 23;
            this.room1.Text = "Room 1";
            this.room1.UseVisualStyleBackColor = false;
            this.room1.Visible = false;
            this.room1.Click += new System.EventHandler(this.room1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.namebox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.numberbox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 170);
            this.panel2.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Location = new System.Drawing.Point(25, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 166);
            this.panel3.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel4.Controls.Add(this.listBox2);
            this.panel4.Location = new System.Drawing.Point(264, 286);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 166);
            this.panel4.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel5.Controls.Add(this.listBox3);
            this.panel5.Location = new System.Drawing.Point(500, 286);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 162);
            this.panel5.TabIndex = 32;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.room3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.room2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.room1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ConnectionLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Player";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.TextBox numberbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button room3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button room2;
        private System.Windows.Forms.Button room1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}

