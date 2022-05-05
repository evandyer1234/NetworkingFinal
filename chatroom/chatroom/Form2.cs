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

        //UdpClient _server = null;
        //IPEndPoint _client = null;
        UDPSocket s = new UDPSocket();
        UDPSocket c = new UDPSocket();

        public Form2()
        {
            InitializeComponent();

            

            if (ci.isServer)
            {
               
                s.Server("127.0.0.1", decimal.ToInt32(ci.portnum));
            }
           
            c.Client("127.0.0.1", decimal.ToInt32(ci.portnum));

            //backgroundWorker1.DoWork += new DoWorkEventHandler(bg_work);

            backgroundWorker1.RunWorkerAsync();
            //c.Send(ci.un + " Joined");

            //Console.ReadKey();
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
                //AddMessage(p);
                c.Send(p);
            }
        }
         
        //should send the message to the server and display it for both clients 
        public void AddMessage(string p)
        {
            //_server.Send(Encoding.ASCII.GetBytes(p), p.Length);
            //byte[] data = _server.Receive(ref _client);
            //string msg = Encoding.ASCII.GetString(data, 0, data.Length);

            //LB.Items.Add(msg);
            if (p != "")
            {
                LB.Invoke(new MethodInvoker(delegate { LB.Items.Add(p); }));
            }
            
        }

        private void Leavebtn(object sender, EventArgs e)
        {          
            //_server.Close();
            this.Close();   
        }

        private void bg_work(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //string s = c.Receive();
            //string s = "yoyo";
            //AddMessage(s);


            //e.Result = messagetest();
            Thread.Sleep(500);
           // Task t = Task.Run(() => {
                e.Result = c.Receive();
           // });
           // t.Wait();
            AddMessage(e.Result.ToString());
            Thread.Sleep(500);
        }

        public bool messagetest()
        {
            string s = "yoyo";
            AddMessage(s);
            return true;
        }

        private void bg_reset(object sender, RunWorkerCompletedEventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
