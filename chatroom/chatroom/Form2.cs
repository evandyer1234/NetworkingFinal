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
    public partial class Form2 : Form
    {
        public int user;
        public string un;
        public int con;

        public Form2()
        {
            InitializeComponent();
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
                string p = un + ": " + tb.Text;
                LB.Items.Add(p);
            }
        }

        private void Leavebtn(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }
    }
}
