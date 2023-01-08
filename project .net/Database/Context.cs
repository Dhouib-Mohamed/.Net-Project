using Microsoft.EntityFrameworkCore;
using project_.net.Models;


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
                 Singleton = Instatiate_Context();
             }
             return Singleton;
         }
        public static Context Instatiate_Context()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(@"server=.;Database=MyData;TrustServerCertificate=True ; Integrated Security=SSPI ;", builder=>builder.EnableRetryOnFailure());

            return new Context(optionsBuilder.Options);
        }

    }
}
