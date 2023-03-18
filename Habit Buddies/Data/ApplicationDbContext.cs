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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Habit>()
        //        .HasOne(h => h.Notification)
        //        .WithOne(c => c.Post)
        //        .HasForeignKey(c => c.PostId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Comment>()
        //        .HasOne(c => c.Post)
        //        .WithMany(p => p.Comments)
        //        .OnDelete(DeleteBehavior.NoAction);
        //}
        public DbSet<Habit> Habit { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}