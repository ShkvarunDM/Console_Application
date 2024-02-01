using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console_Application
{
    public partial class Compl_Work_Form : Form
    {
        public Compl_Work_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NpgsqlCommand add1 = new NpgsqlCommand("add_compl_work");
            add1.CommandType = CommandType.StoredProcedure;

            //NpgsqlCommand add1 = new NpgsqlCommand("INSERT INTO compl_work (id_appl,list_task,date_compl) values (@id_a, @lt,@dc);");

            add1.Parameters.Add("id_a", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_applBox1.Text);
            add1.Parameters.Add("lt", NpgsqlDbType.Char).Value = listBox.Text;
            add1.Parameters.Add("dc", NpgsqlDbType.Date).Value = DateTime.Now.Date;

            Program.DB.ExecuteNonQuery(add1);

            NpgsqlCommand compl = new NpgsqlCommand("update_status");
            compl.CommandType = CommandType.StoredProcedure;
            compl.Parameters.Add("@id_app", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_applBox1.Text);

            Program.DB.ExecuteNonQuery(compl);

            Clear();
        }
        public void Clear()
        {
            listBox.Text = "";
            id_applBox1.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
            Program.fc.Show(1);
        }

        private void coml_work_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
