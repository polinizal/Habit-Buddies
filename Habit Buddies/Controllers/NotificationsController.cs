using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Habit_Buddies.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Notifications.Include(n => n.Habit).Include(n => n.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.Habit)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            int lastHabitId = _context.Habits.Max(h => h.HabitId); // get the last habit id from the habits table
            ViewData["HabitId"] = new SelectList(_context.Habits, "HabitId", "HabitId", lastHabitId); // set the last habit id as the default value in the dropdown list
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotificationId,Description,Title,UserId,NotificationTime,IsEnabled,HabitId")] Notification notification)
         {
        if (ModelState.IsValid)
        {
        int lastHabitId = await _context.Habits.Select(h => h.HabitId).MaxAsync(); // get the last habit id from the habits table
        notification.HabitId = lastHabitId; // set the HabitId of the new notification to the last HabitId in _context.Habits

        // Get the descriptions from the request form
        var descriptions = HttpContext.Request.Form["Description"];

        // Loop through the descriptions and create a new notification for each
        foreach (var description in descriptions)
        {
                    if (!string.IsNullOrEmpty(description))
                    {           // Create a new notification with the current description
                        var newNotification = new Notification
                        {
                            Description = description,
                            Title = notification.Title,
                            UserId = notification.UserId,
                            NotificationTime = notification.NotificationTime,
                            IsEnabled = notification.IsEnabled,
                            HabitId = notification.HabitId
                        };
                        _context.Add(newNotification);
                    }
              

            // Add the new notification to the database
           
        }

        await _context.SaveChangesAsync();
        return Redirect("https://localhost:7017/Habits");
    }

    ViewData["HabitId"] = new SelectList(_context.Habits, "HabitId", "HabitId", notification.HabitId);
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", notification.UserId);
    return View(notification);
}

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["HabitId"] = new SelectList(_context.Habits, "HabitId", "HabitId", notification.HabitId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", notification.UserId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotificationId,Description,Title,UserId,NotificationTime,IsEnabled,HabitId")] Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.NotificationId))
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
            ViewData["HabitId"] = new SelectList(_context.Habits, "HabitId", "HabitId", notification.HabitId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", notification.UserId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.Habit)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notifications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notification'  is null.");
            }
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
          return (_context.Notifications?.Any(e => e.NotificationId == id)).GetValueOrDefault();
        }
    }
}
