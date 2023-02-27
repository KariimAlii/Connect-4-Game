using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Connect4Game
{
    internal class Client
    {
         public TcpClient tcpClient;
        public string name { get; set; }
        public string number { get; set; }
        NetworkStream stream;
        StreamWriter writer;
        StreamReader reader;
        public BackgroundWorker backgroundWorker2;

        public Client(TcpClient tcpClient,string name,string number)
        {
            this.tcpClient = tcpClient;
            this.name = name;
            this.number = number;
             stream = tcpClient.GetStream();
             writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.Write("Connected");
             reader = new StreamReader(stream);
            backgroundWorker2 = new BackgroundWorker();
            backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            Task.Run(() => ReceiveMessages());
            backgroundWorker2.WorkerSupportsCancellation= true;
            
        }
        ~Client() {
            backgroundWorker2.CancelAsync();
            MessageBox.Show("A");
            tcpClient.Close();
            
        }

        
        private async void ReceiveMessages()
        {
            if (backgroundWorker2.IsBusy == false)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                if (stream != null)
                {
                    char[] charArr = new char[100];
                    int x = reader.Read(charArr, 0, 100);
                    string str = new string(charArr);
                    if (str.Contains("ClientStopped"))
                    {
                        MessageBox.Show("Your Client Stopped Playing!!");
                        this.tcpClient.Close();
                        MessageBox.Show(this.tcpClient.Connected.ToString());
                        
                    }

                    else if (str.Contains(","))
                    {

                        string[] temp = str.Split(',');
                        name = temp[0];
                        number = temp[1];
                        /*MessageBox.Show(str);*/
                    }

                }

            }
        }
    }
}
