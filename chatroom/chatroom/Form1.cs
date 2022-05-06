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
using System.Text.Json;


namespace chatroom
{
    public struct chatinfo
    {
        //user number
        //public int us;
        //connect to this user
        public int con;
        //port number
        public decimal portnum;
        public decimal portnum2;
        //username
        public string un;
        //is the client also the server
        //public bool isServer;
    }
    struct idpair
    {
        Socket socket;
        string id;
    };

    [Serializable]
    public unsafe struct DATA
    {
        public string ID;
        public string partnerID;
        public string buf;

    };

    public partial class Form1 : Form
    {
        DATA msg;

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
                ci.portnum = portui.Value;
                ci.portnum2 = port2.Value;
                
                Form2 f2 = new Form2(ci);

                f2.ci = ci;

                f2.Show();
            }
        }

        //start a chat without needing contents of form 1
        public void startchat(chatinfo co)
        {
           
                //sets up form2 (actual chatroom)
                ci.un = co.un;
                ci.portnum = co.portnum;
                ci.portnum2 = co.portnum2;

                Form2 f2 = new Form2(ci);

                f2.ci = ci;

                f2.Show();
            
        }

        //poor naming, joins the server with Tcp
        private void refresh(object sender, EventArgs e)
        {
            s = new UDPSocket();
            s.f1 = this;
            //s.ClientTcp("64.72.2.57", 3399);
            s.ClientTcp(ad.addr, ad.serverport);
            msg.ID = TB.Text;
            
            string b = JsonSerializer.Serialize(msg);
            //string c = TB.Text + '/0';
            s.Send(TB.Text);
        }

        private void requestUser(object sender, EventArgs e)
        {
            s.Send(UserBox.SelectedItem.ToString());
            Adduser(UserBox.SelectedItem.ToString());
        }
        
        //send the server a yes so that the clients and connect
        private void YesButton(object sender, EventArgs e)
        {
            s.Send('Y'.ToString());
        }

        //sends the contents of the text box to the server for the user name
        private void bp(object sender, EventArgs e)
        {
            msg.ID = TB.Text;
            msg.buf = messbox.Text;
            //msg.partnerID
            //var i = new JsonSerializer();
           
            string b = JsonSerializer.Serialize(msg.ID);
            s.Send(TB.Text);
        }

        private void usersub(object sender, EventArgs e)
        {
            string b = JsonSerializer.Serialize(TB.Text);
            s.Send(b);
        }
    }
}
