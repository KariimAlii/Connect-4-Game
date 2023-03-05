using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

//=====================Game GUI====================//

namespace Client
{
    public partial class GameForm : Form
    {
        //public void DrawRectangle(Color color, int penSize, int x, int y, int width, int height)
        //{
        //    Rect_Color = color;
        //    Rect_Pen = new Pen(color, penSize);
        //    Rect = new Rectangle(x, y, width, height);
        //    Graphics g = this.CreateGraphics();
        //    g.DrawRectangle(Rect_Pen, Rect);
        //}
        //public void DrawFilledRectangle(Color color, int penSize, int x, int y, int width, int height)
        //{
        //    Rect_Color = color;
        //    Rect_Brush = new HatchBrush(HatchStyle.BackwardDiagonal, color, Color.Empty);
        //    Rect = new Rectangle(x, y, width, height);
        //    Graphics g = this.CreateGraphics();
        //    g.FillRectangle(Rect_Brush, Rect);
        //}
        //public void DrawCircle(Brush playerBrush, int x, int y, int size)
        //{
        //    Graphics g = GamePanel.CreateGraphics();
        //    g.FillEllipse(playerBrush, x, y, size, size);
        //}
        public void DrawCircle(Brush playerBrush, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);
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
                            DrawCircle(Player1Brush, j * Size, i * Size, Size);
                            break;
                        case 2:
                            DrawCircle(Player2Brush, j * Size, i * Size, Size);
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
            if (true == _isShrouded && null != _background)
                e.Graphics.DrawImage(_background, 0, 0);
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
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
            //draw circle
            Player1 = new Pen(Player1Color);
            Player1.Width = 2;
            g.DrawEllipse(Player1, 200, 320, 100, 100);
            g.FillEllipse(Player1Brush, 200, 320, 100, 100);
            //draw text 
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
            //draw circle
            Player2 = new Pen(Player2Color);
            Player2.Width = 2;
            g.DrawEllipse(Player2, 1200, 320, 100, 100);
            g.FillEllipse(Player2Brush, 1200, 320, 100, 100);
            //draw text 
            Player2_brushStr = new SolidBrush(Player2_colorstr);
            Player2_Location = new Point(1200, 450);
            g.DrawString(Player2_string, Player2_font, Player2_brushStr, Player2_Location);


        }

        private Bitmap _background;
        private bool _isShrouded;



        public void Shroud()
        {
            if (false == _isShrouded)
            {
                CreateScreenshot();

                HideControls();

                _isShrouded = true;

                this.Invalidate();
            }
        }
        public void Unshroud()
        {
            if (true == _isShrouded)
            {
                ShowControls();

                _isShrouded = false;

                this.Invalidate();
            }


        }
        private void ShowControls()
        {
            foreach (Control control in this.Controls)
                control.Visible = true;
        }

        private void HideControls()
        {
            foreach (Control control in this.Controls)
                control.Visible = false;
        }
        private void CreateScreenshot()
        {
            Rectangle area = this.RectangleToScreen(this.ClientRectangle);
            Bitmap screenGrab = new Bitmap(area.Width, area.Height);

            Brush dark = new SolidBrush(Color.FromArgb(128, Color.Black));

            Graphics g = Graphics.FromImage(screenGrab);
            g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            g.FillRectangle(dark, 0, 0, area.Width, area.Height);
            g.Dispose();

            _background = screenGrab;
        }

    }

}
