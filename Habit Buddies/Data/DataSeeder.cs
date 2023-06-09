﻿using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Habit_Buddies.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DataSeeder(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }



        public void Seed()
        {
            var hasher = new PasswordHasher<User>();


            if (!applicationDbContext.Users.Any())
            {
                var users = new List<User>()
                {
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
                };

                if (!applicationDbContext.Habits.Any())
                {
                    var habits = new List<Habit>()
                {
                       new Habit
                    {
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", //ForeignKey
                        Title = "Reading",
                        Description = "Read 20 Pages A Day",
                        Goal = "Become A Passionate Reader",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        IsCompleted = false,
                        AllDay = false,

                    },
                    new Habit
                    {
                        UserId = "9a446965-a28a-4543-a9d6-9485d048cdb9", //ForeignKey
                        Title = "Swimming",
                        Description = "Swim On Monday And Friday",
                        Goal = "Get Fit",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        IsCompleted = false,
                        AllDay = false,

                    },
                     new Habit
                     {
                         UserId = "9a495865-a21b-7852-a9d6-9445d042cnh9", //ForeignKey
                         Title = "Programming",
                         Description = "Learn Fundamentals Of Programming",
                         Goal = "Finish Course",
                         StartDate = DateTime.Now,
                         EndDate = DateTime.Now,
                         IsCompleted = false,
                         AllDay = false,
                         //Notifications = new[] {} //ASK BOUT THIS!!!
                     },
                      new Habit
                      {
                          UserId = "8b495865-a21b-7632-a9d6-9225d04263h9", //ForeignKey
                          Title = "Crypto",
                          Description = "Watch YouTube Videos And Articles About Crypto",
                          Goal = "Invest In Crypto",
                          StartDate = DateTime.Now,
                          EndDate = DateTime.Now,
                          IsCompleted = false,
                          AllDay = false,
                          //Notifications = new[] {} //ASK BOUT THIS!!!
                      }
                            };

                    if (!applicationDbContext.Notifications.Any())
                    {
                        var notifications = new List<Notification>()
                        {
                            new Notification
                            {

                                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", //ForeignKey, UserName => myuser
                                Habit = habits[0], //ForeignKey, Habit.Title => Reading
                                Title = "Reading",
                                Description = "Get your ass up and start reading!"

                            },
                            new Notification
                            {

                                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", //ForeignKey, UserName => myuser
                                Habit = habits[0], //ForeignKey, Habit.Title => Reading
                                Title = "Reading",
                                Description = "Go read your crypto book!",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true

                            },
                            new Notification
                            {

                                UserId = "9a446965-a28a-4543-a9d6-9485d048cdb9", //ForeignKey, UserName => myuser
                                Habit = habits[1], //ForeignKey, Habit.Title => Reading
                                Title = "Swimming",
                                Description = "You can do it! Go to your training!",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true
                            },
                            new Notification
                            {
                                UserId = "9a446965-a28a-4543-a9d6-9485d048cdb9", //ForeignKey, UserName => myuser
                                Habit = habits[1], //ForeignKey, Habit.Title => Reading
                                Title = "Swimming",
                                Description = "The pool is waiting for you!",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true
                            },
                            new Notification
                            {
                                UserId = "9a495865-a21b-7852-a9d6-9445d042cnh9", //ForeignKey, UserName => myuser
                                Habit = habits[2], //ForeignKey, Habit.Title => Reading
                                Title = "Programming",
                                Description = "One more course chapter is waiting for you!",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true
                            },
                            new Notification
                            {
                                UserId = "9a495865-a21b-7852-a9d6-9445d042cnh9", //ForeignKey, UserName => myuser
                                Habit = habits[2], //ForeignKey, Habit.Title => Reading
                                Title = "Programming",
                                Description = "Your dream project is near!",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true
                            },
                            new Notification
                            {
                                UserId = "8b495865-a21b-7632-a9d6-9225d04263h9", //ForeignKey, UserName => myuser
                                Habit = habits[3], //ForeignKey, Habit.Title => Reading
                                Title = "Crypto",
                                Description = "Don't forget your side hustle!",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true
                            },
                            new Notification
                            {

                                UserId = "8b495865-a21b-7632-a9d6-9225d04263h9", //ForeignKey, UserName => myuser
                                Habit = habits[3], //ForeignKey, Habit.Title => Reading
                                Title = "Crypto",
                                Description = "What about the crypto?",
                                NotificationTime = DateTime.Now,
                                IsEnabled = true
                            }
                        };

                        applicationDbContext.Users.AddRange(users);
                        applicationDbContext.Habits.AddRange(habits);
                        applicationDbContext.Notifications.AddRange(notifications);
                        applicationDbContext.SaveChanges();


                    }
                }


            }
        }
    }
}
