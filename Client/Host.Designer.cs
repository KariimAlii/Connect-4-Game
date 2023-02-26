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
            this.SuspendLayout();
            // 
            // StatusBox
            // 
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(102, 406);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(200, 24);
            this.StatusBox.TabIndex = 18;
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnectionLabel.Location = new System.Drawing.Point(27, 408);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(69, 20);
            this.ConnectionLabel.TabIndex = 17;
            this.ConnectionLabel.Text = "Status:";
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.BackColor = System.Drawing.Color.IndianRed;
            this.DisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisconnectBtn.Location = new System.Drawing.Point(635, 76);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(138, 41);
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
            this.ConnectBtn.Location = new System.Drawing.Point(635, 21);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(138, 37);
            this.ConnectBtn.TabIndex = 15;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
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
    }
}

