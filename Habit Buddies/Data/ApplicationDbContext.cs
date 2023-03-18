using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Habit_Buddies.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Habit>()
                        .HasRequired(h => h.Notification)
                        .WithRequiredPrincipal(n => n.Habit);
        }
        public DbSet<Habit> Habit { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}