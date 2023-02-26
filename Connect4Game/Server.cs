using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class Server : Form
    {
        TcpListener listener;
        public Server()
        {
            InitializeComponent();

            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 5 });
            listener = new TcpListener(ip, 5000);
        }
    }
}
