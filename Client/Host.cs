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
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            reader = new StreamReader(stream);
            Task.Run(() => ReceiveMessages());
            writer.AutoFlush = true;
            string tempname = namebox.Text;
            string tempnum = numberbox.Text;
            //sending username and number (here number represents any property that would be implemented futher
            writer.Write($"{tempname},{tempnum}");
            


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
                context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
                context.Post((object obj) => StatusBox.Text = "Disconnected", null);
                MessageBox.Show("Server Stopped!");
                Disconnect();
            }
        }
        private async void Disconnect()
        {
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            await  writer.WriteAsync("ClientStopped");
            client.Close();
        }
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

      
    }
}
