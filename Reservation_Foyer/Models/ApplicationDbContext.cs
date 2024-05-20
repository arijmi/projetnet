using Microsoft.EntityFrameworkCore;
using Reservation_Foyer.Models;

namespace Reservation_Foyer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {
        }
 
        public DbSet<Foyer> Foyer { get; set; }
        public DbSet<Universite> Universites { get; set; }
        public DbSet<Foyer> Foyers { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Universite> Universite { get; set; }

        public DbSet<Reservation_Foyer.Models.Chambre> Chambre { get; set; } = default!;

    }
}
