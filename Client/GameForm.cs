using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

//=====================Game Fields & Constructor====================//
namespace Client
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
        string challenger;
        Brush Player1Brush;
        Brush Player2Brush;
        Brush PanelBrush;
        public int row_num { get; set; }
        public int col_num { get; set; }

        Player player;
        //==================Players================//
        //Player1 Rectangle
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

        //=====================Redrawing==============//
        Boolean drawn;
       
        public GameForm(Player player, int turns)
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
            turn = turns;

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
            this.player = player;
            drawn = true;
            //=================Player=================//
            //Player1 Rectangle 
            //Player1 Rectangle 
            P1RectColor = Color.Black;
            P1RectBrush = new SolidBrush(Color.White);
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
          
            //=========setting the host to start========//
            if (this.player.playerStatus == Status.Guest) { this.GamePanel.Enabled = false; }
            Thread thread = new Thread(async () =>
            {
                if (this.player != null)
                {
                    while (true && this.player.client.Connected)
                    {
                        char[] charArr = new char[300];
                        try
                        {
                            int x = await this.player.reader.ReadAsync(charArr, 0, 300);
                        }
                        catch (Exception)
                        {


                        }

                        string str = new string(charArr);
                        if (str.Contains("@"))
                        {

                            string full = str.Split('*')[0].Trim('@');
                            challenger = str.Split('*')[1];
                            string row = full.Split('/')[0];
                            string col = full.Split('/')[1];
                            if (this.player.playerStatus == Status.Host)
                            {
                                GamePanel.Enabled = true;

                                DrawGamePanel();
                                adjustPlay(int.Parse(row), int.Parse(col), 1);
                                Invalidate();

                            }
                            if (this.player.playerStatus == Status.Guest)
                            {
                                GamePanel.Enabled = true;

                                DrawGamePanel();
                                adjustPlay(int.Parse(row), int.Parse(col), 2);
                                Invalidate();

                            }
                        }
                        if (str.StartsWith("H%") && this.player.playerStatus == Status.Watcher)
                        {
                            string full = str.Split('*')[0].Trim('H').Trim('%');
                            challenger = str.Split('*')[1];
                            string row = full.Split('/')[0];
                            string col = full.Split('/')[1];
                            DrawGamePanel();
                            adjustPlay(int.Parse(row), int.Parse(col), 1);


                        }
                        if (str.StartsWith("G%") && this.player.playerStatus == Status.Watcher)
                        {
                            string full = str.Split('*')[0].Trim('G').Trim('%');
                            challenger = str.Split('*')[1];
                            string row = full.Split('/')[0];
                            string col = full.Split('/')[1];
                            DrawGamePanel();
                            adjustPlay(int.Parse(row), int.Parse(col), 2);
                        }

                        if (str.StartsWith("CloseYourApp"))
                        {
                            this.Close();
                        }
                    }
                }
            });
            thread.Start();
        }
        public void ReDraw()
        {
            if (this.player.playerStatus == Status.Watcher && drawn)
            {
                drawn = false;
                int disk = 2;

                foreach (string item in this.player.played)
                {
                    if (item != "")
                    {

                        string playedrow = item.Substring(0, 1);
                        string playedcol = item.Substring(1, 1);
                        if (playedrow != "\0" && playedcol != "\0")
                        {
                            if (disk % 2 == 0)
                            {
                                adjustPlay(int.Parse(playedrow), int.Parse(playedcol), 1);
                            }
                            else
                            {
                                adjustPlay(int.Parse(playedrow), int.Parse(playedcol), 2);
                            }
                            disk++;
                        }
                    }

                }
                DrawGamePanel();
            }
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
