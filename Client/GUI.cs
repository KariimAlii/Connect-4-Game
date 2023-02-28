﻿using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

//=====================Game GUI====================//

namespace Client
{
    public partial class GameForm : Form
    {
        public void DrawRectangle(Color color, int penSize, int x, int y, int width, int height)
        {
            Rect_Color = color;
            Rect_Pen = new Pen(color, penSize);
            Rect = new Rectangle(x, y, width, height);
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(Rect_Pen, Rect);
        }
        public void DrawFilledRectangle(Color color, int penSize, int x, int y, int width, int height)
        {
            Rect_Color = color;
            Rect_Brush = new HatchBrush(HatchStyle.BackwardDiagonal, color, Color.Empty);
            Rect = new Rectangle(x, y, width, height);
            Graphics g = this.CreateGraphics();
            g.FillRectangle(Rect_Brush, Rect);
        }
        public void DrawCircle(Brush playerBrush, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            g.FillEllipse(playerBrush, x, y, size, size);
        }
        public void DrawGamePanel()
        {
            for (int i = 0; i < Nrows; i++)
            {
                for (int j = 0; j < Ncols; j++)
                {
                    DrawCircle(PanelBrush, j * Size, i * Size, Size);
                    points[i, j] = new Point(j * Size, i * Size);
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawGamePanel();
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }

}