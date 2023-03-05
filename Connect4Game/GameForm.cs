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
        int padding;
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
        //Player1 Rectangle
        Rectangle P1Rect;
        Rectangle roundedRectangle1;
        Color P1RectColor;
        Brush P1RectBrush;
        Pen P1RectPen;
        //player1 circle
        Pen Player1;
        Color Player1Color;
        Brush PlayerOneBrush;
        Color Player1BackColor;
        //player1 text
        string Player1_string;
        Font Player1_font;
        Brush Player1_brushStr;
        Color Player1_colorstr;
        Point Player1_Location;
        FontStyle Player1_style;



        //Player2 Rectangle
        Rectangle P2Rect;
        Rectangle roundedRectangle2;
        Color P2RectColor;
        Pen P2RectPen;
        Brush P2RectBrush;
        //player2 circle
        Pen Player2;
        Color Player2Color;
        Brush PlayerTwoBrush;
        Color Player2BackColor;
        //player2 text
        string Player2_string;
        Font Player2_font;
        Brush Player2_brushStr;
        Color Player2_colorstr;
        Point Player2_Location;
        FontStyle Player2_style;
        SolidBrush overlayBrush;
        HatchStyle circleStyle;
        Color ForeColor1;
        Color BackColor1;
        Color ForeColor2;
        Color BackColor2;



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
            padding = 3;
            Board = new int[Nrows, Ncols];
            points = new Point[Nrows, Ncols];
            turn = 1;
            //Player1Brush = new SolidBrush(Color.Red);
            //Player2Brush = new SolidBrush(Color.Yellow);
            ForeColor1 = Color.White;
            BackColor1 = Color.Red;
            ForeColor2 = Color.White;
            BackColor2 = Color.Yellow;
            circleStyle = HatchStyle.ForwardDiagonal;
            Player1Brush = new HatchBrush(circleStyle, ForeColor1, BackColor1);
            Player2Brush = new HatchBrush(circleStyle, ForeColor2, BackColor2);
           

            PanelBrush = new SolidBrush(Color.Blue);
            //================ Panel =================//
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            GamePanel.BackColor = Color.Beige;
            GamePanel.Location = new Point(400, 100);
            //Player1 Rectangle 
            P1RectColor = Color.Black;
            P1RectBrush=new SolidBrush(Color.White);
            //player1 circle
            Player1Color = Color.Red;
            Player1BackColor = Color.Gray;
            Player1Brush = new SolidBrush(Player1Color);
            //player1 text
            // First Title
            Player1_string = "Player 1";
            Player1_style = FontStyle.Bold;
            Player1_font = new Font("courier", 20, Player1_style);
            Player1_colorstr = Color.Black;

            //Player2 Rectangle 
            P2RectColor = Color.Black;
            P2RectBrush = new SolidBrush(Color.White);
            //player2 circle
            Player2Color = Color.Yellow;

            Player2Brush = new SolidBrush(Player2Color);
            // Second Title
            Player2_string = "Player 2";
            Player2_style = FontStyle.Bold;
            Player2_font = new Font("courier", 20, Player2_style);
            Player2_colorstr = Color.Black;
            overlayBrush = new SolidBrush(Color.FromArgb(128, Color.Black));
           
           


        }

       
    }
}
