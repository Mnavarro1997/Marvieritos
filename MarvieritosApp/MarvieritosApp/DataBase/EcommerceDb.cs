using MarvieritosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MarvieritosApp.DataBase
{
    public partial class EcommerceDb : DbContext
    {
        public DbSet<Cart> Cart { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }

        public EcommerceDb(DbContextOptions<EcommerceDb> options)
            : base(options)
        {
        }
    }
}