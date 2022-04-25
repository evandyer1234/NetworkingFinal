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
        public int user;
        public string un;
        public int con;
       
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
                AddMessage(user, tb.Text);
                tb.Text = "";
            }
        }

        public void AddMessage(int t, string s)
        {
            if (t == con || t == user)
            {
                //_server.Send(Encoding.ASCII.GetBytes(s), s.Length);
                //byte[] data = _server.Receive(ref _client);
                //string msg = Encoding.ASCII.GetString(data, 0, data.Length);

                string p = un + ": " + tb.Text;
                LB.Items.Add(p);
            }
        }

        private void Leavebtn(object sender, EventArgs e)
        {          
            _server.Close();
            this.Close();   
        }
    }
}
