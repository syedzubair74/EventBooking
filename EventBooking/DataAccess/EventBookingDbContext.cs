using EventBooking.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.DataAccess
{
    public class EventBookingDbContext : DbContext
    {
        public EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : base(options)
        {
        }

        public DbSet<AdminUser> AdminUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<AdminUser>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser
                {
                    Id = 1,
                   Username = "admin",
                   Password = "admin",
                }
            );
        }
        }
}
