using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Application.Context
{
    public class SQLiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=employee.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
              .HasKey(p => new { p.Id });
            //modelBuilder.Entity<Employee>()
            //    .HasData(GetEmployeeInitialData());
        }

        //private List<Employee> GetEmployeeInitialData()
        //{
        //    using var reader = new StreamReader("./data.json");
        //    var json = reader.ReadToEnd();
        //    var data = JsonConvert.DeserializeObject<List<Employee>>(json);
        //    return data;
        //}

        public DbSet<Employee>? Employee { get; set; }
    }
}
