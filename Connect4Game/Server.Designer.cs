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
            this.connected_clients = new System.Windows.Forms.Button();
            this.OpenGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusBox
            // 
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Location = new System.Drawing.Point(307, 282);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(200, 24);
            this.StatusBox.TabIndex = 10;
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnectionLabel.Location = new System.Drawing.Point(232, 284);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(69, 20);
            this.ConnectionLabel.TabIndex = 9;
            this.ConnectionLabel.Text = "Status:";
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.Color.IndianRed;
            this.StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StopBtn.Location = new System.Drawing.Point(655, 79);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(113, 41);
            this.StopBtn.TabIndex = 12;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ListenBtn
            // 
            this.ListenBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.ListenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListenBtn.Location = new System.Drawing.Point(655, 36);
            this.ListenBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(113, 37);
            this.ListenBtn.TabIndex = 11;
            this.ListenBtn.Text = "Start";
            this.ListenBtn.UseVisualStyleBackColor = false;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // clients_list
            // 
            this.clients_list.FormattingEnabled = true;
            this.clients_list.ItemHeight = 16;
            this.clients_list.Location = new System.Drawing.Point(127, 53);
            this.clients_list.Margin = new System.Windows.Forms.Padding(4);
            this.clients_list.Name = "clients_list";
            this.clients_list.Size = new System.Drawing.Size(161, 116);
            this.clients_list.TabIndex = 13;
            // 
            // connected_clients
            // 
            this.connected_clients.Location = new System.Drawing.Point(332, 251);
            this.connected_clients.Margin = new System.Windows.Forms.Padding(4);
            this.connected_clients.Name = "connected_clients";
            this.connected_clients.Size = new System.Drawing.Size(145, 25);
            this.connected_clients.TabIndex = 14;
            this.connected_clients.Text = "connected_clients";
            this.connected_clients.UseVisualStyleBackColor = true;
            this.connected_clients.Click += new System.EventHandler(this.connected_clients_Click);
            // 
            // OpenGame
            // 
            this.OpenGame.Location = new System.Drawing.Point(618, 300);
            this.OpenGame.Name = "OpenGame";
            this.OpenGame.Size = new System.Drawing.Size(75, 23);
            this.OpenGame.TabIndex = 15;
            this.OpenGame.Text = "Game";
            this.OpenGame.UseVisualStyleBackColor = true;
            this.OpenGame.Click += new System.EventHandler(this.OpenGame_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenGame);
            this.Controls.Add(this.connected_clients);
            this.Controls.Add(this.clients_list);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.ListenBtn);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ConnectionLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.ListBox clients_list;
        private System.Windows.Forms.Button connected_clients;
        private System.Windows.Forms.Button OpenGame;
    }
}