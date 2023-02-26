using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class Server : Form
    {
        TcpListener listener;
        NetworkStream stream;
        StreamWriter writer;
        StreamReader reader;
        SynchronizationContext context;
        public Server()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 5 });
            listener = new TcpListener(ip, 5000);

            context = SynchronizationContext.Current;
        }

        private async void ReceiveMessages()
        {
            char[] charArr = new char[100];
            int x = await reader.ReadAsync(charArr, 0, 100);
            string str = new string(charArr);

            if (str.Contains("ClientStopped"))
            {
                MessageBox.Show("Your Client Stopped Playing!!");
            }
        }
        private void AcceptConnections()
        {
            while (true)
            {
                TcpClient serverClient = listener.AcceptTcpClient();
                stream = serverClient.GetStream();

                writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.Write("Connected");

                reader = new StreamReader(stream);

                context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                context.Post((object obj) => StatusBox.Text = "Connection Accepted!", null);

                Task.Run(() => ReceiveMessages());
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
            StopListening();
        }
        private void StopListening()
        {
            writer.Write("ServerStopped");
            //Thread.Sleep(5000);
            listener.Stop();

            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Server Stopped...", null);
        }
    }
}
