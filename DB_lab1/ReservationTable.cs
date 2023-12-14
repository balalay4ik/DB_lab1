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
    public int id { get; set; }
    public int client_id { get; set; }
    public int object_id { get; set; }
    public DateTime booking_start_date { get; set; }
    public DateTime booking_end_date { get; set; }
    public decimal price { get; set; }
}
