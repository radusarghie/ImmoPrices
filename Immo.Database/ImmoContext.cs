using Immo.Domain.BusinessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Immo.Database
{
    public class ImmoContext : DbContext
    {
        private readonly string connectionString;

        public ImmoContext(DbContextOptions<ImmoContext> options) : base(options)
        {
        }

        public ImmoContext(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<PropertyWebsite> PropertyWebsites { get; set; }
        public DbSet<HtmlPagedResult> HtmlPagedResults { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options
        //    .UseSqlServer("Data Source=RADU-LAPTOP-BE\\SQLEXPRESS;Database=Immo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
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
        public ImmoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImmoContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=Immo;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true");


            return new ImmoContext(optionsBuilder.Options);
        }
    }
}
