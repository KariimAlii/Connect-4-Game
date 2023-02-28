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
                temp = new Client(serverClient);
                clients.Add(temp);
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
                    context.Post((object obj) => clients_list.Items.Add(client), null);
                }
                else
                {
                    context.Post((object obj) =>
                    {
                        clients_list.Items.Remove(client);
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
                    MessageBox.Show($"{client.name} is connected");
                }
                else
                {
                    MessageBox.Show($"{client.name} is Disconnected!!!!!");
                }
            });
        }
    }
}


