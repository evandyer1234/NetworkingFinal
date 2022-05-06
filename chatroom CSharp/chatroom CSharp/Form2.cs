using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatroom_CSharp
{
    public partial class Form2 : Form
    {
        public Form1 f1;

        public Form2()
        {
            InitializeComponent();
        }

        unsafe private void EnterPressed(object sender, EventArgs e)
        {
            /*
            fixed (char* p = &f1.data.ID)

            {
               *p = IDBox.Text.ToCharArray(0, 128);
            }
            */
            f1.id = IDBox.Text;
            f1.waiting = false;

        }
    }
}
