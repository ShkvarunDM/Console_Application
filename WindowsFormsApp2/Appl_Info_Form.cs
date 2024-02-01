using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Console_Application.Program;

namespace Console_Application
{
    public partial class Appl_Info_Form : Form
    {
        private int _lastId;
        private List<string> data;

        public Appl_Info_Form()
        {
            InitializeComponent();
        }

        private void appl_info_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
            Program.fc.Show(1);
        }

        private void AddButton(string text)
        {
            AssociateButton btn = new AssociateButton();
            btn.Recid = _lastId++;
            btn.BackColor = Color.White;
            btn.Text = text;
            btn.Click += btnClick;
            btn.Height = 30;
            btn.Width = 100;
            btn.Dock = DockStyle.Top;
            btn.FlatAppearance.BorderSize = 4;
            groupBox1.Controls.Add(btn);

        }

        private void btnClick(object sender, EventArgs e)
        {
            
            foreach(object btn in groupBox1.Controls)
            {
                ((AssociateButton)btn).Enabled= true;
            }
            PutData(((AssociateButton)sender).Recid);
        }

         private void PutData(int id)
          {
              textBox1.Text = data[id];
          }

        public void UpdateData()
        {  
            data = new List<string>();
            _lastId = 0;

            groupBox1.Controls.Clear();
            
            NpgsqlCommand appl = new NpgsqlCommand("SELECT * FROM application;");
            var reader = Program.DB.ExecuteReader(appl);

            while (reader.Read())
            {
                string id3 = reader[0].ToString();  
                string text = $" Номер заявки: {reader[0]}\r\n " +
                    $"Описание проблемы: {reader[1]}\r\n " +
                    $"Дата создания заявки: " +
                    $"{reader[2]}\r\n " +
                    $"Статус: {reader[3]}\r\n " +
                    $"Приоритет: {reader[4]}\r\n " +
                    $"Номер работника: {reader[5]}\r\n ";

                data.Add(text);
                AddButton(id3);
            }
            reader.Close();
        }
    }
}
