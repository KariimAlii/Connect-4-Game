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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public enum Status
    {
        Host,
        Guest,
        Watcher,
    }
    public partial class Player : Form
    {
        TcpClient client;

        Stream stream;
        StreamReader reader;
        StreamWriter writer;

        SynchronizationContext context;

        string name;
        string number;
        string room;

        GameForm game;
        Status playerStatus;
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
                    else if (str.Contains("R1") && !str.Contains("R2") && !str.Contains("R3"))
                    {
                        this.room = "1";
                        string host = str.Split('1')[1].Split('|')[0];
                        string guest = str.Split('1')[1].Split('|')[1];
                        if (!listBox1.Items.Contains(host)) context.Post((object obj) => listBox1.Items.Add(host), null);
                        if (!listBox1.Items.Contains(guest))
                        {
                            context.Post((object obj) => listBox1.Items.Add(guest), null);

                        }
                        if (this.name == host) this.playerStatus = Status.Host;
                        if (this.name == guest) this.playerStatus = Status.Guest;
                    }
                    else if (str.Contains("R2") && !str.Contains("R1") && !str.Contains("R3"))
                    {
                        this.room = "2";
                        string host = str.Split('2')[1].Split('|')[0];
                        string guest = str.Split('2')[1].Split('|')[1];
                        if (!listBox2.Items.Contains(host)) context.Post((object obj) => listBox2.Items.Add(host), null);
                        if (!listBox2.Items.Contains(guest)) context.Post((object obj) => listBox2.Items.Add(guest), null);
                        if (this.name == host) this.playerStatus = Status.Host;
                        if (this.name == guest) this.playerStatus = Status.Guest;
                    }
                    else if (str.Contains("R3") && !str.Contains("R1") && !str.Contains("R2"))
                    {
                        this.room = "3";
                        string host = str.Split('3')[1].Split('|')[0];
                        string guest = str.Split('3')[1].Split('|')[1];
                        if (!listBox3.Items.Contains(host)) context.Post((object obj) => listBox3.Items.Add(host), null);
                        if (!listBox3.Items.Contains(guest)) context.Post((object obj) => listBox3.Items.Add(guest), null);
                        if (this.name == host) this.playerStatus = Status.Host;
                        if (this.name == guest) this.playerStatus = Status.Guest;
                    }
                    ////////////////////////////////////////zzz/////////////////////
                    if (str.Contains("Open"))
                    {
                        game = new GameForm();
                        Application.Run(game);
                    }
                }

            }
        }




        private async void Disconnect()
        {
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            await writer.WriteAsync("ClientStopped");
            //writer.Write("ClientStopped");

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
