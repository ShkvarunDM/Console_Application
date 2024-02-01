using System;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace  Console_Application

{
    public partial class Log_Form : Form
    {
        public Log_Form()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
        }

        private void loginbutton1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand login = new NpgsqlCommand("SELECT * FROM login WHERE log = @a AND password = @b");
            login.Parameters.Add("@a", NpgsqlDbType.Char).Value = textBox1.Text;
            login.Parameters.Add("@b", NpgsqlDbType.Char).Value = textBox2.Text;
            NpgsqlDataReader reader = Program.DB.ExecuteReader(login);
  
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessageBox.Show(" Добро пожаловать! ");
                    int lev = Convert.ToInt32(reader[2]);
                    Program.fc.Show(1);
                    ((Base_Form)Program.fc.forms[1]).Data_Access(lev);                   
                }
            }
            else
            {
                MessageBox.Show("неверно введен пароль");
            }
            reader.Close();
        }
    }
}
