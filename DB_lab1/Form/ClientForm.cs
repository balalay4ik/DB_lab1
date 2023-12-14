using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_lab1
{
    public partial class ClientForm : TableForm
    {

        public ClientForm()
        {
            InitializeComponent();
            errormsg.ForeColor = Color.Red;
            textBox2.KeyPress += TextBox2_KeyPress;


        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void InitTable()
        {
            ClientTable client = table as ClientTable;
            textBox1.Text = client.name;
            textBox2.Text = client.company_id.ToString();
            textBox3.Text = client.email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (table == null) AddRow();
            else EditRow();
        }

        private void AddRow()
        {
            if (textBox1.Text == "")
            {
                errormsg.Text = "name не повино бути null";
                return;
            }

            ClientTable client = new ClientTable()
            {
                name = textBox1.Text,
                company_id = String.IsNullOrEmpty(textBox2.Text) ? null : Convert.ToInt32(textBox2.Text),
                email = textBox3.Text
            };


            try
            {
                db.Insert(client);
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            this.Close();
        }

        private void EditRow()
        {
            ClientTable client = new ClientTable()
            {
                id = (table as ClientTable).id,
                name = textBox1.Text,
                company_id = String.IsNullOrEmpty(textBox2.Text) ? null : Convert.ToInt32(textBox2.Text),
                email = textBox3.Text
            };

            try
            {
                db.Edit<ClientTable>(client.id, client);
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            this.Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (table != null)
                InitTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void SearchMode(DataBaseContext DB)
        {
            db = DB;
            this.Controls.Remove(button1);
            textBox1.KeyUp += Filter;
            textBox2.KeyUp += Filter;
            textBox3.KeyUp += Filter;
        }

        private void Filter(object sender, KeyEventArgs e)
        {
            int? companyId = String.IsNullOrEmpty(textBox2.Text) ? -1 : Convert.ToInt32(textBox2.Text);

            db.Search<ClientTable>(
                x =>
                    (string.IsNullOrEmpty(textBox1.Text) || x.name.Contains(textBox1.Text)) &&
                    (companyId == -1 || x.company_id == companyId || x.company_id == null) &&
                    (string.IsNullOrEmpty(textBox3.Text) || x.email.Contains(textBox3.Text))
            );
        }
    }
}
