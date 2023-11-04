using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_lab1
{
    public partial class SportObjectForm : TableForm
    {
        public SportObjectForm()
        {
            InitializeComponent();
        }

        private void SportObjectForm_Load(object sender, EventArgs e)
        {
            if (table != null)
                InitTable();
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

            try
            {
                db.Insert<SportObjectTable>(attr, attrName);
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

            try
            {
                db.Edit<SportObjectTable>(table.GetId(), attr);
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitTable()
        {
            SportObjectTable sport = table as SportObjectTable;
            textBox1.Text = sport.Name;
        }

        public override void SearchMode(DataBase DB)
        {
            db = DB;
            this.Controls.Remove(button1);
            textBox1.KeyUp += Filter;
        }

        private void Filter(object sender, KeyEventArgs e)
        {
            string attr = "";

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                conditions.Add($"{label1.Text} LIKE '%{textBox1.Text}%'");
            }

            if (conditions.Count > 0)
            {
                attr = string.Join(" AND ", conditions);
            }

            db.Search<SportObjectTable>(attr);
        }
    }
}
