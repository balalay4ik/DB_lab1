using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class CompanyTable : Table
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Fill(NpgsqlDataReader reader)
    {
        this.Id = (int)reader["id"];
        this.Name = reader["company_name"].ToString();
    }

    public void Fill(DataGridViewRow param)
    {
        this.Id = (int)param.Cells["id"].Value;
        this.Name = param.Cells["name"].Value.ToString();
    }

    public string GetParam() { return "company_name"; }
    public string GetAttr() { return "md5(random()::text) as company_name"; }
    public string AdditionalAttr() { return ""; }
    public int GetId() { return this.Id; }
}