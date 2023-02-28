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
        NetworkStream stream;
        StreamWriter writer;
        StreamReader reader;
        SynchronizationContext context;
        Thread receivethread;
        Client temp;
        string tempnum;
        string tempstr;

        public Server()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            listener = new TcpListener(ip, 5000);
            context = SynchronizationContext.Current;
            clients = new List<Client>();
        }


        private void AcceptConnections()
        {
            while (true)
            {
                TcpClient serverClient = listener.AcceptTcpClient();

                context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                context.Post((object obj) => StatusBox.Text = "Connection Accepted!", null);
                //ReceiveMessages();
                temp = new Client(serverClient, tempstr, tempnum);
                clients.Add(temp);
                //if (clients[0].tcpClient.Connected)
                //{
                //    MessageBox.Show(clients[0].name);
                //}
                Thread.Sleep(100);
                Invoke(new Action(() =>
                {
                    clients.ForEach(client =>
                    {
                        if (client.name == temp.name)
                        {
                            clients_list.Items.Add(client.name + client.number);
                        }
                        if (!client.tcpClient.Connected)
                        {
                            clients.Remove(client);
                            int index = clients.IndexOf(client);
                            clients.RemoveAt(index);
                            clients_list.Items.RemoveAt(index);
                            clients_list.Refresh();
                        }

                    });
                }));
                //clients.Disconnected += (sender, args) =>
                //{
                //    // Find the index of the disconnected client in the connectedPlayers list


                //    // Remove the disconnected client from the connectedPlayers list


                //    // Remove the corresponding name from the ListBox

                //};

                //clients[0].tcpClient.Connected
                if (!backgroundWorker1.IsBusy)
                {
                    MessageBox.Show("in backgroundworker1");
                    backgroundWorker1.RunWorkerAsync();
                }

            }


        }


        private void ListenBtn_Click(object sender, EventArgs e)
        {
            listener.Start();

            Task.Run(() => AcceptConnections());
            context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
            context.Post((object obj) => StatusBox.Text = "Listening...", null);

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
                client.backgroundWorker2.CancelAsync();
                client.tcpClient.Dispose();

            });
            listener.Stop();
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Server Stopped...", null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                Invoke(new Action(() =>
                {
                    clients.ForEach(client =>
                    {

                        if (!client.tcpClient.Connected)
                        {
                            MessageBox.Show(client.name);
                            //clients.Remove(client);
                            int index = clients.IndexOf(client);
                            clients.RemoveAt(index);
                            clients_list.Items.RemoveAt(index);
                            clients_list.Refresh();
                        }

                    });
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room room1 = new Room();
            int count = 0;
            clients.ForEach(client =>
            {

                if (room1.Owner==null)
                {
                    room1.Owner = client.name;
                    MessageBox.Show("owner in ");

                }
                else if (room1.Player2==null)
                {
                    room1.Player2 = client.name;
                    MessageBox.Show("player2 in ");
                }
                else if (room1.watcher ==null)
                {
                    room1.watcher = client.name;
                    MessageBox.Show("watcher in ");
                }
                else
                {
                    MessageBox.Show("Room is full");
                }
            });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) // we need this background worker to be a thread
        {
            MessageBox.Show("background worker work done");
        }
    }
}


