﻿using System;
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

        
        private  async void AcceptConnections()
        {
            while (true)
            {
                TcpClient serverClient = await listener.AcceptTcpClientAsync();
              
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
                Invoke(new Action(() => {
                    clients.ForEach(client =>
                    {
                        if(client.name == temp.name)
                        {
                            clients_list.Items.Add(client.name + client.number);
                        }
                        
                    });
                }));
                


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
            writer.Write("ServerStopped");
            //Thread.Sleep(5000);
            //backgroundWorker1.CancelAsync();
            listener.Stop();
            context.Post((object obj) => StatusBox.BackColor = Color.IndianRed, null);
            context.Post((object obj) => StatusBox.Text = "Server Stopped...", null);
        }

       
    }
}
