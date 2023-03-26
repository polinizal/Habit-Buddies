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

            modelBuilder.Entity<UserFriend>()
                .HasKey(uf => new { uf.UserId, uf.FakeFriendId });


            //DataBaseSeeder

            var hasher = new PasswordHasher<User>();

               modelBuilder.Entity<User>().HasData(

                new User
                {

                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    Email = "myuser@abv.bg",
                    UserName = "myuser",
                    NormalizedUserName = "MYUSER",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new User
                {

                    Id = "9a446965-a28a-4543-a9d6-9485d048cdb9", // primary key
                    Email = "polina.ilieva@yahoo.com",
                    UserName = "polina.staneva",
                    NormalizedUserName = "POLINA.STANEVA",
                    PasswordHash = hasher.HashPassword(null, "Test@123")
                },
                new User
                {

                    Id = "9a495865-a21b-7852-a9d6-9445d042cnh9", // primary key
                    Email = "soundcore@gmail.com",
                    UserName = "soundcore",
                    NormalizedUserName = "SOUNDCORE",
                    PasswordHash = hasher.HashPassword(null, "Test@123")
                },
                new User
                {

                    Id = "8b495865-a21b-7632-a9d6-9225d04263h9", // primary key
                    Email = "football_fan@gmail.com", //this
                    UserName = "football_fan", // this
                    NormalizedUserName = "FOOTBALL_FAN", //ask if can be diff
                    PasswordHash = hasher.HashPassword(null, "Test@123")
                }
        );
            
            modelBuilder.Entity<Habit>().HasData(

 
                new Habit 
                { 
                  HabitId = 1, //PrimaryKey
                  UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", //ForeignKey
                  Title="Reading",
                  Description = "Read 20 Pages A Day",
                  Goal = "Become A Passionate Reader",
                  StartDate = DateTime.Now,
                  IsCompleted = false,
                    
                },
                new Habit
                {
                    HabitId = 2, //PrimaryKey
                    UserId = "9a446965-a28a-4543-a9d6-9485d048cdb9", //ForeignKey
                    Title = "Swimming",
                    Description = "Swim On Monday And Friday",
                    Goal = "Get Fit",
                    StartDate = DateTime.Now,
                    IsCompleted = false,
                    
                },
                 new Habit
                 {
                     HabitId = 3, //PrimaryKey
                     UserId = "9a495865-a21b-7852-a9d6-9445d042cnh9", //ForeignKey
                     Title = "Programming",
                     Description = "Learn Fundamentals Of Programming",
                     Goal = "Finish Course",
                     StartDate = DateTime.Now,
                     IsCompleted = false,
                     //Notifications = new[] {} //ASK BOUT THIS!!!
                 },
                  new Habit
                  {
                      HabitId = 4, //PrimaryKey
                      UserId = "8b495865-a21b-7632-a9d6-9225d04263h9", //ForeignKey
                      Title = "Crypto",
                      Description = "Watch YouTube Videos And Articles About Crypto",
                      Goal = "Invest In Crypto",
                      StartDate = DateTime.Now,
                      IsCompleted = false,
                      //Notifications = new[] {} //ASK BOUT THIS!!!
                  }
        );
            modelBuilder.Entity<Notification>().HasData(
               new Notification
               {
                   NotificationId = 1, //PrimaryKey
                   UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", //ForeignKey, UserName => myuser
                   HabitId = 1, //ForeignKey, Habit.Title => Reading
                   Title = "Reading",
                   Description = "Get your ass up and start reading!"

               },
                  new Notification
                  {
                      NotificationId = 2, //PrimaryKey
                      UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", //ForeignKey, UserName => myuser
                      HabitId = 1, //ForeignKey, Habit.Title => Reading
                      Title = "Reading",
                      Description = "Go read your crypto book!",
                      NotificationTime = DateTime.Now,
                      IsEnabled = true

                  },
                   new Notification
                   {
                       NotificationId = 3, //PrimaryKey
                       UserId = "9a446965-a28a-4543-a9d6-9485d048cdb9", //ForeignKey, UserName => myuser
                       HabitId = 2, //ForeignKey, Habit.Title => Reading
                       Title = "Swimming",
                       Description = "You can do it! Go to your training!",
                       NotificationTime = DateTime.Now,
                       IsEnabled = true
                   },
                    new Notification
                    {
                        NotificationId = 4, //PrimaryKey
                        UserId = "9a446965-a28a-4543-a9d6-9485d048cdb9", //ForeignKey, UserName => myuser
                        HabitId = 2, //ForeignKey, Habit.Title => Reading
                        Title = "Swimming",
                        Description = "The pool is waiting for you!",
                        NotificationTime = DateTime.Now,
                        IsEnabled = true
                    },
                    new Notification
                    {
                        NotificationId = 5 , //PrimaryKey
                        UserId = "9a495865-a21b-7852-a9d6-9445d042cnh9", //ForeignKey, UserName => myuser
                        HabitId = 3, //ForeignKey, Habit.Title => Reading
                        Title = "Programming",
                        Description = "One more course chapter is waiting for you!",
                        NotificationTime = DateTime.Now,
                        IsEnabled = true
                    },
                    new Notification
                    {
                        NotificationId = 6, //PrimaryKey
                        UserId = "9a495865-a21b-7852-a9d6-9445d042cnh9", //ForeignKey, UserName => myuser
                        HabitId = 3, //ForeignKey, Habit.Title => Reading
                        Title = "Programming",
                        Description = "Your dream project is near!",
                        NotificationTime = DateTime.Now,
                        IsEnabled = true
                    },
                    new Notification
                    {
                        NotificationId = 7, //PrimaryKey
                        UserId = "8b495865-a21b-7632-a9d6-9225d04263h9", //ForeignKey, UserName => myuser
                        HabitId = 4, //ForeignKey, Habit.Title => Reading
                        Title = "Crypto",
                        Description = "Don't forget your side hustle!",
                        NotificationTime = DateTime.Now,
                        IsEnabled = true
                    },
                    new Notification
                    {
                        NotificationId = 8, //PrimaryKey
                        UserId = "8b495865-a21b-7632-a9d6-9225d04263h9", //ForeignKey, UserName => myuser
                        HabitId = 4, //ForeignKey, Habit.Title => Reading
                        Title = "Crypto",
                        Description = "What about the crypto?",
                        NotificationTime = DateTime.Now,
                        IsEnabled = true
                    }


        ); ;

        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FakeFriend> FakeFriends { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

    }
}