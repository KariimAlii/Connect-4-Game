using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

//=====================Game Fields & Constructor====================//
namespace Connect4Game
{
    public partial class GameForm : Form
    {
        //================ Board =================//
        int Nrows;
        int Ncols;
        int Size;
        int[,] Board;
        Point[,] points;
        int turn;
        Brush Player1Brush;
        Brush Player2Brush;
        Brush PanelBrush;
        int row_num;
        int col_num;
        //================ Rectangle =================//
        Color Rect_Color;
        Rectangle Rect;
        Pen Rect_Pen;
        HatchBrush Rect_Brush;
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
            points = new Point[Nrows, Ncols];
            turn = 1;
            Player1Brush = new SolidBrush(Color.Pink);
            Player2Brush = new SolidBrush(Color.Yellow);
            PanelBrush = new SolidBrush(Color.Blue);
            //================ Panel =================//
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            GamePanel.BackColor = Color.Beige;
            GamePanel.Location = new Point(50, 50);
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nrows = 4;
            Ncols=5;
            for (int i = 0; i < Nrows; i++)
            {
                for (int j = 0; j < Ncols; j++)
                {
                    DrawCircle(PanelBrush, j * Size, i * Size, Size);
                    points[i, j] = new Point(j * Size, i * Size);
                }
            }
         
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            Invalidate();   

        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nrows = 5;
            Ncols = 6;
           
            for (int i = 0; i < Nrows; i++)
            {
                for (int j = 0; j < Ncols; j++)
                {
                    DrawCircle(PanelBrush, j * Size, i * Size, Size);
                    points[i, j] = new Point(j * Size, i * Size);
                }
            }

            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            Invalidate();


        }

        private void largePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nrows = 6;
            Ncols = 7;
         
            for (int i = 0; i < Nrows; i++)
            {
                for (int j = 0; j < Ncols; j++)
                {
                    DrawCircle(PanelBrush, j * Size, i * Size, Size);
                    points[i, j] = new Point(j * Size, i * Size);
                }
            }

            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            Invalidate();

        }
    }
}
