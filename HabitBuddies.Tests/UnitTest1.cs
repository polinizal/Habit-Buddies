using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace HabitBuddies.Tests
{
    public class Tests
    {
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            var _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyTestDb")
            .Options;
            _context = new ApplicationDbContext(_options);
        }

        [Test]
        public void AddHabit_AddsHabitToDatabase()
        {
            
            var habit = new Habit
            {
                Title = "Test Habit",
                Description = "This is a test habit",
                Goal = "Test Goal",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                PercentageCompleted = 0,
                IsCompleted = false,
                IsCompletedToday = false,
                CompletedDays = 0,
                LastCompletedDate = DateTime.MinValue,
                AllDay = true,
                UserId = "test-user"
            };

            // Act
            _context.Habits.Add(habit);
            _context.SaveChanges();

            // Assert
            var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "Test Habit");
            Assert.IsNotNull(habitFromDb);
            Assert.AreEqual(habitFromDb.Title, habit.Title);     
        }
        [Test]
        public void GetHabit_ReturnsHabitFromDatabase()
        {
            
            var habit = new Habit
            {
                Title = "Test Habit",
                Description = "This is a test habit",
                Goal = "Test Goal",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                PercentageCompleted = 0,
                IsCompleted = false,
                IsCompletedToday = false,
                CompletedDays = 0,
                LastCompletedDate = DateTime.MinValue,
                AllDay = true,
                UserId = "test-user"
            };
                _context.Habits.Add(habit);
                _context.SaveChanges();

                // Act
                var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "Test Habit");

                // Assert
                Assert.IsNotNull(habitFromDb);
                Assert.AreEqual(habitFromDb.Title, habit.Title);
        }
        [Test]
        public void DeleteHabit_DeletesHabitFromDatabase()
        {
            // Arrange  
            var habit = new Habit
            {
                Title = "Test Habit",
                Description = "This is a test habit",
                Goal = "Test Goal",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                PercentageCompleted = 0,
                IsCompleted = false,
                IsCompletedToday = false,
                CompletedDays = 0,
                LastCompletedDate = DateTime.MinValue,
                AllDay = true,
                UserId = "test-user"
            };
            _context.Habits.Add(habit);
            _context.SaveChanges();

            // Act
            _context.Habits.Remove(habit);
            _context.SaveChanges();

            // Assert
            var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "Test Habit");
            Assert.AreEqual(null, habitFromDb);

        }

        [Test]
        public void EditHabit_UpdatesHabitInDatabase()
        {
            // Arrange
            var habit = new Habit
            {
                Title = "Test Habit",
                Description = "This is a test habit",
                Goal = "Test Goal",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                PercentageCompleted = 0,
                IsCompleted = false,
                IsCompletedToday = false,
                CompletedDays = 0,
                LastCompletedDate = DateTime.MinValue,
                AllDay = true,
                UserId = "test-user"
            };
            _context.Habits.Add(habit);
            _context.SaveChanges();

            // Act
            habit.Title = "New Test Habit";
           _context.SaveChanges();

            // Assert
            var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "New Test Habit");
            Assert.IsNotNull(habitFromDb);
            Assert.AreEqual(habitFromDb.Title, "New Test Habit");
            
        }
    }
}