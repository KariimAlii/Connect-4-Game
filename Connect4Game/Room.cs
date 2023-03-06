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
        #region Fields
        private Client host;
        private Client guest;
        public List<string> Board;
        public List<Client> watcherList;
        public string Room_number { set; get; }
        #endregion
        #region Constructor
        public Room()
        {
            InitializeComponent();
            Board = new List<string>();
            watcherList = new List<Client>();
        }
        #endregion
        #region Getters & Setters
        public Client getHost() { return this.host; }
        public Client getGuest() { return this.guest; }
        public void setHost(Client host)
        {
            this.host = host;
        }
        public void setGuest(Client guest)
        {
            this.guest = guest;
        }
        #endregion

    }
}

