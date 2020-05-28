using Microsoft.EntityFrameworkCore;

namespace TableData.Models
{
  public class TableDataContext : DbContext
  {
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cuisine> Cuisine { get; set; }

    public TableDataContext(DbContextOptions options) : base(options) { }
  }
}