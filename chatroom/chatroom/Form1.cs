using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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
        public decimal portnum2;
        //username
        public string un;
        //is the client also the server
        public bool isServer;
    }
    struct idpair
    {
        Socket socket;
        string id;
    };


    public partial class Form1 : Form
    {
        public chatinfo ci = new chatinfo();
        UDPSocket s;
        public Form1()
        {
            InitializeComponent();

            //default ui for port selection, portnum changed on portui value changed
            portui.Value = 27000;
            ci.portnum = 27000;
            port2.Value = 26000;
            ci.portnum2 = 26000;
            
        }


        public void Adduser(string p)
        {
            UserBox.Invoke(new MethodInvoker(delegate { UserBox.Items.Add(p); }));
        }
        private void enterchat(object sender, EventArgs e)
        {
            if (TB.Text != "")
            {
                //sets up form2 (actual chatroom)
                ci.un = TB.Text;
                ci.portnum2 = port2.Value;
                ci.isServer = hostbox.Checked;
                Form2 f2 = new Form2(ci);
                
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

        private void refresh(object sender, EventArgs e)
        {
            s = new UDPSocket();
            s.f1 = this;
            s.ClientTcp("127.0.0.3", 3399);
            
            s.Send(TB.Text + '\0');
        }

        private void requestUser(object sender, EventArgs e)
        {
            s.Send(UserBox.SelectedItem.ToString());
            Adduser(UserBox.SelectedItem.ToString());
        }

        private void YesButton(object sender, EventArgs e)
        {
            s.Send('Y'.ToString());
        }

        private void bp(object sender, EventArgs e)
        {
            s.Send(messbox.Text + '\0');
        }
    }
}
