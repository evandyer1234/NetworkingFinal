using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatroom
{
    public struct chatinfo
    {
        //user number
        public int us;
        //connect to this user
        public int con;
        //port number
        public decimal portnum;
        //username
        public string un;
        public bool isServer;
    }

    public partial class Form1 : Form
    {
        public chatinfo ci = new chatinfo();
        
        public Form1()
        {
            InitializeComponent();

            //default ui for port selection, portnum changed on portui value changed
            portui.Value = 27000;
            ci.portnum = 27000;
        }

        private void enterchat(object sender, EventArgs e)
        {
            if (TB.Text != "")
            {
                //sets up form2 (actual chatroom)
                Form2 f2 = new Form2();
                ci.un = TB.Text;
                ci.isServer = hostbox.Checked;
                f2.ci = ci;
                      
                f2.Show();
            }
        }
        
        //changes enabled buttons so the user can't connect to themselves
        public void buttonreset(int i)
        {
            radioButton5.Enabled = true;
            radioButton8.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;

            if (i == 1)
            {
                radioButton5.Enabled = false;
            }
            else if (i == 2)
            {
                radioButton6.Enabled = false;
            }
            else if (i == 3)
            {
                radioButton7.Enabled = false;
            }
            else if (i == 4)
            {
                radioButton8.Enabled = false;
            }
        }

        private void rbcheck1(object sender, EventArgs e)
        {
            ci.us = 1;
            buttonreset(1);
            
        }

        private void rbcheck2(object sender, EventArgs e)
        {
            ci.us = 2;
            buttonreset(2);
        }

        private void rbcheck3(object sender, EventArgs e)
        {
            ci.us = 3;
            buttonreset(3);
        }

        private void rbcheck4(object sender, EventArgs e)
        {
            ci.us = 4;
            buttonreset(4);
        }

        private void cn1(object sender, EventArgs e)
        {
            ci.con = 1;
        }

        private void cn2(object sender, EventArgs e)
        {
            ci.con = 2;
        }

        private void cn3(object sender, EventArgs e)
        {
            ci.con = 3;
        }

        private void cn4(object sender, EventArgs e)
        {
            ci.con = 4;
        }

        private void portchange(object sender, EventArgs e)
        {
            ci.portnum = portui.Value;
        }
    }
}
