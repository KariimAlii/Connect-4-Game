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
        public Room()
        {
            InitializeComponent();


            
            
        }
        public string Owner { set; get; }
        public string Player2 { set; get; }
        public string watcher { set; get; }   

        
        

    }



    

}

