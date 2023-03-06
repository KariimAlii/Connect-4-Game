using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class Server : Form
    {
        #region Fields
        TcpListener listener;
        public List<Client> clients;
        SynchronizationContext context;
        Thread receivethread;
        bool isListening = true;
        public Room room1 { get; set; }
        public Room room2 { get; set; }
        public Room room3 { get; set; }
        #endregion

        #region Constructor
        public Server()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            listener = new TcpListener(ip, 5000);
            context = SynchronizationContext.Current;
            clients = new List<Client>();
            room1 = new Room();
            room2 = new Room();
            room3 = new Room();
        }
        #endregion

        #region Accepting Client Connections
        private void AcceptConnections()
        {
            while (isListening)
            {
                try
                {
                    TcpClient serverClient = listener.AcceptTcpClient();
                    context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                    context.Post((object obj) => StatusBox.Text = "Connection Accepted!", null);
                    Client tempClient = new Client(serverClient);
                    tempClient.server = this;
                    clients.Add(tempClient);
                }
                catch
                {

                }

            }
        }
        #endregion

        #region Stop Server Listening
        private void StopListening()
        {
            this.isListening = false;
            clients.ForEach((client) => client.tcpClient.Dispose());
            receivethread.Abort();
            listener.Stop();
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Server Stopped...", null);
        }
        #endregion

        #region Controls
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            isListening = true;
            listener.Start();

            Task.Run(() => AcceptConnections());
            context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
            context.Post((object obj) => StatusBox.Text = "Listening...", null);

            receivethread = new Thread(() =>
            {
                while (true)
                {
                    UpdateClients();
                    Thread.Sleep(1000);
                }
            });
            receivethread.IsBackground = true;
            receivethread.Start();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopListening();
        }
        #endregion

        #region Updating Clients & Rooms Info 
        public void UpdateClients()
        {
            context.Post((object obj) => clients_list.Items.Clear(), null);
            Thread.Sleep(100);
            clients.ToList().ForEach(client =>
            {
                if (client.tcpClient.Connected)
                {
                    context.Post((object obj) => clients_list.Items.Add(client.name), null);
                    #region Assigning Each Room Guest & Host
                    if (client.room == "1")
                    {
                        if (room1.getHost() == null)
                        {
                            room1.setHost(client);
                            client.writer.Write($"R1H{client.name}*");

                        }
                        else if (room1.getGuest() == null && room1.getHost() != client)
                        {
                            room1.setGuest(client);
                            room1.getGuest().writer.Write($"R1G{client.name}*");
                            room1.getHost().writer.Write("Open");
                            room1.getGuest().writer.Write("Open");


                        }
                        else if (room1.getHost() != client && room1.getGuest() != client)
                        {
                            if (!room1.watcherList.Contains(client))
                            {
                                string combinedString = string.Join("", client.myRoom.Board);
                                client.writer.Write($"^^{combinedString}");
                                room1.watcherList.Add(client);
                                room1.watcherList.ToList().ForEach((watcher) =>
                                {
                                    if (watcher.tcpClient.Connected)
                                    {
                                        watcher.writer.Write($"R1W{client.name}*");
                                        watcher.writer.Write("Open");
                                    }

                                });

                            }

                        }

                    }
                    else if (client.room == "2")
                    {
                        if (room2.getHost() == null)
                        {
                            room2.setHost(client);
                            client.writer.Write($"R2H{client.name}*");

                        }
                        else if (room2.getGuest() == null && room2.getHost() != client)
                        {
                            room2.setGuest(client);
                            room2.getGuest().writer.Write($"R2G{client.name}*");
                            room2.getHost().writer.Write("Open");
                            room2.getGuest().writer.Write("Open");


                        }
                        else if (room2.getHost() != client && room2.getGuest() != client)
                        {
                            if (!room2.watcherList.Contains(client))
                            {
                                string combinedString = string.Join("", client.myRoom.Board);
                                client.writer.Write($"^^{combinedString}");
                                room2.watcherList.Add(client);
                                room2.watcherList.ToList().ForEach((watcher) =>
                                {
                                    if (watcher.tcpClient.Connected)
                                    {
                                        watcher.writer.Write($"R2W{client.name}*");
                                        watcher.writer.Write("Open");
                                    }

                                });


                            }

                        }

                    }
                    if (client.room == "3")
                    {
                        if (room3.getHost() == null)
                        {
                            room3.setHost(client);
                            client.writer.Write($"R3H{client.name}*");

                        }
                        else if (room3.getGuest() == null && room3.getHost() != client)
                        {
                            room3.setGuest(client);
                            room3.getGuest().writer.Write($"R3G{client.name}*");
                            room3.getHost().writer.Write("Open");
                            room3.getGuest().writer.Write("Open");


                        }
                        else if (room3.getHost() != client && room3.getGuest() != client)
                        {
                            if (!room3.watcherList.Contains(client))
                            {
                                string combinedString = string.Join("", client.myRoom.Board);
                                client.writer.Write($"^^{combinedString}");
                                room3.watcherList.Add(client);
                                room3.watcherList.ToList().ForEach((watcher) =>
                                {
                                    if (watcher.tcpClient.Connected)
                                    {
                                        watcher.writer.Write($"R3W{client.name}*");
                                        watcher.writer.Write("Open");
                                    }

                                });


                            }

                        }

                    }
                    #endregion
                    #region Broadcast to All Players to Update Their Room Lists
                    if (room1.getHost() != null && room1.getGuest() != null)
                    {
                        client.writer.Write($"Room1{room1.getHost().name},{room1.getGuest().name}*");
                    }
                    if (room2.getHost() != null && room2.getGuest() != null)
                    {
                        client.writer.Write($"Room2{room2.getHost().name},{room2.getGuest().name}*");
                    }
                    if (room3.getHost() != null && room3.getGuest() != null)
                    {
                        client.writer.Write($"Room3{room3.getHost().name},{room3.getGuest().name}*");
                    }
                    #endregion
                }
                else
                {
                    context.Post((object obj) => clients_list.Items.Remove(client.name), null);
                    clients.Remove(client);
                    client.tcpClient.Dispose();
                }
            });
        }
        #endregion

    }
}


