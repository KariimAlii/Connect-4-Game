using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

//=====================Game GUI====================//

namespace Connect4Game
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
            ForeColor1 =Color.White;
            BackColor1=Color.Red;
            circleStyle = HatchStyle.ForwardDiagonal;
            playerBrush = new HatchBrush(circleStyle,ForeColor1,BackColor1);
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);
            playerBrush = new SolidBrush(Color.Red);
            g.FillEllipse(playerBrush, x + padding + Xspace, y + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);



        }
        public void DrawPlay2(Brush playerBrush, int x, int y, int size)
        {
            Graphics g = GamePanel.CreateGraphics();
            int Xspace = 13;
            int Yspace = 13; 
            
            ForeColor2 = Color.White;
            BackColor2 = Color.Green;
            circleStyle = HatchStyle.ForwardDiagonal;
            playerBrush = new HatchBrush(circleStyle, ForeColor2, BackColor2);
            g.FillEllipse(playerBrush, x + padding, y + padding, size - 2 * padding, size - 2 * padding);
            playerBrush = new SolidBrush(Color.Green);
            g.FillEllipse(playerBrush, x + padding+Xspace, y + padding+Yspace, 75 - 2 * padding, 75 - 2 * padding);


        }
        public void DrawGamePanel()
        {
            Graphics g = GamePanel.CreateGraphics();
            for (int i = 0; i < Nrows; i++)
            {
                for (int j = 0; j < Ncols; j++)
                {
                  
                    DrawCircle(PanelBrush, j * Size, i * Size,Size);
                    points[i, j] = new Point(j * Size, i * Size);
                }
            }

            // Draw border
           
            Pen borderPen = new Pen(Color.Black, 6);
            g.DrawRectangle(borderPen, 0, 0, GamePanel.Width - 1, GamePanel.Height - 1);

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
            int Xspace = 13;
            int Yspace = 13;

            ForeColor2 = Color.White;
            BackColor2 = Color.Red;
            circleStyle = HatchStyle.ForwardDiagonal;
            Brush playerBrush = new HatchBrush(circleStyle, ForeColor2, BackColor2);

            //fill rectangle
            g.FillRectangle(P1RectBrush,P1Rect);
            //draw circle
            g.FillEllipse(playerBrush, 200 + padding, 320 + padding, 100 - 2 * padding, 100 - 2 * padding);
            playerBrush = new SolidBrush(Color.Red);
            g.FillEllipse(playerBrush, 200 + padding + Xspace, 320 + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);

           
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
            int Xspace = 13;
            int Yspace = 13;

            ForeColor2 = Color.White;
            BackColor2 = Color.Green;
            circleStyle = HatchStyle.ForwardDiagonal;
            Brush playerBrush = new HatchBrush(circleStyle, ForeColor2, BackColor2);
           
            //fill rectangle
            g.FillRectangle(P2RectBrush, P2Rect);
            //draw circle
            g.FillEllipse(playerBrush, 1200 + padding, 320 + padding, 100 - 2 * padding, 100 - 2 * padding);
            playerBrush = new SolidBrush(Color.Green);
            g.FillEllipse(playerBrush, 1200 + padding + Xspace, 320 + padding + Yspace, 75 - 2 * padding, 75 - 2 * padding);
           
            //draw text 
            Player2_brushStr = new SolidBrush(Player2_colorstr);
            Player2_Location = new Point(1200, 450);
            g.DrawString(Player2_string, Player2_font, Player2_brushStr, Player2_Location);


        }

        public void Dim_Player1()
        {
            Graphics g = this.CreateGraphics();
            // Create a semi-transparent overlay
            
            g.FillRectangle(overlayBrush, P1Rect);
            Player2_Rectangle();
            Fill_Player2();


        }
      

        public void Dim_Player2()
        {
            Graphics g = this.CreateGraphics();
            // Create a semi-transparent overlay
           
            g.FillRectangle(overlayBrush, roundedRectangle2);

            Player1_Rectangle();
            Fill_Player1();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawGamePanel();
            Player1_Rectangle();
            Fill_Player1();
            Player2_Rectangle();
            Fill_Player2();
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }

}
