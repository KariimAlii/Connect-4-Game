namespace Client
{
    partial class Host
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
            this.room1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.room2 = new System.Windows.Forms.Button();
            this.room3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusBox
            // 
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(76, 330);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(2);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(151, 21);
            this.StatusBox.TabIndex = 18;
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnectionLabel.Location = new System.Drawing.Point(20, 332);
            this.ConnectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(59, 17);
            this.ConnectionLabel.TabIndex = 17;
            this.ConnectionLabel.Text = "Status:";
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.BackColor = System.Drawing.Color.IndianRed;
            this.DisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisconnectBtn.Location = new System.Drawing.Point(476, 62);
            this.DisconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(104, 33);
            this.DisconnectBtn.TabIndex = 16;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConnectBtn.Location = new System.Drawing.Point(476, 17);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(104, 30);
            this.ConnectBtn.TabIndex = 15;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(76, 31);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(173, 20);
            this.namebox.TabIndex = 19;
            // 
            // numberbox
            // 
            this.numberbox.Location = new System.Drawing.Point(76, 70);
            this.numberbox.Name = "numberbox";
            this.numberbox.Size = new System.Drawing.Size(173, 20);
            this.numberbox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Number";
            // 
            // room1
            // 
            this.room1.Location = new System.Drawing.Point(119, 114);
            this.room1.Name = "room1";
            this.room1.Size = new System.Drawing.Size(75, 23);
            this.room1.TabIndex = 23;
            this.room1.Text = "Room 1";
            this.room1.UseVisualStyleBackColor = true;
            this.room1.Visible = false;
            this.room1.Click += new System.EventHandler(this.room1_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(107, 143);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 24;
            // 
            // room2
            // 
            this.room2.Location = new System.Drawing.Point(230, 114);
            this.room2.Name = "room2";
            this.room2.Size = new System.Drawing.Size(75, 23);
            this.room2.TabIndex = 25;
            this.room2.Text = "Room 2";
            this.room2.UseVisualStyleBackColor = true;
            this.room2.Visible = false;
            this.room2.Click += new System.EventHandler(this.room2_Click);
            // 
            // room3
            // 
            this.room3.Location = new System.Drawing.Point(333, 114);
            this.room3.Name = "room3";
            this.room3.Size = new System.Drawing.Size(75, 23);
            this.room3.TabIndex = 26;
            this.room3.Text = "Room 3";
            this.room3.UseVisualStyleBackColor = true;
            this.room3.Visible = false;
            this.room3.Click += new System.EventHandler(this.room3_Click);
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.room3);
            this.Controls.Add(this.room2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.room1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberbox);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Host";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button room1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button room2;
        private System.Windows.Forms.Button room3;
    }
}

