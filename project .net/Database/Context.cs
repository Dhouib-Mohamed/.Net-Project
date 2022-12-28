using Microsoft.EntityFrameworkCore;
using project_.net.Models;
using project_.net.Models.project_.net.Models;


namespace project_.net.Database
{
    public class Context : DbContext
    {
        private static Context? Singleton = null;
       
        public Context(DbContextOptions o) : base(o) { }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public static Context getInstance()
         {
             if (Singleton == null)
             {
                 Singleton = new Context(null);
             }
             return Singleton;
         }
        
    }
}
