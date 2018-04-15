using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class RestaurantContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Restaurant> restaurants {get;set;}
        public DbSet<Review> reviews {get;set;}
    }
}
