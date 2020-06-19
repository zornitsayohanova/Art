using Microsoft.EntityFrameworkCore;

namespace ArtFeverShop.Data
{
    public class ArtFeverShopContext : DbContext
    {
        private const string connectionString = @"Server=.\SQLEXPRESS;Database=ArtFeverShop;Trusted_Connection=True;";

        public ArtFeverShopContext() { }

        public ArtFeverShopContext(DbContextOptions<ArtFeverShopContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<ArtFeverShop.Models.Item> Items { get; set; }
        public DbSet<ArtFeverShop.Models.Category> Categories { get; set; }
    }
}
