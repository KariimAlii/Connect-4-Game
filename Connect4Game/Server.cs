using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class Server : Form
    {
        TcpListener listener;
        List<Client> clients;
        SynchronizationContext context;
        Thread receivethread;
        public Room room1 { get; set; }
        public Room room2 { get; set; }
        public Room room3 { get; set; }



        public Server()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            listener = new TcpListener(ip, 10000);
            context = SynchronizationContext.Current;
            clients = new List<Client>();
            room1 = new Room();
            room2 = new Room();
            room3 = new Room();

        }



        private void AcceptConnections()
        {
            while (true)
            {
                TcpClient serverClient = listener.AcceptTcpClient();
                context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                context.Post((object obj) => StatusBox.Text = "Connection Accepted!", null);
                clients.Add(new Client(serverClient));
            }
        }


        private void ListenBtn_Click(object sender, EventArgs e)
        {
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
            //clients.ForEach(item => { MessageBox.Show(item.ToString()); });

            StopListening();
        }
        private void StopListening()
        {
            //writer.Write("ServerStopped");
            //Thread.Sleep(5000);
            //backgroundWorker1.CancelAsync();
            clients.ForEach((client) =>
            {
                //client.backgroundWorker2.CancelAsync();
                client.tcpClient.Dispose();

            });
            receivethread.Abort();
            listener.Stop();
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Server Stopped...", null);
        }



        public void UpdateClients()
        {
            context.Post((object obj) => clients_list.Items.Clear(), null);
            clients.ForEach(client =>
            {
                if (client.tcpClient.Connected)
                {
                    context.Post((object obj) => clients_list.Items.Add(client.name), null);

                    ////////////////assign host and guest to client depending on their room;/////////////// 
                    if (client.room == "1")
                    {
                        if (room1.getHost() == null)
                        {
                            room1.setHost(ref client);

                        }
                        else if (room1.getGuest() == null && room1.getHost() != client)
                        {
                            room1.setGuest(ref client);
                            room1.getHost().writer.Write("Open");
                            room1.getGuest().writer.Write("Open");

                        }
                        else if (room1.getGuest() != client && room1.getHost() != client)
                        {
                            room1.watcherList.Add(client);
                        }

                    }
                    else if (client.room == "2")
                    {
                        if (room2.getHost() == null)
                        {
                            room2.setHost(ref client);

                        }
                        else if (room2.getGuest() == null && room2.getHost() != client)
                        {
                            room2.setGuest(ref client);

                        }
                        else if (room2.getGuest() != client && room2.getHost() != client)
                        {
                            room2.watcherList.Add(client);
                        }
                    }
                    else if (client.room == "3")
                    {
                        if (room3.getHost() == null)
                        {
                            room3.setHost(ref client);

                        }
                        else if (room3.getGuest() == null && room3.getHost() != client)
                        {
                            room3.setGuest(ref client);

                        }
                        else if (room3.getGuest() != client && room3.getHost() != client)
                        {
                            room3.watcherList.Add(client);
                        }

                    }
                    ////////broadcasting to client to update their lists//////////

                    if (room1.getHost() != null && room1.getGuest() != null)
                    {
                        client.writer.Write($"R1{room1.getHost().name}|{room1.getGuest().name}");
                        //Thread.Sleep(100);
                    }
                    if (room2.getHost() != null && room2.getGuest() != null)
                    {
                        client.writer.Write($"R2{room2.getHost().name}|{room2.getGuest().name}");
                        //Thread.Sleep(100);
                    }
                    if (room3.getHost() != null && room3.getGuest() != null)
                    {
                        client.writer.Write($"R3{room3.getHost().name}|{room3.getGuest().name}");
                        //Thread.Sleep(100);
                    }
                }
                else
                {
                    context.Post((object obj) =>
                    {
                        clients_list.Items.Remove(client.name);
                        clients.Remove(client);
                    }, null);
                }


            });

        }

        private void OpenGame_Click(object sender, EventArgs e)
        {
            Task.Run(() => Application.Run(new GameForm()));
        }

        private void connected_clients_Click(object sender, EventArgs e)
        {

            clients.ForEach((client) =>
            {
                if (client.tcpClient.Connected)
                {

                    MessageBox.Show($"{room1.getHost().name},{room1.getGuest().name}");
                    MessageBox.Show($"{room2.getHost().name},{room2.getGuest().name}");
                    MessageBox.Show($"{room3.getHost().name},{room3.getGuest().name}");
                }
                else
                {
                    MessageBox.Show($"{client.name} is Disconnected!!!!!");
                }

            });
        }
    }
}


