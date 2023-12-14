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
    public partial class ReservationForm : TableForm
    {
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void InitTable()
        {
            ReservationTable reservation = table as ReservationTable;
            textBox1.Text = reservation.client_id.ToString();
            textBox2.Text = reservation.object_id.ToString();
            dateTimePicker1.Value = reservation.booking_start_date;
            dateTimePicker2.Value = reservation.booking_end_date;
            textBox3.Text = reservation.price.ToString();
        }

        private string errorMsg = " не повино бути null";

        private void AddRow()
        {
            if (textBox1.Text == "")
            {
                errormsg.Text = label1.Text + errorMsg;
                return;
            }

            if (textBox2.Text == "")
            {
                errormsg.Text = label2.Text + errorMsg;
                return;
            }

            if (textBox3.Text == "")
            {
                errormsg.Text = label3.Text + errorMsg;
                return;
            }

            ReservationTable reservation = new ReservationTable()
            {
                client_id = Convert.ToInt32(textBox1.Text),
                object_id = Convert.ToInt32(textBox2.Text),
                price = Convert.ToInt32(textBox3.Text),
            };

            try
            {
                db.Insert(reservation);
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
                errormsg.Text = label1.Text + errorMsg;
                return;
            }

            if (textBox2.Text == "")
            {
                errormsg.Text = label2.Text + errorMsg;
                return;
            }

            if (textBox3.Text == "")
            {
                errormsg.Text = label3.Text + errorMsg;
                return;
            }

            ReservationTable reservation = new ReservationTable()
            {
                id = (table as ReservationTable).id,
                client_id = Convert.ToInt32(textBox1.Text),
                object_id = Convert.ToInt32(textBox2.Text),
                price = Convert.ToInt32(textBox3.Text),
            };

            try
            {
                db.Edit<ReservationTable>(reservation.id, reservation);
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

        public override void SearchMode(DataBaseContext DB)
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
            int? clientId = String.IsNullOrEmpty(textBox1.Text) ? -1 : Convert.ToInt32(textBox1.Text);
            int? objectId = String.IsNullOrEmpty(textBox2.Text) ? -1 : Convert.ToInt32(textBox2.Text);
            int? _price = String.IsNullOrEmpty(textBox3.Text) ? -1 : Convert.ToInt32(textBox3.Text);

            DateTime bookingStartDate = dateTimePicker1.Value;
            DateTime bookingEndDate = dateTimePicker2.Value;
            db.Search<ReservationTable>(
            x =>
            (clientId == -1 || x.client_id == clientId || x.client_id == null) &&
                        (objectId == -1 || x.object_id == objectId || x.object_id == null) &&
                        (x.booking_start_date >= bookingStartDate) &&
                        (x.booking_end_date <= bookingEndDate) &&
                        (_price == -1 || x.price == _price || x.price == null)
                );
        }
    }
}
