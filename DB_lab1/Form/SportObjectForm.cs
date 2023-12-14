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
            if (textBox1.Text == "")
            {
                errormsg.Text = "name не повино бути null";
                return;
            }

            SportObjectTable sport = new SportObjectTable()
            {
                name = textBox1.Text
            };

            try
            {
                db.Insert<SportObjectTable>(sport);
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
            if (textBox1.Text == "")
            {
                errormsg.Text = "name не повино бути null";
                return;
            }

            SportObjectTable sport = new SportObjectTable()
            {
                id = (table as SportObjectTable).id,
                name = textBox1.Text
            };

            try
            {
                db.Edit<SportObjectTable>(sport.id, sport);
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
            textBox1.Text = sport.name;
        }

        public override void SearchMode(DataBaseContext DB)
        {
            db = DB;
            this.Controls.Remove(button1);
            textBox1.KeyUp += Filter;
        }

        private void Filter(object sender, KeyEventArgs e)
        {
            db.Search<SportObjectTable>(
                x => string.IsNullOrEmpty(textBox1.Text) || x.name.Contains(textBox1.Text)
            );
        }
    }
}
