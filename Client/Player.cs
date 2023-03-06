using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        #region Fields
        public TcpClient client;

        public Stream stream;
        public StreamReader reader;
        public StreamWriter writer;

        public SynchronizationContext context;
        public string name;
        string number;
        string room;
        public string[] played;
        GameForm game;
        public Status playerStatus;
        bool isConnected = true;
        public Thread recievingthread;
        public bool isPlaying = false;
        #endregion

        #region Constructor
        public Player()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }
        #endregion

        #region Controls
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            isConnected = true;
            //Validation
            if (namebox.Text == "" || numberbox.Text == "")
            {
                MessageBox.Show("Please Enter Your name and Number", "Invalid Input");
            }
            else
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
                recievingthread = new Thread(() => ReceiveMessages());
                recievingthread.Start();
                room1.Visible = true;
                room2.Visible = true;
                room3.Visible = true;
            }

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
        #endregion
        public void ReceiveMessages()
        {
            while (isConnected)
            {
                if (stream != null)
                {

                    char[] charArr = new char[100];
                    try
                    {
                        int x = reader.Read(charArr, 0, 100);
                    }
                    catch (Exception)
                    {

                    }
                    string str = new string(charArr);

                    #region Updating Room Listboxes
                    List(str);
                    #endregion
                    #region Responding if PLayer Connected to Server
                    if (str.Contains("Connected"))
                    {
                        context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                        context.Post((object obj) => StatusBox.Text = str, null);

                    }
                    #endregion
                    #region Responding if Server Stopped Listening
                    else if (str.Contains("ServerStopped"))
                    {
                        MessageBox.Show("Server Stopped!");
                        Disconnect();
                    }
                    #endregion
                    #region Receiving Info from Server (room , player_name , player_status)
                    // ( R1H{client_name}* )
                    else if (str.StartsWith("R1") && !str.Contains("R2") && !str.Contains("R3"))
                    {
                        this.room = "1";
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
                        if (str.StartsWith("R1W") && str.Contains("*"))
                        {
                            string name = str.Split('W')[1].Split('*')[0];
                            this.playerStatus = Status.Watcher;
                        }
                    }
                    else if (str.Contains("R2") && !str.Contains("R1") && !str.Contains("R3"))
                    {
                        this.room = "2";
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
                        if (str.StartsWith("R2W") && str.Contains("*"))
                        {
                            string name = str.Split('W')[1].Split('*')[0];
                            this.playerStatus = Status.Watcher;
                        }
                    }
                    else if (str.Contains("R3") && !str.Contains("R1") && !str.Contains("R2"))
                    {
                        this.room = "3";
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
                        if (str.StartsWith("R3W") && str.Contains("*"))
                        {
                            string name = str.Split('W')[1].Split('*')[0];
                            this.playerStatus = Status.Watcher;
                        }
                    }
                    #endregion
                    #region For Watcher , Updating the Played Info Array
                    if (str.Contains("^^"))
                    {
                        str = str.Remove(0, 2);
                        played = str.Split('/');

                    }
                    #endregion
                    #region Receiving instruction to open the game
                    if (str.Contains("Open"))
                    {

                        if (this.playerStatus == Status.Host) { game = new GameForm(this, 2); }
                        if (this.playerStatus == Status.Guest) { game = new GameForm(this, 1); }
                        if (this.playerStatus == Status.Watcher) { game = new GameForm(this, 3); }
                        if (this.playerStatus != Status.Watcher)
                        {
                            this.game.GamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse);
                        }
                        Thread thread = new Thread(() => { Application.Run(game); });
                        thread.Start();
                        recievingthread.Abort();

                    }
                    #endregion
                }

            }
        }

        public void List(string str)
        {
            // (Room1{Host},{Guest}*)
            if (str.StartsWith("Room1"))
            {
                string room1 = str.Split('*')[0];
                string hostName = room1.Substring(5).Split(',')[0];
                string guestName = room1.Substring(5).Split(',')[1];
                if (!listBox1.Items.Contains(hostName)) { listBox1.Items.Add(hostName); }
                if (!listBox1.Items.Contains(guestName)) { listBox1.Items.Add(guestName); }
            }
            if (str.StartsWith("Room2"))
            {
                string room2 = str.Split('*')[0];
                string hostName = room2.Substring(5).Split(',')[0];
                string guestName = room2.Substring(5).Split(',')[1];
                if (!listBox2.Items.Contains(hostName)) { listBox2.Items.Add(hostName); }
                if (!listBox2.Items.Contains(guestName)) { listBox2.Items.Add(guestName); }
            }
            if (str.StartsWith("Room3"))
            {
                string room3 = str.Split('*')[0];
                string hostName = room3.Substring(5).Split(',')[0];
                string guestName = room3.Substring(5).Split(',')[1];
                if (!listBox3.Items.Contains(hostName)) { listBox3.Items.Add(hostName); }
                if (!listBox3.Items.Contains(guestName)) { listBox3.Items.Add(guestName); }
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
            isConnected = false;
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            await writer.WriteAsync("ClientStopped");
            client.Close();
        }
    }
}
