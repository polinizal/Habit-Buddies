using Habit_Buddies.Controllers;
using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HabitBuddies.Tests
{
    public class HabitTests
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
        [TearDown]
        public void Teardown()
        {
            // Dispose the in-memory database after each test
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void CreateHabit()
        {
            
            var habit = new Habit
            {
                Title = "TestHabit",
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
            var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "TestHabit");
            Assert.IsNotNull(habitFromDb);
            Assert.AreEqual(habitFromDb.Title, habit.Title);     
        }
        
        [Test]
        public void GetHabit()
        {
            
            var habit = new Habit
            {
                Title = "TestHabit",
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
                var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "TestHabit");

                // Assert
                Assert.IsNotNull(habitFromDb);
                Assert.AreEqual(habitFromDb.Title, habit.Title);
        }
        [Test]
        public void DeleteHabit()
        {
            // Arrange  
            var habit = new Habit
            {
                Title = "TestHabit",
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
            var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "TestHabit");
            Assert.AreEqual(default(Habit), habitFromDb);

        }

        [Test]
        public void EditHabit()
        {
            // Arrange
            var habit = new Habit
            {
                Title = "TestHabit",
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
            habit.Title = "NewTestHabit";
           _context.SaveChanges();

            // Assert
            var habitFromDb = _context.Habits.FirstOrDefault(h => h.Title == "NewTestHabit");
            Assert.IsNotNull(habitFromDb);
            Assert.AreEqual(habitFromDb.Title, "NewTestHabit");
            
        }
        [Test]
        public async Task CompleteToday()
        {
            // Arrange
            var habit = new Habit
            {
                Title = "TestHabit",
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

            var user = new User
            {
                Id = "test-user",
                Email = "test@test.com",
            };
            _context.Habits.Add(habit);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var controller = new HabitsController(_context);

            // Act
            await controller.CompleteToday(habit.HabitId, habit.UserId);

            // Assert
            Assert.IsTrue(habit.IsCompletedToday);
            Assert.AreEqual(DateTime.Today, habit.LastCompletedDate);
            Assert.AreEqual(1, habit.CompletedDays);
        }
        [Test]
        public async Task CompleteToday_IsCompletedToday()
        {
            // Arrange
            var habit = new Habit
            {
                Title = "TestHabit",
                Description = "This is a test habit",
                Goal = "Test Goal",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                PercentageCompleted = 0,
                IsCompleted = false,
                IsCompletedToday = true,
                CompletedDays = 0,
                LastCompletedDate = DateTime.MinValue,
                AllDay = true,
                UserId = "test-user"
            };
            var user = new User
            {
                Id = "test-user",
                Email = "test@test.com",
            };
            _context.Habits.Add(habit);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var controller = new HabitsController(_context);

            // Act
            var result = await controller.CompleteToday(habit.HabitId, user.Id);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
        [Test]
        public async Task Complete()
        {
            // Arrange
            var habit = new Habit
            {
                Title = "TestHabit",
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
            var user = new User
            {
                Id = "test-user",
                Email = "test@test.com",
                Experience = 500,
                Rank = "procrastinator"
            };
            _context.Habits.Add(habit);
            _context.Users.Add(user);
            _context.SaveChanges();

            var controller = new HabitsController(_context);

            // Act
            await controller.Complete(habit.HabitId, user.Id);

            // Assert

            Assert.IsTrue(habit.IsCompleted);
            Assert.AreEqual(1000, user.Experience);
            Assert.AreEqual("newbie", user.Rank);
        }

    }
}