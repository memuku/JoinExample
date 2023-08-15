using Data.Model;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=mydatabase;User=root;Password=root;",
                                       new MySqlServerVersion(new Version(8, 0, 34)));
            }
        }
    }
}

