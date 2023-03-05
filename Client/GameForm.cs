﻿using System;
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
        int[,] Board;
        Point[,] points;
        int turn;
        string challenger;
        Brush Player1Brush;
        Brush Player2Brush;
        Brush PanelBrush;
        public int row_num { get; set; }
        public int col_num { get; set; }
        //================ Rectangle =================//
        Color Rect_Color;
        Rectangle Rect;
        Pen Rect_Pen;
        HatchBrush Rect_Brush;
        Player player;
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
            Board = new int[Nrows, Ncols];
            points = new Point[Nrows, Ncols];
            turn = turns;
            Player1Brush = new SolidBrush(Color.Pink);
            Player2Brush = new SolidBrush(Color.Yellow);
            PanelBrush = new SolidBrush(Color.Cyan);
            //================ Panel =================//
            GamePanel.Width = Ncols * Size;
            GamePanel.Height = Nrows * Size;
            GamePanel.BackColor = Color.Beige;
            GamePanel.Location = new Point(50, 50);
            this.player = player;
            drawn = true;
            //=========setting the host to start========//
            if (this.player.playerStatus == Status.Guest) { this.GamePanel.Enabled = false; }
            Thread thread = new Thread(async () =>
            {
                if (this.player != null)
                {
                    while (true)
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

                            }
                            if (this.player.playerStatus == Status.Guest)
                            {
                                GamePanel.Enabled = true;
                                DrawGamePanel();
                                adjustPlay(int.Parse(row), int.Parse(col), 2);

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


    }
}
