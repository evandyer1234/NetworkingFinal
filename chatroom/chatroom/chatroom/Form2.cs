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
    
    unsafe struct DATA
    {
        public fixed char id[64];
        public fixed char buf[64];
    }

    unsafe struct MSG
    {
        public fixed char msg[64];
        public fixed char id[64];
        public fixed char rec[64];
    }

    public partial class Form2 : Form
    {
        public int user;
        public string un;
        public int con;
       
        UdpClient _server = null;
        IPEndPoint _client = null;

        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;

        public Form2()
        {
            InitializeComponent();
            //_server = new UdpClient("127.0.0.1", 16000);

            // _client = new IPEndPoint(IPAddress.Any, 0);
            UDPSocket s = new UDPSocket();
            s.Server("127.0.0.1", 27000);

            UDPSocket c = new UDPSocket();
            c.Client("127.0.0.1", 27000);
            c.Send("TEST!");

            //Console.ReadKey();
        }

        private void EnterPressed(object sender, EventArgs e)
        {   
            if (tb.Text != "")
            {
                AddMessage(user, tb.Text);
                tb.Text = "";
            }
        }

        public void AddMessage(string s)
        {
            LB.Items.Add(s);
        }

        public void AddMessage(int t, string s)
        {
            if (t == con || t == user)
            {
                //_server.Send(Encoding.ASCII.GetBytes(s), s.Length);
                //byte[] data = _server.Receive(ref _client);
                //string msg = Encoding.ASCII.GetString(data, 0, data.Length);

                //string p = un + ": " + msg;
                string p = un + ": " + tb.Text;
                LB.Items.Add(p);
            }
        }

        private void Leavebtn(object sender, EventArgs e)
        {          
            _server.Close();
            this.Close();   
        }

       

        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        public void Server(string address, int port)
        {
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            Receive();
        }

        public void Client(string address, int port)
        {
            _socket.Connect(IPAddress.Parse(address), port);
            Receive();
        }

        public void Send(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndSend(ar);
                Console.WriteLine("SEND: {0}, {1}", bytes, text);
            }, state);
        }

        private void Receive()
        {
            _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                //Console.WriteLine("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
                //AddMessage("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
                AddMessage(Encoding.ASCII.GetString(so.buffer, 0, bytes));
            }, state);
        }

    }
}
