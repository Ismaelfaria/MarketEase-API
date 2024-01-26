using MarketEase_API.Entity;
using Microsoft.EntityFrameworkCore;

namespace MarketEase_API.Pesistence
{
    public class ContextMarket : DbContext
    {
        public ContextMarket(DbContextOptions<ContextMarket> options) : base(options)
        {}

        public DbSet<Product> products { get; set; }
        public DbSet<PackagingTypes> packaging { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PackagingTypes>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.product)
                .WithOne()
                .HasForeignKey(s => s.PackagingTypesId);

                e.Property(de => de.Size)
                .IsRequired(true);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(de => de.Name)
                .IsRequired(false);
            });
        }
    }
}
