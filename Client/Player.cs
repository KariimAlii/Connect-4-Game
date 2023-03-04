using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public enum Status
    {
        None,
        Host,
        Guest,
        Watcher,
    }
    public partial class Player : Form
    {
        public TcpClient client;

        public Stream stream;
        public StreamReader reader;
        public StreamWriter writer;

        SynchronizationContext context;

        public string name;
        string number;
        string room;

        GameForm game;
        public Status playerStatus;
        public Player()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();

            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            name = namebox.Text;
            number = numberbox.Text;
            writer.Write($"{name},{number}");

            context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
            context.Post((object obj) => StatusBox.Text = "Connected..", null);


            reader = new StreamReader(stream);

            Task.Run(() => ReceiveMessages());
            room1.Visible = true;
            room2.Visible = true;
            room3.Visible = true;

        }
        private async void ReceiveMessages()
        {
            while (true)
            {
                if (stream != null)
                {

                    char[] charArr = new char[100];
                    try
                    {
                        int x = await reader.ReadAsync(charArr, 0, 100);
                    }
                    catch (Exception)
                    {


                    }

                    string str = new string(charArr);
                    List(str);
                    if (str.Contains("Connected"))
                    {
                        context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                        context.Post((object obj) => StatusBox.Text = str, null);

                    }
                    else if (str.Contains("ServerStopped"))
                    {
                        context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
                        context.Post((object obj) => StatusBox.Text = "Disconnected", null);
                        MessageBox.Show("Server Stopped!");
                        Disconnect();
                    }
                    //==================Receiveing The Broadcast From The Server To Update Room List==================//
                    else if (str.StartsWith("R1") && !str.Contains("R2") && !str.Contains("R3"))
                    {


                        this.room = "1";
                        string temp = str.Substring(3).Split('*')[0];
                        if (str.StartsWith("R1H") && str.Contains("*"))
                        {
                            string name = str.Split('H')[1].Split('*')[0];
                            this.playerStatus = Status.Host;
                        }
                        if (str.StartsWith("R1G") && str.Contains("*"))
                        {
                            string name = str.Split('G')[1].Split('*')[0];
                            this.playerStatus = Status.Guest;
                        }
                    }
                    //else if (str.StartsWith("Room1"))
                    //{
                    //    string temp1 = str.Substring(5).Split(',')[0];
                    //    string temp2 = str.Substring(5).Split(',')[1];
                    //    if (!listBox1.Items.Contains(temp1)) { listBox1.Items.Add(temp1); }
                    //    if (!listBox1.Items.Contains(temp2)) { listBox1.Items.Add(temp2); }
                    //}
                    else if (str.Contains("R2") && !str.Contains("R1") && !str.Contains("R3"))
                    {
                        this.room = "2";
                        string temp = str.Substring(3).Split('*')[0];
                        if (str.StartsWith("R2H") && str.Contains("*"))
                        {
                            string name = str.Split('H')[1].Split('*')[0];
                            this.playerStatus = Status.Host;
                        }
                        if (str.StartsWith("R2G") && str.Contains("*"))
                        {
                            string name = str.Split('G')[1].Split('*')[0];
                            this.playerStatus = Status.Guest;
                        }
                    }
                    else if (str.Contains("R3") && !str.Contains("R1") && !str.Contains("R2"))
                    {
                        this.room = "3";
                        string temp = str.Substring(3).Split('*')[0];
                        if (str.StartsWith("R3H") && str.Contains("*"))
                        {
                            string name = str.Split('H')[1].Split('*')[0];
                            this.playerStatus = Status.Host;
                        }
                        if (str.StartsWith("R3G") && str.Contains("*"))
                        {
                            string name = str.Split('G')[1].Split('*')[0];
                            this.playerStatus = Status.Guest;
                        }
                    }
                    if (str.Contains("Open"))
                    {
                        if (this.playerStatus == Status.Host) { game = new GameForm(this, 2); }
                        if (this.playerStatus == Status.Guest) { game = new GameForm(this, 1); }
                        this.game.GamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse);
                        Thread thread = new Thread(() =>
                        {
                            Application.Run(game);
                        });
                        thread.Start();
                    }


                }

            }
        }
        public void List(string str)
        {
            if (str.StartsWith("Room1"))
            {
                string room1 = str.Split('*')[0];
                string temp1 = room1.Substring(5).Split(',')[0];
                string temp2 = room1.Substring(5).Split(',')[1];
                if (!listBox1.Items.Contains(temp1)) { listBox1.Items.Add(temp1); }
                if (!listBox1.Items.Contains(temp2)) { listBox1.Items.Add(temp2); }
            }
            if (str.StartsWith("Room2"))
            {
                string room2 = str.Split('*')[0];
                string temp1 = room2.Substring(5).Split(',')[0];
                string temp2 = room2.Substring(5).Split(',')[1];
                if (!listBox2.Items.Contains(temp1)) { listBox2.Items.Add(temp1); }
                if (!listBox2.Items.Contains(temp2)) { listBox2.Items.Add(temp2); }
            }
            if (str.StartsWith("Room3"))
            {
                string room3 = str.Split('*')[0];
                string temp1 = room3.Substring(5).Split(',')[0];
                string temp2 = room3.Substring(5).Split(',')[1];
                if (!listBox3.Items.Contains(temp1)) { listBox3.Items.Add(temp1); }
                if (!listBox3.Items.Contains(temp2)) { listBox3.Items.Add(temp2); }
            }
        }
        private void Mouse(object sender, MouseEventArgs e)
        {
            if (this.playerStatus == Status.Host)
            {
                writer.WriteLine($"$H{this.game.row_num}/{this.game.col_num}*{this.name}");
                game.GamePanel.Enabled = false;
                game.DrawGamePanel();

            }
            else if (this.playerStatus == Status.Guest)
            {
                writer.WriteLine($"$G{this.game.row_num}/{this.game.col_num}*{this.name}");
                game.GamePanel.Enabled = false;
                game.DrawGamePanel();

            }


        }
        private async void Disconnect()
        {
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            await writer.WriteAsync("ClientStopped");

            client.Close();
        }
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void room1_Click(object sender, EventArgs e)
        {
            writer.WriteAsync("Room1");
        }

        private void room2_Click(object sender, EventArgs e)
        {
            writer.WriteAsync("Room2");
        }

        private void room3_Click(object sender, EventArgs e)
        {
            writer.WriteAsync("Room3");
        }


    }
}
