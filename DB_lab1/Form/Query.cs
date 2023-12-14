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
    public partial class Query : TableForm
    {
        public Query()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //db.Command(richTextBox1.Text);
                label1.Text = "";
            }
            catch (Exception er)
            {
                label1.Text = er.Message;
            }
        }

        private void Query_Load(object sender, EventArgs e)
        {

        }
    }
}
