using Application.Entities;
using Microsoft.EntityFrameworkCore;

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
        }

        public DbSet<Employee>? Employee { get; set; }
    }
}
