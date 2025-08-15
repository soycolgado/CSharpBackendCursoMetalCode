namespace Backend.Models;

using Microsoft.EntityFrameworkCore;

public class StoreContext: DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
        
    }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Beer> Beers { get; set; }
    
}