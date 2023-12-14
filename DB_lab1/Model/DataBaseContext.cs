using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class DataBaseContext : DbContext
{
    private const string ConnectionString = "Server=localhost;Port=5432;User ID=postgres;Database=postgres;Password=admin;";
    DataGridView grid;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DataBaseContext(DataGridView _grid) { grid = _grid; }

    public DbSet<ClientTable> Client { get; set; }
    public DbSet<CompanyTable> Company { get; set; }
    public DbSet<ReservationTable> Reservation { get; set; }
    public DbSet<SportObjectTable> Sport_object { get; set; }

    public void LoadRecords<T>() where T : class, Table
    {
        DbSet<T> table = Set<T>();
        grid.DataSource = table.ToList();
    }

    public void Insert<T>(T record) where T : class, Table
    {
        DbSet<T> table = Set<T>();
        table.Add(record);
        SaveChanges();
        LoadRecords<T>();
    }

    public void Delete<T>(int id) where T : class, Table
    {
        DbSet<T> table = Set<T>();
        T entity = table.Find(id);

        if (entity != null)
        {
            table.Remove(entity);
            SaveChanges();
            LoadRecords<T>();
        }
    }

    public T GetRowParams<T>(int id) where T : class, Table
    {
        DbSet<T> table = Set<T>();
        return table.Find(id);
    }

    public void Edit<T>(int id, T record) where T : class, Table
    {
        DbSet<T> table = Set<T>();
        T existingEntity = table.Find(id);

        if (existingEntity != null)
        {
            Entry(existingEntity).CurrentValues.SetValues(record);
            SaveChanges();
            LoadRecords<T>();
        }
    }

    public void Search<T>(Func<T, bool> predicate) where T : class, Table
    {
        DbSet<T> table = Set<T>();
        grid.DataSource = table.Where(predicate).ToList();
    }

    public void GetReportResult()
    {
        var results = from c in Set<ClientTable>()
                    join r in Set<ReservationTable>() on c.id equals r.client_id
                    join s in Set<SportObjectTable>() on r.object_id equals s.id
                    group new { c, r, s } by new NewClass(c.name, s.name, c.email) into grouped
                    select new
                    {
                        PersonName = grouped.Key.Name,
                        ObjectName = grouped.Key.Name,
                        NumberOfBookings = grouped.Count(),
                        FirstBookingDate = grouped.Min(x => x.r.booking_start_date),
                        LastBookingDate = grouped.Max(x => x.r.booking_end_date),
                        TotalSpentMoney = grouped.Sum(x => x.r.price),
                        PersonEmail = grouped.Key.Email
                    };

        grid.DataSource = results.ToList();
    }
}

internal class NewClass
{
    public string Name { get; }
    public string Item { get; }
    public string Email { get; }

    public NewClass(string name, string item, string email)
    {
        Name = name;
        Item = item;
        Email = email;
    }

    public override bool Equals(object obj)
    {
        return obj is NewClass other &&
               Name == other.Name &&
               Item == other.Item &&
               Email == other.Email;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Item, Email);
    }
}