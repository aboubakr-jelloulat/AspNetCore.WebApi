using Microsoft.EntityFrameworkCore;

namespace DURC.Data;

public class ApplicationDbContext : DbContext
{

    //public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().ToTable("Products");
    }
}
