using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ClientTable : Table
{
    public int id { get; set; }
    public string name { get; set; }
    public int? company_id { get; set; }
    public string email { get; set; }
}