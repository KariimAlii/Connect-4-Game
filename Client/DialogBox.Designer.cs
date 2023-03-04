namespace Client
{
    partial class DialogBox
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
            this.WinLoseLabel = new System.Windows.Forms.Label();
            this.PlayAgainBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WinLoseLabel
            // 
            this.WinLoseLabel.AutoSize = true;
            this.WinLoseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinLoseLabel.ForeColor = System.Drawing.Color.Red;
            this.WinLoseLabel.Location = new System.Drawing.Point(338, 90);
            this.WinLoseLabel.Name = "WinLoseLabel";
            this.WinLoseLabel.Size = new System.Drawing.Size(98, 32);
            this.WinLoseLabel.TabIndex = 0;
            this.WinLoseLabel.Text = "label1";
            // 
            // PlayAgainBtn
            // 
            this.PlayAgainBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.PlayAgainBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayAgainBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PlayAgainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayAgainBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlayAgainBtn.Location = new System.Drawing.Point(205, 238);
            this.PlayAgainBtn.Name = "PlayAgainBtn";
            this.PlayAgainBtn.Size = new System.Drawing.Size(154, 42);
            this.PlayAgainBtn.TabIndex = 4;
            this.PlayAgainBtn.Text = "Play Again!";
            this.PlayAgainBtn.UseVisualStyleBackColor = false;
            this.PlayAgainBtn.Click += new System.EventHandler(this.PlayAgainBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Red;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExitBtn.Location = new System.Drawing.Point(451, 238);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(137, 42);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "Cancel";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayAgainBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.WinLoseLabel);
            this.Name = "DialogBox";
            this.Text = "Game Result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WinLoseLabel;
        private System.Windows.Forms.Button PlayAgainBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}