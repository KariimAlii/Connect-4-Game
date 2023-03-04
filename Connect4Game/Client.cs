﻿using System;
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
        bool isConnected = true;
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
            while (isConnected)
            {
                if (stream != null)
                {
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
                    //////////////////////////////////////////////////////////////////////
                    if (this.room == "1")
                    {

                        if (str.StartsWith("$"))
                        {

                            string full = str.Split('*')[0].Trim('$');
                            string playerName = str.Split('*')[1];
                            string row = full.Split('/')[0];
                            string col = full.Split('/')[1];
                            if (row.StartsWith("G"))
                            {
                                row = row.Trim('G');
                                this.server.room1.getHost().writer.WriteLine($"@{row}/{col}*{playerName}");
                            }
                            else if (row.StartsWith("H"))
                            {
                                row = row.Trim('H');
                                this.server.room1.getGuest().writer.WriteLine($"@{row}/{col}*{playerName}");
                            }

                        }
                        if (str.StartsWith("PlayAgain"))
                        {

                        }
                        if (str.StartsWith("Exit"))
                        {
                            string status = str.Split('-')[1];
                            if (status.Contains("Host"))
                            {
                                this.server.needHost1 = true;
                                this.server.needGuest1 = true;
                                this.server.clients.Remove(this.myRoom.getGuest());
                                this.server.clients.Remove(this);
                                this.myRoom.getGuest().writer.Write("CloseYourApp");
                                Thread.Sleep(2000);
                                this.myRoom.getGuest().tcpClient.Close();
                                MessageBox.Show("Set Host to null");
                            }
                            else if (status.Contains("Guest"))
                            {
                                this.server.needGuest1 = true;
                                this.server.clients.Remove(this);
                                MessageBox.Show("Set Guest to null");
                            }
                            isConnected = false;
                            this.tcpClient.Close();
                            //this.tcpClient.Dispose();

                        }

                    }

                }


            }
        }

    }
}


//switch (status)
//{
//    case "Host":

//        break;
//    case "Guest":

//        break;
//    default:

//        break;
//}
