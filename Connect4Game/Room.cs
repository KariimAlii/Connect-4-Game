using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Game
{
    public partial class Room : Form
    {
        public Client host;
        public Client guest { get; set; }

        List<Client> watcher = new List<Client>();
        public string Room_number { set; get; }
        public Room()
        {
            InitializeComponent();
        }
    }
}
