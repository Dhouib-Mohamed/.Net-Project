using Microsoft.EntityFrameworkCore;
using project_.net.Models;

namespace project_.net.Database
{
    public class Context : DbContext
    {
        private static Context? Singleton = null;
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Category> Categories { get; set; }
        private Context(DbContextOptions o) : base(o) { }

        public static Context getInstance()
        {
            if (Singleton == null)
            {
                Singleton = Instatiate_Context();
            }
            return Singleton;
        }
        public static Context Instatiate_Context()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            optionsBuilder.UseSqlite("Data source=.\\database.db;");

            return new Context(optionsBuilder.Options);
        }
    }
}
