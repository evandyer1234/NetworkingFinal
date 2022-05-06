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

namespace chatroom_CSharp
{

    public unsafe struct _DATA
    {
        public new fixed char ID[128];
        public new fixed char parnter[128];
        public new fixed char buf[128];
    }

    public partial class Form1 : Form
    {
        public _DATA data;
        public Socket _clientsocket;
        public bool waiting = false;

        public string id;

        public Form2 f2;
        public Form1()
        {
            
            InitializeComponent();
            //_clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //_clientsocket.Connect(IPAddress.Parse("127.0.0.1"), 3399);
            UDPSocket s = new UDPSocket()
            f2 = new Form2();
            f2.f1 = this;

            waiting = true;

            while (waiting)
            {

            }

            


        }
    }
}
