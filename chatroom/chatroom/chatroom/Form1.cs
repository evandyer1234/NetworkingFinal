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
        public Form2 form2;

        public Form1()
        {
            InitializeComponent();
            portui.Value = 8080;
        }

        private void enterchat(object sender, EventArgs e)
        {
            if (TB.Text != "")
            {
                Form2 f2 = new Form2();
                f2.un = TB.Text;
                f2.user = us;
                f2.con = con;
                f2.form1 = this;
                form2 = f2;
                f2.Show();
            }
        }
        public void CloseForm()
        {
            form2.Close();
        }
        public void buttonreset(int i)
        {
            radioButton5.Enabled = true;
            radioButton8.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;

            if (i == 1)
            {
                radioButton5.Enabled = false;
            }
            else if (i == 2)
            {
                radioButton6.Enabled = false;
            }
            else if (i == 3)
            {
                radioButton7.Enabled = false;
            }
            else if (i == 4)
            {
                radioButton8.Enabled = false;
            }
        }

        private void rbcheck1(object sender, EventArgs e)
        {
            us = 1;
            buttonreset(1);
            
        }

        private void rbcheck2(object sender, EventArgs e)
        {
            us = 2;
            buttonreset(2);
        }

        private void rbcheck3(object sender, EventArgs e)
        {
            us = 3;
            buttonreset(3);
        }

        private void rbcheck4(object sender, EventArgs e)
        {
            us = 4;
            buttonreset(4);
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
