using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SportObjectTable : Table
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Fill(NpgsqlDataReader reader)
    {
        this.Id = (int)reader["id"];
        this.Name = reader["name"].ToString();
    }

    public void Fill(DataGridViewRow param)
    {
        this.Id = (int)param.Cells["id"].Value;
        this.Name = param.Cells["name"].Value.ToString();
    }

    public string GetParam() { return "name"; }
    public string GetAttr() { return "md5(random()::text) as name"; }
    public string AdditionalAttr() { return ""; }

    public int GetId() { return this.Id; }

}

