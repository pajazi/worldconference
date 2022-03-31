using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Country> Countries { get; set; }

		public DbSet<Company> Companies { get; set; }

		public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			builder.Entity<Country>().ToTable("Country");
			builder.Entity<Company>().ToTable("Company");
			builder.Entity<Employee>().ToTable("Employee");
        }
    }
}