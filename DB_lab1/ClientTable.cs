using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ClientTable : Table
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Company_id { get; set; }
    public string Email { get; set; }

    public void Fill(NpgsqlDataReader reader)
    {
        this.Id = (int)reader["id"];
        this.Name = reader["name"].ToString();
        this.Company_id = reader["company_id"] == DBNull.Value ? null : (int?)reader["company_id"];
        this.Email = reader["email"].ToString();
    }

    public void Fill(DataGridViewRow param)
    {
        this.Id = (int)param.Cells["id"].Value;
        this.Name = param.Cells["name"].Value.ToString();
        this.Company_id = (int?)param.Cells["company_id"].Value;
        this.Email = param.Cells["email"].Value.ToString();
    }

    public string GetParam() { return "name, company_id, email"; }
    public string GetAttr() { return "md5(random()::text) as name, case when c is not null then(select floor(random()*c) + 1) else null end as company_id, 'client'|| generate_series(id_start, id_end) || '@example.com' AS email"; }
    public string AdditionalAttr() { return ", (select coalesce(max(id), 1) as c from \"Company\") as rid"; }

    public int GetId() { return this.Id; }
}