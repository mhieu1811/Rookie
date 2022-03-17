using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //code first
            //db first
            //model first
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>(entity =>
            {
                entity.ToTable(name: "Category");
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable(name: "Product");
            });
            builder.Entity<ProductPicture>(entity =>
            {
                entity.ToTable(name: "ProductPicture");
            });

         
            builder.Entity<Order>(entity =>
            {
                entity.ToTable(name: "Order");
            });
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable(name: "OrderItem");

            });
            builder.Entity<ProductDetails>(entity =>
            {
                entity.ToTable(name: "ProductDetail");
            });
            builder.Entity<ProductPicture>(entity =>
            {
                entity.ToTable(name: "ProductPicture");
            });
            builder.Entity<Rating>(entity =>
            {
                entity.ToTable(name: "Rating");

            });
            /*builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<UserDetails>(entity =>
            {
                entity.ToTable(name: "UserDetail");
            });*/
            builder.Entity<Cart>(entity =>
            {
                entity.ToTable(name: "Cart");
            });
        }
    }
}
