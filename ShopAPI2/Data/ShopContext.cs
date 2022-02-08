using Microsoft.EntityFrameworkCore;

namespace ShopAPI2.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
             : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

    }
}
