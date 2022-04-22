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
    public partial class Form1 : Form
    {        
        public int us;
        public int con;

        public Form1()
        {
            InitializeComponent();
        }

        private void enterchat(object sender, EventArgs e)
        {
            if (TB.Text != "")
            {
                Form2 f2 = new Form2();
                f2.un = TB.Text;
                f2.user = us;
                f2.con = con;
                f2.Show();
            }
        }

        private void rbcheck1(object sender, EventArgs e)
        {
            us = 1;
        }

        private void rbcheck2(object sender, EventArgs e)
        {
            us = 2;
        }

        private void rbcheck3(object sender, EventArgs e)
        {
            us = 3;
        }

        private void rbcheck4(object sender, EventArgs e)
        {
            us = 4;
        }

        private void cn1(object sender, EventArgs e)
        {
            con = 1;
        }

        private void cn2(object sender, EventArgs e)
        {
            con = 2;
        }

        private void cn3(object sender, EventArgs e)
        {
            con = 3;
        }

        private void cn4(object sender, EventArgs e)
        {
            con = 4;
        }

       
    }
}
