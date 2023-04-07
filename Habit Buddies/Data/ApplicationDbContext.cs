using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Identity;
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
                .HasOne(h => h.User)
                .WithMany(n => n.Habits)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Habit)
                .WithMany(h => h.Notifications)
                .OnDelete(DeleteBehavior.NoAction);


            

            modelBuilder.Entity<UserFriendship>(uf =>
            {
                uf.HasKey(x => new { x.UserId, x.UserFriendId });

                uf.HasOne(x => x.User)
                    .WithMany(x => x.Friends)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                uf.HasOne(x => x.UserFriend)
                    .WithMany(x => x.FriendsOf)
                    .HasForeignKey(x => x.UserFriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });


        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Habit_Buddies.Data.Entities.UserFriendship>? UserFriendships { get; set; }

    }
}