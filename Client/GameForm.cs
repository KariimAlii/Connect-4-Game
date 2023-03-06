using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

//=====================Game Fields & Constructor====================//

namespace Client
{
    public partial class GameForm : Form
    {

        #region Fields
        int Nrows;
        int Ncols;
        int Size;
        int padding;
        int[,] Board;
        Point[,] points;
        int turn;
        string challenger;


        public int row_num { get; set; }
        public int col_num { get; set; }

        Player player;
        Boolean drawn;

        Brush PanelBrush;
        Color BackColor1;
        Color BackColor2;
        #endregion


        public GameForm(Player player, int turns)
        {
            InitializeComponent();

            #region Initiating Class Members
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
            //================ Panel =================//
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            GamePanel.BackColor = Color.Beige;
            GamePanel.Location = new Point(400, 100);
            ForeColor = Color.White;
            BackColor1 = Color.Red;
            BackColor2 = Color.Green;
            PanelBrush = new SolidBrush(Color.Blue);

            turn = turns;
            this.player = player;
            drawn = true;
            #endregion

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
                            if (this.player.playerStatus == Status.Host)
                            {
                                Thread recievingthread = new Thread(() => this.player.ReceiveMessages());
                                recievingthread.Start();
                                this.GamePanel.Enabled = true;
                                Board = new int[Nrows, Ncols];
                                DrawGamePanel();
                            }
                            else { this.Dispose(); }

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

                        string playedRow = item.Substring(0, 1);
                        string playedCol = item.Substring(1, 1);
                        if (playedRow != "\0" && playedCol != "\0")
                        {
                            if (disk % 2 == 0)
                            {
                                adjustPlay(int.Parse(playedRow), int.Parse(playedCol), 2);
                            }
                            else
                            {
                                adjustPlay(int.Parse(playedRow), int.Parse(playedCol), 1);
                            }
                            disk++;
                        }
                    }

                }
                DrawGamePanel();
            }
        }


    }
}
