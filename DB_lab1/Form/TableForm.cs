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
    public partial class TableForm : Form
    {
        protected DataBaseContext db;
        protected bool isNew;
        protected Table table;
        public TableForm()
        {
            InitializeComponent();
        }

        public void InitDB(DataBaseContext DB, bool _isNew)
        {
            db = DB;
            isNew = _isNew;
        }

        public void InitTable(Table _table = null) 
        {
            table = _table;
        }

        public virtual void SearchMode(DataBaseContext DB) {}

        private void TableForm_Load(object sender, EventArgs e)
        {

        }
    }
}
