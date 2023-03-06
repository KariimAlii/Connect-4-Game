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

        public void DrawPlay1(Brush playerBrush, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            int Xspace = 13;
            int Yspace = 13;
            ForeColor1 = Color.White;
            BackColor1 = Color.Red;
            circleStyle = HatchStyle.ForwardDiagonal;
            playerBrush = new HatchBrush(circleStyle, ForeColor1, BackColor1);
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);

            Brush playerBrush1 = new SolidBrush(Color.Black);
            g.FillEllipse(playerBrush1, x + padding + Xspace, y + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);




            playerBrush = new SolidBrush(Color.Red);
            g.FillEllipse(playerBrush, x + padding + Xspace, y + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);

        }
        public void DrawPlay2(Brush playerBrush, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            int Xspace = 13;
            int Yspace = 13;

            ForeColor2 = Color.White;
            BackColor2 = Color.Yellow;
            circleStyle = HatchStyle.ForwardDiagonal;
            playerBrush = new HatchBrush(circleStyle, ForeColor2, BackColor2);
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);
            Brush playerBrush1 = new SolidBrush(Color.Yellow);
            g.FillEllipse(playerBrush1, x + padding + Xspace, y + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);

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
                            DrawPlay1(Player1Brush, j * Size, i * Size, Size);
                            break;
                        case 2:
                            DrawPlay2(Player2Brush, j * Size, i * Size, Size);
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
            Player1_Rectangle();
            Fill_Player1();
            Player2_Rectangle();
            Fill_Player2();
        }
        public void Player1_Rectangle()
        {
            Graphics g = this.CreateGraphics();
            P1RectColor = Color.Black;
            P1Rect = new Rectangle(150, 300, 200, 200);
            P1RectPen = new Pen(P1RectColor, 2);
            g.DrawRectangle(P1RectPen, P1Rect);
        }
        public void Fill_Player1()
        {
            Graphics g = this.CreateGraphics();
            Player1 = new Pen(Player1Color);
            Player1.Width = 2;
            g.DrawEllipse(Player1, 200, 320, 100, 100);
            g.FillEllipse(Player1Brush, 200, 320, 100, 100);
            Player1_brushStr = new SolidBrush(Player1_colorstr);
            Player1_Location = new Point(200, 450);
            g.DrawString(Player1_string, Player1_font, Player1_brushStr, Player1_Location);
        }

        public void Player2_Rectangle()
        {
            Graphics g = this.CreateGraphics();
            P2RectColor = Color.Black;
            P2Rect = new Rectangle(1150, 300, 200, 200);
            roundedRectangle2 = Rectangle.Round(P2Rect);
            P2RectPen = new Pen(P1RectColor, 2);
            g.DrawRectangle(P2RectPen, roundedRectangle2);
        }
        public void Fill_Player2()
        {
            Graphics g = this.CreateGraphics();
            Player2 = new Pen(Player2Color);
            Player2.Width = 2;
            g.DrawEllipse(Player2, 1200, 320, 100, 100);
            g.FillEllipse(Player2Brush, 1200, 320, 100, 100);
            Player2_brushStr = new SolidBrush(Player2_colorstr);
            Player2_Location = new Point(1200, 450);
            g.DrawString(Player2_string, Player2_font, Player2_brushStr, Player2_Location);


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
