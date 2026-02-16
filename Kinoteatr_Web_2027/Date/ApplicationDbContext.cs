using Kinoteatr_Web_2027.Models;
using Microsoft.EntityFrameworkCore;

namespace Kinoteatr_Web_2027.Date
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Ticket> Books { get; set; }
        public DbSet<Version> Students { get; set; }

    }
}
