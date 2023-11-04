using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

public class DataBase
{
    NpgsqlConnection Connection;
    DataGridView grid;

    public DataBase(DataGridView _grid)
    {
        grid = _grid;
    }

    private string GetTableName<T>()
    {
        string tableName = null;
        if (typeof(T) == typeof(ClientTable)) tableName = "Client";
        else if (typeof(T) == typeof(CompanyTable)) tableName = "Company";
        else if (typeof(T) == typeof(ReservationTable)) tableName = "Reservation";
        else if (typeof(T) == typeof(SportObjectTable)) tableName = "Sport_object";

        return $"\"{tableName}\"";
    }

    public void Connect()
    {
        Connection = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=admin;Port=5432;Database=postgres;");
        Connection.Open();
    }

    public void LoadRecords<T>() where T : Table, new()
    {
        grid.DataSource = Records<T>();
    }

    private BindingList<T> Records<T>() where T : Table, new() 
    {
        string tableName = GetTableName<T>();


        string query = $"SELECT * FROM {tableName} ORDER BY id ASC";

        NpgsqlCommand nCommand = new NpgsqlCommand(query, Connection);

        NpgsqlDataReader reader = nCommand.ExecuteReader();

        BindingList<T> RecordsBindingList = new BindingList<T>();

        while (reader.Read())
        {
            T table = new T();
            table.Fill(reader);

            RecordsBindingList.Add(table);
        }
        reader.Close();

        return RecordsBindingList;

    }

    public void Insert<T>(string attr, string attrName) where T : Table, new()
    {
        string tableName = GetTableName<T>();

        BindingList<T> RecordsBindingList = Records<T>();

        int id = RecordsBindingList.Last().GetId() + 1;

        string query = $"INSERT INTO {tableName}(id{attrName}) VALUES({id}{attr})";
        NpgsqlCommand nCommand = new NpgsqlCommand(query, Connection);

        nCommand.ExecuteNonQuery();
        LoadRecords<T>();
    }

    public void InsertRandom<T>(int count) where T : Table, new()
    {
        string tableName = GetTableName<T>();

        T table = new T();

        string query = $"INSERT INTO {tableName}(id,{table.GetParam()}) SELECT generate_series(id_start, id_end) as id, {table.GetAttr()} FROM (SELECT COALESCE(max(id) + 1, 1) as id_start, COALESCE(max(id), 0) + {count} as id_end FROM {tableName}) as id_range {table.AdditionalAttr()}";
        NpgsqlCommand nCommand = new NpgsqlCommand(query, Connection);

        nCommand.ExecuteNonQuery();
        LoadRecords<T>();
    }

    public void Edit<T>(int id, string attr) where T : Table, new()
    {
        string tableName = GetTableName<T>();

        string query = $"UPDATE {tableName} SET {attr} WHERE \"id\" = {id};";

        NpgsqlCommand nCommand = new NpgsqlCommand(query, Connection);

        nCommand.ExecuteNonQuery();
        LoadRecords<T>();
    }

    public void Delete<T>(int id) where T : Table, new()
    {
        string tableName = GetTableName<T>();

        string query = $"DELETE FROM {tableName} WHERE id = {id}";

        NpgsqlCommand nCommand = new NpgsqlCommand(query, Connection);

        nCommand.ExecuteNonQuery();
        LoadRecords<T>();
    }

    public void Command(string query)
    {
        var dataAdapter = new NpgsqlDataAdapter(query, Connection);

        var dataSet = new DataSet();

        dataAdapter.Fill(dataSet);

        grid.DataSource = dataSet.Tables[0];
    }

    public void Search<T>(string attr) where T : Table, new()
    {
        string tableName = GetTableName<T>();

        string query;

        if (attr != "") query = $"select * from {tableName} where {attr} ORDER BY id ASC";
        else query = $"select * from {tableName} ORDER BY id ASC";

        Command(query);
    }
}
