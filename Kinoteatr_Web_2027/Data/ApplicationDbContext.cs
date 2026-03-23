using Kinoteatr_Web_2027.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kinoteatr_Web_2027.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

    }
}
