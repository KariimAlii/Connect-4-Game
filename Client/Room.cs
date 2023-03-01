using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Room : Form
    {
        public string host;
        public string guest { get; set; }

        //List<Client> watcher = new List<Client>();
        public string Room_number { set; get; }
        public Room()
        {
            InitializeComponent();
        }
    }
}
