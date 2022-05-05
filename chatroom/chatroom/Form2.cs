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

//https://gist.github.com/darkguy2008/413a6fea3a5b4e67e5e0d96f750088a9
namespace chatroom
{
    public partial class Form2 : Form
    {

        public chatinfo ci;

        
        UDPSocket s;
        UDPSocket c;
        UdpClient udpClient;
        public IPEndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);

        public Form2(chatinfo ch)
        {
            InitializeComponent();

            s = new UDPSocket();
           
            s.f2 = this;
            //udpClient = new UdpClient(decimal.ToInt32(ch.portnum));
            
            if (ch.isServer)
            {
                
                //s.Server("127.0.0.1", decimal.ToInt32(ci.portnum));
                s.Server("127.0.0.1", decimal.ToInt32(ch.portnum));
            }
            c = new UDPSocket();
            
            c.f2 = this;
            c.Client("127.0.0.1", decimal.ToInt32(ch.portnum));
            
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void EnterPressed(object sender, EventArgs e)
        {
            if (tb.Text != "")
            {
                //var b = {"ID" : ci.un.ToString(), "msg" : }
                c.Send(ci.un + ": " + tb.Text);
                tb.Text = "";
            }
        }

        //should send the message to the server and display it for both clients 
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

        private void bg_work(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //e.Result = messagetest();
            
            //Byte[] receiveBytes = udpClient.Receive(ref epFrom);
            //string returnData = Encoding.ASCII.GetString(receiveBytes);
            //AddMessage(returnData);
        }

        private void bg_reset(object sender, RunWorkerCompletedEventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
