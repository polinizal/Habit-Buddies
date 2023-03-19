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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Habit>()
                .HasMany(h => h.Notifications)
                .WithOne(n => n.Habit)
                .HasForeignKey(n => n.HabitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Habit>()
                .HasOne(h => h.User)
                .WithMany(n => n.Habits)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Habit)
                .WithMany(h => h.Notifications)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Friend>(b =>
            {
                b.HasKey(x => new { x.FriendshipListId, x.FriendUserId });
            });


        }
        public DbSet<Habit> Habit { get; set; }
        public DbSet<Notification> Notification { get; set; }

        public DbSet<Friend> Friend { get; set; }
        public DbSet<Notification> Friendship { get; set; }
    }
}