namespace Connect4Game
{
    partial class Server
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
            this.StopBtn = new System.Windows.Forms.Button();
            this.ListenBtn = new System.Windows.Forms.Button();
            this.clients_list = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.last_played_list = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBox
            // 
            this.StatusBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(30, 228);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(151, 21);
            this.StatusBox.TabIndex = 10;
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.Black;
            this.ConnectionLabel.Location = new System.Drawing.Point(63, 196);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(74, 19);
            this.ConnectionLabel.TabIndex = 9;
            this.ConnectionLabel.Text = "Status";
            // 
            // StopBtn
            // 
            this.StopBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StopBtn.BackColor = System.Drawing.Color.IndianRed;
            this.StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StopBtn.Location = new System.Drawing.Point(66, 136);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(85, 33);
            this.StopBtn.TabIndex = 12;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ListenBtn
            // 
            this.ListenBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ListenBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.ListenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListenBtn.Location = new System.Drawing.Point(66, 51);
            this.ListenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(85, 30);
            this.ListenBtn.TabIndex = 11;
            this.ListenBtn.Text = "Start";
            this.ListenBtn.UseVisualStyleBackColor = false;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // clients_list
            // 
            this.clients_list.FormattingEnabled = true;
            this.clients_list.Location = new System.Drawing.Point(23, 47);
            this.clients_list.Name = "clients_list";
            this.clients_list.Size = new System.Drawing.Size(157, 225);
            this.clients_list.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 81);
            this.panel1.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(221, 81);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 81);
            this.panel4.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(20, 86);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 135);
            this.panel2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome To Server Main Page";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = global::Connect4Game.Properties.Resources._1707222;
            this.pictureBox1.Image = global::Connect4Game.Properties.Resources._1707222;
            this.pictureBox1.InitialImage = global::Connect4Game.Properties.Resources._1707222;
            this.pictureBox1.Location = new System.Drawing.Point(517, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.clients_list);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 285);
            this.panel3.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "List Of Players";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SlateGray;
            this.panel5.Controls.Add(this.last_played_list);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(421, 81);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(201, 285);
            this.panel5.TabIndex = 18;
            // 
            // last_played_list
            // 
            this.last_played_list.FormattingEnabled = true;
            this.last_played_list.Location = new System.Drawing.Point(26, 47);
            this.last_played_list.Name = "last_played_list";
            this.last_played_list.Size = new System.Drawing.Size(157, 225);
            this.last_played_list.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Last Played";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.ConnectionLabel);
            this.panel6.Controls.Add(this.StopBtn);
            this.panel6.Controls.Add(this.StatusBox);
            this.panel6.Controls.Add(this.ListenBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(209, 81);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(212, 285);
            this.panel6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Stop Server";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Start Server";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(622, 366);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Server";
            this.Text = "Server";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.ListBox clients_list;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox last_played_list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}