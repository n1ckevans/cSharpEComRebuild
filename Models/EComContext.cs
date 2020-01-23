using Microsoft.EntityFrameworkCore;

namespace ECom.Models
{
  public class EComContext : DbContext
  {
    public EComContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Association> Associations { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Order> Orders { get; set; }
  }
}