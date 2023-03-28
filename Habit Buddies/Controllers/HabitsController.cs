using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;
using System.Security.Claims;

namespace Habit_Buddies.Controllers
{
    public class HabitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habits
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID
            var applicationDbContext = _context.Habits.Where(h => h.UserId == userId); // Get the habits created by the current user
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Habits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habits == null)
            {
                return NotFound();
            }

            var habit = await _context.Habits
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HabitId == id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // GET: Habits/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return View();
        }

        // POST: Habits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitId,UserId,Title,Description,Goal,StartDate,EndDate,IsCompleted")] Habit habit)
        {
            if (ModelState.IsValid)
            {
                habit.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Set the UserId property to the current user's ID
                _context.Add(habit);
                await _context.SaveChangesAsync();
                return Redirect("https://localhost:7017/Notifications/Create");
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", habit.UserId);
            return View(habit);

        }

        // GET: Habits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habits == null)
            {
                return NotFound();
            }

            var habit = await _context.Habits.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", habit.UserId);
            return View(habit);
        }

        // POST: Habits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitId,UserId,Title,Description,Goal,StartDate,EndDate,IsCompleted")] Habit habit)
        {
            if (id != habit.HabitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitExists(habit.HabitId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", habit.UserId);
            return View(habit);
        }

        // GET: Habits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habits == null)
            {
                return NotFound();
            }

            var habit = await _context.Habits
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HabitId == id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // POST: Habits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habit'  is null.");
            }
            var habit = await _context.Habits.FindAsync(id);
            if (habit != null)
            {
                _context.Habits.Remove(habit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitExists(int id)
        {
          return (_context.Habits?.Any(e => e.HabitId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Complete(int habitId, int userId)
        {
            var habit = await _context.Habits.FindAsync(habitId);
            var user = await _context.Users.FindAsync(userId);

            if (habit == null || user == null)
            {
                return NotFound();
            }

            user.Experience += 500;

            if (user.Experience >= 10000)
            {
                user.Rank = "god";
            }
            else if (user.Experience >= 5000)
            {
                user.Rank = "master";
            }
            else if (user.Experience >= 2000)
            {
                user.Rank = "average";
            }
            else if (user.Experience >= 500)
            {
                user.Rank = "newbie";
            }
            else if (user.Experience >= 0)
            {
                user.Rank = "procrastinator";
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
