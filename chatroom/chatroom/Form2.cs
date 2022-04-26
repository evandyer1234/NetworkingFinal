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
        public chatinfo ci = new chatinfo();

        UdpClient _server = null;
        IPEndPoint _client = null;

        public Form2()
        {
            InitializeComponent();
            _server = new UdpClient("127.0.0.1", 16000);
            
            _client = new IPEndPoint(IPAddress.Any, 0);         
        }

        private void EnterPressed(object sender, EventArgs e)
        {   
            if (tb.Text != "")
            {
                CreateMessage(ci.us, tb.Text);
                tb.Text = "";
            }
        }

        //builds the message that will be displayed
        public void CreateMessage(int t, string s)
        {
            if (t == ci.con || t == ci.us)
            {
                string p = ci.un + ": " + tb.Text;
                AddMessage(p);
            }
        }
         
        //should send the message to the server and display it for both clients 
        public void AddMessage(string p)
        {
            //_server.Send(Encoding.ASCII.GetBytes(p), p.Length);
            //byte[] data = _server.Receive(ref _client);
            //string msg = Encoding.ASCII.GetString(data, 0, data.Length);

            //LB.Items.Add(msg);
            LB.Items.Add(p);
        }

        private void Leavebtn(object sender, EventArgs e)
        {          
            _server.Close();
            this.Close();   
        }
    }
}
