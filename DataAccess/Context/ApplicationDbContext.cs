using DataAccess.Entities;
using DataAccess.Maps;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Salloon> Salloons { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<Week> Weeks { get; set; }
        public DbSet<SalloonSeat> SalloonSeats { get; set; }
        public DbSet<Seat> Seats { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieGenreMap());
            builder.ApplyConfiguration(new SalloonSeatMap());


            base.OnModelCreating(builder);
        }

    }
}
