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
        public TcpClient tcpClient;
        public string name { get; set; }
        public string room { get; set; }
        public Room myRoom;
        public Server server;


        NetworkStream stream;
        public StreamWriter writer { get; }
        public StreamReader reader { get; }
        Thread streamingThread;

        public BackgroundWorker backgroundWorker2;

        public Client(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;


            stream = tcpClient.GetStream();

            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.Write("Connected");


            reader = new StreamReader(stream);

            //Task.Run(() => ReceiveMessages());
            streamingThread = new Thread(() => ReceiveMessages());
            streamingThread.IsBackground = true;
            streamingThread.Start();


        }
        //~Client() {
        //    backgroundWorker2.CancelAsync();
        //    tcpClient.Close();
        //}


        private void ReceiveMessages()
        {
            while (true)
            {
                if (stream != null)
                {
                    char[] charArr = new char[100];
                    int x = reader.Read(charArr, 0, 100);
                    string str = new string(charArr);

                    //string str = await reader.ReadLineAsync();
                    if (str.Contains("ClientStopped"))
                    {
                        MessageBox.Show("Your Client Stopped Playing!!");
                        this.tcpClient.Dispose();
                        streamingThread.Abort();
                        //this.tcpClient.Close();

                        //MessageBox.Show(this.tcpClient.Connected.ToString());
                    }

                    else if (str.Contains(","))
                    {

                        string[] temp = str.Split(',');
                        name = temp[0];

                        //room = temp[1];
                        /*MessageBox.Show(str);*/
                    }
                    ////////////////////////accepting their request to join the room////////////////
                    else if (str.Contains("Room1") && this.room == null)
                    {
                        this.room = "1";


                    }
                    else if (str.Contains("Room2") && this.room == null)
                    {
                        this.room = "2";
                    }
                    else if (str.Contains("Room3") && this.room == null)
                    {
                        this.room = "3";
                    }
                    //////////////////////////////////////////////////////////////////////
                    if (this.room == "1")
                    {

                        if (str.StartsWith("$"))
                        {
                            string full = str.Split('*')[0].Trim('$');
                            string row = full.Split('/')[0];
                            string col = full.Split('/')[1];
                            this.server.room1.getHost().writer.Write($"@{row}/{col}*");
                            this.server.room1.getGuest().writer.Write($"@{row}/{col}*");
                        }
                    }

                }


            }
        }

    }
}
