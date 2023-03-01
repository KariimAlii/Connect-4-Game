using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

//=====================Game Fields & Constructor====================//
namespace Client
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
            PanelBrush = new SolidBrush(Color.Cyan);
            //================ Panel =================//
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            GamePanel.BackColor = Color.Beige;
            GamePanel.Location = new Point(50, 50);
            
        }

        
    }
}
