using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ReservationTable : Table
{
    public int Id { get; set; }
    public int Client_id { get; set; }
    public int Object_id { get; set; }
    public DateTime Booking_start_date { get; set; }
    public DateTime Booking_end_date { get; set; }
    public decimal Price { get; set; }

    public void Fill(NpgsqlDataReader reader)
    {
        this.Id = (int)reader["id"];
        this.Client_id = (int)reader["client_id"];
        this.Object_id = (int)reader["object_id"];
        this.Booking_start_date = (DateTime)reader["booking_start_date"];
        this.Booking_end_date = (DateTime)reader["booking_end_date"];
        this.Price = (decimal)reader["price"];
    }

    public void Fill(DataGridViewRow param)
    {
        this.Id = (int)param.Cells["id"].Value;
        this.Client_id = (int)param.Cells["client_id"].Value;
        this.Object_id = (int)param.Cells["object_id"].Value;
        this.Booking_start_date = (DateTime)param.Cells["booking_start_date"].Value;
        this.Booking_end_date = (DateTime)param.Cells["booking_end_date"].Value;
        this.Price = (decimal)param.Cells["price"].Value;
    }

    public string GetParam() { return "client_id, object_id, booking_start_date, booking_end_date, price"; }
    public string GetAttr() { return "(SELECT FLOOR(random() * c) + 1) AS client_id, (SELECT FLOOR(random() * c1) + 1) AS object_id, (CURRENT_DATE - (FLOOR(random() * 365) || ' days')::INTERVAL) AS booking_start_date, (CURRENT_DATE - (FLOOR(random() * 365) || ' days')::INTERVAL) + (FLOOR(random() * 365) || ' days')::INTERVAL AS booking_end_date, (random()*1000)::int as price"; }
    public string AdditionalAttr() { return ", (select coalesce(max(id), 1) as c from \"Client\") as rid, (select coalesce(max(id), 1) as c1 from \"Sport_object\") as rid1"; }
    public int GetId() { return this.Id; }
}
