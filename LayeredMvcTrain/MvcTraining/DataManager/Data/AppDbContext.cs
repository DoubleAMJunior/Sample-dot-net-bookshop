using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER1;Initial Catalog=DataManager;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=12345678");
            base.OnConfiguring(optionsBuilder);
        }*/
        public DbSet<Core.Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Cnfigurations.UserConfig());
            modelBuilder.ApplyConfiguration(new Cnfigurations.AddressConfig());
        }
    }
}
