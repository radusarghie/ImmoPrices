using Immo.Domain.BusinessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Immo.Database
{
    public class ImmoContext : DbContext
    {
        private readonly string connectionString;

        public ImmoContext(DbContextOptions<ImmoContext> options = null) : base(options)
        {
        }

        public ImmoContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<PropertyWebsite> PropertyWebsites { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Search> Searches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }

    public class ImmoContextFactory : IDesignTimeDbContextFactory<ImmoContext>
    {
        public ImmoContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImmoContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=Immo;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true");


            return new ImmoContext(optionsBuilder.Options);
        }
    }
}
