using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            textBox1.Text = client.Name;
            textBox2.Text = client.Company_id.ToString();
            textBox3.Text = client.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (table == null) AddRow();
            else EditRow();
        }

        private void AddRow()
        {
            string attrName = "";
            string attr = "";
            if (textBox1.Text != "")
            {
                attr += $", '{textBox1.Text}'";
                attrName += $", {label1.Text}";
            }
            else
            {
                errormsg.Text = "name не повино бути null";
                return;
            }

            if (textBox2.Text != "")
            {
                attr += $", {textBox2.Text}";
                attrName += $", {label2.Text}";
            }
            if (textBox3.Text != "")
            {
                attr += $", '{textBox3.Text}'";
                attrName += $", {label3.Text}";
            }

            try
            {
                db.Insert<ClientTable>(attr, attrName);
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
            string attr = "";

            if (textBox1.Text != "")
            {
                attr += $"\"{label1.Text}\" = \'{textBox1.Text}\'";
            }
            else
            {
                errormsg.Text = "name не повино бути null";
                return;
            }

            if (textBox2.Text != "")
            {
                attr += $", {label2.Text} = {textBox2.Text}";
            }
            else
                attr += $", {label2.Text} = NULL";


            attr += $", {label3.Text} = \'{textBox3.Text}\'";


            try
            {
                db.Edit<ClientTable>(table.GetId(), attr);
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

        public override void SearchMode(DataBase DB)
        {
            db = DB;
            this.Controls.Remove(button1);
            textBox1.KeyUp += Filter;
            textBox2.KeyUp += Filter;
            textBox3.KeyUp += Filter;
        }

        private void Filter(object sender, KeyEventArgs e)
        {
            string attr = "";

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                conditions.Add($"{label1.Text} LIKE '%{textBox1.Text}%'");
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                conditions.Add($"{label2.Text} = '{textBox2.Text}'");
            }

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                conditions.Add($"{label3.Text} LIKE '%{textBox3.Text}%'");
            }

            if (conditions.Count > 0)
            {
                attr = string.Join(" AND ", conditions);
            }

            db.Search<ClientTable>(attr);
        }
    }
}
