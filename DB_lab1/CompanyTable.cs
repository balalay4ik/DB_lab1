using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class CompanyTable : Table
{
    public int id { get; set; }
    public string company_name { get; set; }
}