using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class GameForm : Form
    {
        //================ Board =================//
        int Nrows;
        int Ncols;
        int Size;

        int[,] Board;
        //================ Rectangle =================//
        Color Rect_Color;
        Rectangle Rect;
        Pen Rect_Pen;
        HatchBrush Rect_Brush;
        //================ Circle =================//
        Color Circle_Color;
        Brush Circle_Brush;
        public GameForm()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //================ Board =================//
            Nrows = 6;
            Ncols = 7;
            Size = 100;
            Board = new int[Nrows, Ncols];
            //================ Panel =================//
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            GamePanel.BackColor = Color.Beige;
            GamePanel.Location = new Point(50, 50);
        }
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
        public void DrawCircle(Color color, int x, int y, int size)
        {
            Circle_Brush = new SolidBrush(color);
            Graphics g = GamePanel.CreateGraphics();
            g.FillEllipse(Circle_Brush, x, y, size, size);
        }
        public void DrawGamePanel()
        {
            for (int i = 0; i <= Nrows; i++)
            {
                for (int j = 0; j <= Ncols; j++)
                {
                    DrawCircle(Color.Blue, i * Size, j * Size, Size);
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
