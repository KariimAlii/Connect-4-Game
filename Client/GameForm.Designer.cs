﻿namespace Client
{
    partial class GameForm
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
            this.GamePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.Location = new System.Drawing.Point(-1, 0);
            this.GamePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1348, 636);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseClick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 666);
            this.Controls.Add(this.GamePanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "Connect 4 Game";
            this.Resize += new System.EventHandler(this.GameForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel GamePanel;
    }
}

