using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DataAccess.Common
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }


        public DbSet<UserEntity> Users { get; set; }
        /*public DbSet<GameEntity> Games { get; set; }
        public DbSet<CategoryEntity> Categoryes { get; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<WishlistEntity> Wishlists { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}
