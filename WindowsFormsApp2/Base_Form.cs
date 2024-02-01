using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Console_Application
{
    public partial class Base_Form : Form
    {
        public Base_Form()
        {
            InitializeComponent();
        }

        private void Base_Form_Load(object sender, EventArgs e)
        {

        }

        public void Data_Access(int level)
        {
            Console.WriteLine(level);
            button1.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;

            if (level == 1)
            {
                button1.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.fc.Show(2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.fc.Show(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.fc.Show(4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Tech_Form)Program.fc.forms[6]).UpdateData();
            Program.fc.Show(6);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.fc.Show(5);
        }
    }
}
