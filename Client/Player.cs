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
    public partial class Player : Form
    {
        TcpClient client;

        Stream stream;
        StreamReader reader;
        StreamWriter writer;

        SynchronizationContext context;
        public Player()
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
            string tempname = namebox.Text;
            string tempnum = numberbox.Text;
            writer.Write($"{tempname},{tempnum}");

            context.Post((object obj) => StatusBox.BackColor = Color.Chartreuse, null);
            context.Post((object obj) => StatusBox.Text = "Connected..", null);


            reader = new StreamReader(stream);

            Task.Run(() => ReceiveMessages());

            //sending username and number (here number represents any property that would be implemented futher

        }
        private async void ReceiveMessages()
        {

            if (stream != null)
            {
                char[] charArr = new char[100];
                int x = await reader.ReadAsync(charArr, 0, 100);
                string str = new string(charArr);
                //string str = await reader.ReadLineAsync();
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
        }
        private async void Disconnect()
        {
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Disconnected", null);
            await writer.WriteAsync("ClientStopped");
            //writer.Write("ClientStopped");

            client.Close();
        }
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Disconnect();
        }


    }
}
