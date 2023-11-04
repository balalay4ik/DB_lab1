using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public interface Table
{
    void Fill(NpgsqlDataReader reader);
    void Fill(DataGridViewRow param);
    string GetParam();
    string GetAttr();
    string AdditionalAttr();
    int GetId();
}
