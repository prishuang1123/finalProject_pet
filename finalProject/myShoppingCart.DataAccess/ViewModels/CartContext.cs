using Microsoft.EntityFrameworkCore;
using myShoppingCart.DataAccess;
using myShoppingCart.Models;

namespace myShoppingCart.ViewModels
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { categoryId = 1, categoryName = "cat", categoryDesc = "training courses for cats" },
                new Category { categoryId = 2, categoryName = "dog(s)", categoryDesc = "training courses for small dogs" }
                );
        }




    }

}
