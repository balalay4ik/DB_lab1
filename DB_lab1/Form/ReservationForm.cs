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
    public partial class ReservationForm : TableForm
    {
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void InitTable()
        {
            ReservationTable reservation = table as ReservationTable;
            textBox1.Text = reservation.Client_id.ToString();
            textBox2.Text = reservation.Object_id.ToString();
            dateTimePicker1.Value = reservation.Booking_start_date;
            dateTimePicker2.Value = reservation.Booking_end_date;
            textBox3.Text = reservation.Price.ToString();
        }

        private string errorMsg = " не повино бути null";

        private void AddRow()
        {
            

            string attrName = "";
            string attr = "";
            if (textBox1.Text != "")
            {
                attr += $", {textBox1.Text}";
                attrName += $", {label1.Text}";
            }
            else
            {
                errormsg.Text = label1.Text + errorMsg;
                return;
            }

            if (textBox2.Text != "")
            {
                attr += $", {textBox2.Text}";
                attrName += $", {label2.Text}";
            }
            else
            {
                errormsg.Text = label2.Text + errorMsg;
                return;
            }

            if (textBox3.Text != "")
            {
                attr += $", {textBox3.Text}";
                attrName += $", {label3.Text}";
            }
            else
            {
                errormsg.Text = label3.Text + errorMsg;
                return;
            }


            try
            {
                Convert.ToDateTime(dateTimePicker1.Value);
                attr += $", '{dateTimePicker1.Value}'";
                attrName += $", {label4.Text}";
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            try
            {
                Convert.ToDateTime(dateTimePicker2.Value);
                attr += $", '{dateTimePicker2.Value}'";
                attrName += $", {label5.Text}";
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            try
            {
                db.Insert<ReservationTable>(attr, attrName);
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
                attr += $"\"{label1.Text}\" = {textBox1.Text}";
            }
            else
            {
                errormsg.Text = label1.Text + errorMsg;
                return;
            }

            if (textBox2.Text != "")
            {
                attr += $", \"{label2.Text}\" = {textBox2.Text}";
            }
            else
            {
                errormsg.Text = label2.Text + errorMsg;
                return;
            }

            if (textBox3.Text != "")
            {
                attr += $", \"{label3.Text}\" = {textBox3.Text}";
            }
            else
            {
                errormsg.Text = label3.Text + errorMsg;
                return;
            }


            try
            {
                Convert.ToDateTime(dateTimePicker1.Value);
                attr += $", \"{label4.Text}\" = '{dateTimePicker1.Value}'";
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            try
            {
                Convert.ToDateTime(dateTimePicker2.Value);
                attr += $", \"{label5.Text}\" = '{dateTimePicker2.Value}'";
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }


            try
            {
                db.Edit<ReservationTable>(table.GetId(), attr);
            }
            catch (Exception er)
            {
                errormsg.Text = er.Message.ToString();
                return;
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (table == null) AddRow();
            else EditRow();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            if (table != null)
                InitTable();

        }

        public override void SearchMode(DataBase DB)
        {
            db = DB;
            this.Controls.Remove(button1);
            textBox1.KeyUp += Filter;
            textBox2.KeyUp += Filter;
            textBox3.KeyUp += Filter;
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker_ValueChanged;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Filt();
        }

        private void Filter(object sender, KeyEventArgs e)
        {
            Filt();
        }

        private void Filt()
        {
            string attr = "";

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                conditions.Add($"{label1.Text} = '{textBox1.Text}'");
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                conditions.Add($"{label2.Text} = '{textBox2.Text}'");
            }

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                conditions.Add($"{label3.Text} = {textBox3.Text}");
            }

            if (!string.IsNullOrEmpty(dateTimePicker1.Value.ToString()))
            {
                conditions.Add($"{label4.Text} >= '{dateTimePicker1.Value}'");
            }

            if (!string.IsNullOrEmpty(dateTimePicker2.Value.ToString()))
            {
                conditions.Add($"{label5.Text} <= '{dateTimePicker2.Value}'");
            }

            if (conditions.Count > 0)
            {
                attr = string.Join(" AND ", conditions);
            }

            db.Search<ReservationTable>(attr);
        }
    }
}
