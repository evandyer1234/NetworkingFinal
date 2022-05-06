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
    public partial class Form2 : Form
    {
        public chatinfo ci;
 
        UDPSocket s;
        UDPSocket c;
        //UdpClient udpClient;

        public Form2(chatinfo ch)
        {
            InitializeComponent();

            s = new UDPSocket();
            s.f2 = this;
            s.Server(ad.addr, decimal.ToInt32(ch.portnum2));

            //udpClient = new UdpClient(decimal.ToInt32(ch.portnum));
            c = new UDPSocket();      
            c.f2 = this;
            c.Client(ad.addr, decimal.ToInt32(ch.portnum));            
        }

        //sends a message to the server and adds the message to the users window
        private void EnterPressed(object sender, EventArgs e)
        {
            if (tb.Text != "")
            {
                c.Send(ci.un + ": " + tb.Text);

                AddMessage(ci.un + ": " + tb.Text);
                tb.Text = "";
            }
        }

        // adds a message to the ListBox 
        public void AddMessage(string p)
        {
            if (p != "")
            {
                LB.Invoke(new MethodInvoker(delegate { LB.Items.Add(p); }));               
            }   
        }

        private void Leavebtn(object sender, EventArgs e)
        {          
            s._socket.Close();
            this.Close();   
        }
    }
}
