using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using riode_backend.Models;

namespace riode_backend.Contexts
{
    public class RiodeDbContext : IdentityDbContext<AppUser>
    {
        public RiodeDbContext(DbContextOptions<RiodeDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;   
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;
        public DbSet<Blog> Blogs { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
