using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class Room : Form
    {
        private Client host;
        private Client guest;
        public List<string> Board;
        public List<Client> watcherList = new List<Client>();
        public string Room_number { set; get; }
        public Room()
        {
            InitializeComponent();
            Board = new List<string>();

        }
        public Client getHost() { return this.host; }
        public Client getGuest() { return this.guest; }
        public void setHost(ref Client host)
        {
            this.host = host;
        }
        public void setGuest(ref Client guest)
        {
            this.guest = guest;
        }

    }
}

