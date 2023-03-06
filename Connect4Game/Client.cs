using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Connect4Game
{
    public class Client
    {
        #region Fields
        public TcpClient tcpClient;
        public string name { get; set; }
        public string room { get; set; }

        public Room myRoom;

        public Server server;

        NetworkStream stream;
        public StreamWriter writer { get; }
        public StreamReader reader { get; }

        Thread streamingThread;

        bool isConnected = true;
        #endregion

        #region Constructor
        public Client(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;

            stream = tcpClient.GetStream();

            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.Write("Connected");

            reader = new StreamReader(stream);

            streamingThread = new Thread(() => ReceiveMessages());
            streamingThread.IsBackground = true;
            streamingThread.Start();

        }
        #endregion

        private void ReceiveMessages()
        {
            while (isConnected)
            {
                if (stream != null)
                {

                    #region Reading Message
                    char[] charArr = new char[100];
                    string str = "";
                    try
                    {
                        int x = reader.Read(charArr, 0, 100);
                        str = new string(charArr);
                    }
                    catch
                    {

                    }
                    #endregion

                    #region Client Disconnect
                    if (str.Contains("ClientStopped"))
                    {
                        MessageBox.Show("Your Client Stopped Playing!!");
                        if (myRoom.getHost() == this)
                        {

                            myRoom.setHost(null);
                            myRoom.setGuest(null);
                        }
                        if (myRoom.getGuest() == this) {; myRoom.setGuest(null); }

                        this.tcpClient.Dispose();
                        streamingThread.Abort();
                    }
                    #endregion

                    #region Client Connect
                    else if (str.Contains(","))
                    {
                        string[] temp = str.Split(',');
                        name = temp[0];
                        //room = temp[1];
                    }
                    #endregion

                    #region Client Request to Join a Room
                    else if (str.Contains("Room1") && this.room == null)
                    {
                        this.room = "1";
                        this.myRoom = this.server.room1;
                    }
                    else if (str.Contains("Room2") && this.room == null)
                    {
                        this.room = "2";
                        this.myRoom = this.server.room2;
                    }
                    else if (str.Contains("Room3") && this.room == null)
                    {
                        this.room = "3";
                        this.myRoom = this.server.room2;
                    }
                    #endregion


                    if (this.room == "1" || this.room == "2" || this.room == "3")
                    {
                        #region Client make a Play
                        // ($Grow/col*playerName)
                        if (str.StartsWith("$"))
                        {
                            string full = str.Split('*')[0].Trim('$');
                            string playerName = str.Split('*')[1];
                            string row = full.Split('/')[0];
                            string col = full.Split('/')[1];
                            if (row.StartsWith("G"))
                            {
                                row = row.Trim('G');
                                myRoom.Board.Add(row + col + '/');
                                this.myRoom.getHost().writer.WriteLine($"@{row}/{col}*{playerName}");
                                foreach (Client watcher in this.myRoom.watcherList.ToList())
                                {
                                    if (watcher.tcpClient.Connected)
                                    {
                                        watcher.writer.WriteLine($"H%{row}/{col}*{playerName}");
                                        string combinedString = string.Join("", this.myRoom.Board);
                                        this.writer.Write($"^^{combinedString}");
                                    }

                                }
                            }
                            else if (row.StartsWith("H"))
                            {
                                row = row.Trim('H');
                                myRoom.Board.Add(row + col + '/');
                                if (this.myRoom.getGuest() != null)
                                    this.myRoom.getGuest().writer.WriteLine($"@{row}/{col}*{playerName}");
                                foreach (Client watcher in this.server.room1.watcherList.ToList())
                                {
                                    if (watcher.tcpClient.Connected)
                                    {
                                        watcher.writer.WriteLine($"G%{row}/{col}*{playerName}");
                                    }

                                }
                            }

                        }
                        #endregion
                        #region Client Play Again
                        if (str.StartsWith("PlayAgain"))
                        {
                            this.myRoom.Board = new List<string>();
                            this.myRoom.watcherList = new List<Client>();
                        }
                        #endregion
                        #region Client Exit
                        if (str.StartsWith("Exit"))
                        {
                            string status = str.Split('-')[1];
                            if (status.Contains("Host"))
                            {

                                this.server.clients.Remove(this.myRoom.getGuest());
                                this.server.clients.Remove(this);
                                this.myRoom.getGuest().writer.Write("CloseYourApp");
                                Thread.Sleep(500);
                                this.myRoom.getGuest().tcpClient.Close();
                                this.myRoom.getGuest().isConnected = false;
                                this.myRoom.setHost(null);
                                this.myRoom.setGuest(null);

                            }
                            else if (status.Contains("Guest"))
                            {
                                this.myRoom.getHost().writer.Write("CloseYourApp");
                                this.server.clients.Remove(this);
                                this.myRoom.setGuest(null);

                                MessageBox.Show("Set Guest to null");
                            }
                            isConnected = false;
                            this.tcpClient.Close();
                        }
                        #endregion

                    }

                }


            }
        }

    }
}

