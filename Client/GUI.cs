using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;


//=====================Game GUI====================//

namespace Client
{
    public partial class GameForm : Form
    {
        public void DrawCircle(Brush playerBrush, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);
        }

        public void DrawPlay(Color backColor, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            int Xspace = 13;
            int Yspace = 13;
            HatchStyle circleStyle = HatchStyle.ForwardDiagonal;
            Brush playerBrush = new HatchBrush(circleStyle, ForeColor, backColor);
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);
            playerBrush = new SolidBrush(backColor);
            g.FillEllipse(playerBrush, x + padding + Xspace, y + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);
        }

        public void DrawGamePanel()
        {
            for (int i = 0; i < Nrows; i++)
            {
                for (int j = 0; j < Ncols; j++)
                {
                    switch (Board[i, j])
                    {
                        case 0:
                            DrawCircle(PanelBrush, j * Size, i * Size, Size);
                            break;
                        case 1:
                            DrawPlay(BackColor1, j * Size, i * Size, Size);
                            break;
                        case 2:
                            DrawPlay(BackColor2, j * Size, i * Size, Size);
                            break;
                    }

                    points[i, j] = new Point(j * Size, i * Size);
                }
            }
            Graphics g = GamePanel.CreateGraphics();
            Pen borderPen = new Pen(Color.Black, 6);
            g.DrawRectangle(borderPen, 0, 0, GamePanel.Width - 1, GamePanel.Height - 1);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawGamePanel();
            ReDraw();

            Draw_Player_Rectangle(150);
            Draw_Player_Rectangle(1150);

            Fill_Player(200, BackColor1, "Player 1");
            Fill_Player(1200, BackColor2, "Player 2");
        }
        private void GameForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void Draw_Player_Rectangle(int xPosition)
        {
            Graphics g = this.CreateGraphics();
            Rectangle Rect = new Rectangle(xPosition, 300, 200, 200);
            Pen RectPen = new Pen(Color.Black, 2);
            g.DrawRectangle(RectPen, Rect);
        }

        public void Fill_Player(int xPosition, Color BackColor, string str)
        {
            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(BackColor, 2);
            HatchStyle circleStyle = HatchStyle.ForwardDiagonal;
            Brush playerBrush = new HatchBrush(circleStyle, ForeColor, BackColor);
            g.DrawEllipse(pen, xPosition, 320, 100, 100);
            g.FillEllipse(playerBrush, xPosition, 320, 100, 100);

            SolidBrush textBrush = new SolidBrush(Color.Black);
            Point location = new Point(xPosition, 450);
            Font font = new Font("courier", 20, FontStyle.Bold);
            g.DrawString(str, font, textBrush, location);
        }

        public void Dim()
        {
            if (this.player.playerStatus != Status.Watcher)
            {
                Graphics g = this.CreateGraphics();
                Rectangle area = this.RectangleToScreen(this.ClientRectangle);
                Brush dark = new SolidBrush(Color.FromArgb(128, Color.Black));
                g.FillRectangle(dark, 0, 0, area.Width, area.Height);
            }
        }


    }

}
