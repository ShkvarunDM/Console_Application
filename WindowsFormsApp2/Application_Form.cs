using Npgsql;
using NpgsqlTypes;
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
    public partial class Application_Form : Form
    {
        public Application_Form()
        {
            InitializeComponent();
        }

        private void appl_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            NameBox.Text = "";
            numberBox.Text = "";
            emailBox.Text = "";
            adressBox.Text = "";
            problemBox.Text = "";
            priorityBox.Text = "";
            idWBox.Text = "";
            id_applBox.Text = "";
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
            Program.fc.Show(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand add2 = new NpgsqlCommand("INSERT INTO application (id_appl,problems, date_created,priority, id_worker,status) values (@id_a, @problems, @datec,@priority,@idw,@sts);");
            
            NpgsqlCommand add2 = new NpgsqlCommand("add_appl");
            add2.CommandType = CommandType.StoredProcedure;

            add2.Parameters.Add("id_ap", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_applBox.Text);
            add2.Parameters.Add("prob", NpgsqlDbType.Char).Value = problemBox.Text;
            add2.Parameters.Add("date_cr", NpgsqlDbType.Date).Value = DateTime.Now.Date;
            add2.Parameters.Add("pr", NpgsqlDbType.Char).Value = priorityBox.Text;
            add2.Parameters.Add("id_w", NpgsqlDbType.Integer).Value = Convert.ToInt32(idWBox.Text);
            add2.Parameters.Add("sts", NpgsqlDbType.Char).Value = "В обработке";

            Program.DB.ExecuteNonQuery(add2);

            // NpgsqlCommand add1 = new NpgsqlCommand("INSERT INTO clients (cName, cphone, email, adress, id_appl) values (@name,@phone,@email,@adress,@id_appl);");
            NpgsqlCommand add1 = new NpgsqlCommand("add_clients");
            add1.CommandType = CommandType.StoredProcedure;

            add1.Parameters.Add("cn", NpgsqlDbType.Char).Value = NameBox.Text;
            add1.Parameters.Add("cph", NpgsqlDbType.Char).Value = numberBox.Text;
            add1.Parameters.Add("em", NpgsqlDbType.Char).Value = emailBox.Text;
            add1.Parameters.Add("adr", NpgsqlDbType.Char).Value = adressBox.Text;
            add1.Parameters.Add("id_a", NpgsqlDbType.Integer).Value = Convert.ToInt32(id_applBox.Text);

            Program.DB.ExecuteNonQuery(add1);
            Clear();
        }
    }
}
