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

namespace Client
{
    public partial class Host : Form
    {
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        Stream stream;
        SynchronizationContext context;
        public Host()
        {
            InitializeComponent();

            context = SynchronizationContext.Current;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            client = new TcpClient("192.168.1.5", 5000);
            stream = client.GetStream();
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            reader = new StreamReader(stream);
            Task.Run(() => ReceiveMessages());
        }
        private async void ReceiveMessages()
        {
            char[] charArr = new char[100];
            int x = await reader.ReadAsync(charArr, 0, 100);
            string str = new string(charArr);
            if (str.Contains("Connected"))
            {
                context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
                context.Post((object obj) => StatusBox.Text = str, null);
            }
            else if (str.Contains("ServerStopped"))
            {
                Disconnect();
                context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
                context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            }
        }
        private void Disconnect()
        {
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            writer.Write("ClientStopped");
            client.Close();
        }
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
    }
}
