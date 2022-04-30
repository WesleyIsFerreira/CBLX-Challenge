using APi_Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APi_Products.DataContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Product>()
            .Property(e => e.Kind)
            .HasConversion(
                v => v.ToString(),
                v => (Kind)Enum.Parse(typeof(Kind), v));
        }
    }
}
