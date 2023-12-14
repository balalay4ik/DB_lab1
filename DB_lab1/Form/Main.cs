using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DB_lab1
{
    public partial class Main : Form
    {
        private DataBaseContext db;
        private string selectedTable = null;

        private TableForm tableForm;

        public Main()
        {
            InitializeComponent();
            //db = new DataBase1(dataGridView1);
            db = new DataBaseContext(dataGridView1);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            //db.Connect();

            comboBox1.Items.Add("Client");
            comboBox1.Items.Add("Company");
            comboBox1.Items.Add("Reservation");
            comboBox1.Items.Add("Sport_object");
            comboBox1.SelectedIndex = 0;
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            if (tableForm != null) tableForm.Close();

            if (selectedTable == "Client") tableForm = new ClientForm();
            else if (selectedTable == "Company") tableForm = new CompanyForm();
            else if (selectedTable == "Reservation") tableForm = new ReservationForm();
            else if (selectedTable == "Sport_object") tableForm = new SportObjectForm();

            tableForm.InitDB(db, false);
            tableForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.LoadRecords<ClientTable>();


            this.Name = "Main";
            this.Text = "Main";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTable = comboBox1.SelectedItem.ToString();

            if (selectedTable == "Client") db.LoadRecords<ClientTable>();
            else if (selectedTable == "Company") db.LoadRecords<CompanyTable>();
            else if (selectedTable == "Reservation") db.LoadRecords<ReservationTable>();
            else if (selectedTable == "Sport_object") db.LoadRecords<SportObjectTable>();

            if (tableForm != null) tableForm.Close();
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (tableForm != null) tableForm.Close();
            Table table = null;
            int Id = (int)dataGridView1.CurrentRow.Cells["id"].Value;

            if (selectedTable == "Client")
            {
                tableForm = new ClientForm();
                table = new ClientTable();
                table = db.GetRowParams<ClientTable>(Id);
            }
            else if (selectedTable == "Company")
            {
                tableForm = new CompanyForm();
                table = new CompanyTable();
                table = db.GetRowParams<CompanyTable>(Id);
            }
            else if (selectedTable == "Reservation")
            {
                tableForm = new ReservationForm();
                table = new ReservationTable();
                table = db.GetRowParams<ReservationTable>(Id);
            }
            else if (selectedTable == "Sport_object")
            {
                tableForm = new SportObjectForm();
                table = new SportObjectTable();
                table = db.GetRowParams<SportObjectTable>(Id);
            }

            tableForm.InitDB(db, true);

            tableForm.InitTable(table);
            tableForm.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            int Id = (int)dataGridView1.CurrentRow.Cells["id"].Value;

            try
            {
                if (selectedTable == "Client") db.Delete<ClientTable>(Id);
                else if (selectedTable == "Company") db.Delete<CompanyTable>(Id);
                else if (selectedTable == "Reservation") db.Delete<ReservationTable>(Id);
                else if (selectedTable == "Sport_object") db.Delete<SportObjectTable>(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Query_Click(object sender, EventArgs e)
        {
            TableForm query = new Query();
            //query.InitDB(db, true);
            query.Show();
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            int count = (int)numericUpDown1.Value;

            //if (selectedTable == "Client") db.InsertRandom<ClientTable>(count);
            //else if (selectedTable == "Company") db.InsertRandom<CompanyTable>(count);
            //else if (selectedTable == "Reservation") db.InsertRandom<ReservationTable>(count);
            //else if (selectedTable == "Sport_object") db.InsertRandom<SportObjectTable>(count);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (tableForm != null) tableForm.Close();

            if (selectedTable == "Client")
            {
                tableForm = new ClientForm();
            }
            else if (selectedTable == "Company")
            {
                tableForm = new CompanyForm();
            }
            else if (selectedTable == "Reservation")
            {
                tableForm = new ReservationForm();
            }
            else if (selectedTable == "Sport_object")
            {
                tableForm = new SportObjectForm();
            }

            tableForm.SearchMode(db);
            tableForm.Show();
        }

        private void Statistic_Click(object sender, EventArgs e)
        {
            db.GetReportResult();
        }
    }
}
