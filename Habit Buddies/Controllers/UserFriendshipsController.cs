using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Habit_Buddies.Controllers
{
    public class UserFriendshipsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserFriendshipsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserFriendships
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID
            var userFriendships = await _context.UserFriendships.Where(h => h.UserId == userId).ToListAsync(); // Get the habits created by the current user
            return View(userFriendships);
        }

        // GET: UserFriendships/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserFriendships == null)
            {
                return NotFound();
            }

            var userFriendship = await _context.UserFriendships
                .Include(u => u.User)
                .Include(u => u.UserFriend)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userFriendship == null)
            {
                return NotFound();
            }

            return View(userFriendship);
        }

        // GET: UserFriendships/Create
        public IActionResult Create()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usersExceptCurrent = _context.Users.Where(u => u.Id != currentUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UserFriendId"] = new SelectList(usersExceptCurrent, "Id", "Id");
            return View();
        }

        // POST: UserFriendships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,UserFriendId")] UserFriendship userFriendship)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(userFriendship);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserId);
        //    ViewData["UserFriendId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserFriendId);
        //    return View(userFriendship);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserFriendId")] UserFriendship userFriendship)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Check if the friendship already exists
                var existingFriendship = await _context.UserFriendships.FirstOrDefaultAsync(
                    uf => uf.UserId == currentUserId && uf.UserFriendId == userFriendship.UserFriendId);
                var existingFriendId = await _context.Users.FirstOrDefaultAsync(
                    uf => uf.Id == userFriendship.UserFriendId);

                if (currentUserId == userFriendship.UserFriendId)
                {
                    ModelState.AddModelError(string.Empty, "You can't add yourself as a friend :(");
                }
                else if (existingFriendId == null)
                {
                    ModelState.AddModelError(string.Empty, "This user doesn't exist");
                }
                else if (existingFriendship != null)
                {
                    ModelState.AddModelError(string.Empty, "You are already friends with this user.");
                }
                else
                {
                    // Add the friendship to the database
                    userFriendship.UserId = currentUserId;
                    _context.Add(userFriendship);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            // If we get here, there was a validation error, so we redisplay the form with error messages
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserId);
            ViewData["UserFriendId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserFriendId);
            return View(userFriendship);
        }

        // GET: UserFriendships/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserFriendships == null)
            {
                return NotFound();
            }

            var userFriendship = await _context.UserFriendships.FindAsync(id);
            if (userFriendship == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserId);
            ViewData["UserFriendId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserFriendId);
            return View(userFriendship);
        }

        // POST: UserFriendships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,UserFriendId")] UserFriendship userFriendship)
        {
            if (id != userFriendship.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFriendship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFriendshipExists(userFriendship.UserId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserId);
            ViewData["UserFriendId"] = new SelectList(_context.Users, "Id", "Id", userFriendship.UserFriendId);
            return View(userFriendship);
        }

        // GET: UserFriendships/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.UserFriendship == null)
        //    {
        //        return NotFound();
        //    }

        //    var userFriendship = await _context.UserFriendship
        //        .Include(u => u.User)
        //        .Include(u => u.UserFriend)
        //        .FirstOrDefaultAsync(m => m.UserId == id);
        //    if (userFriendship == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userFriendship);
        //}
        public async Task<IActionResult> Delete(string userId, string userFriendId)
        {
            var userFriendship = await _context.UserFriendships.FindAsync(userId, userFriendId);

            if (userFriendship == null)
            {
                return NotFound();
            }

            return View(userFriendship);
        }

        // POST: UserFriendships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserFriendships == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserFriendship'  is null.");
            }
            var userFriendship = await _context.UserFriendships.FindAsync(id);
            if (userFriendship != null)
            {
                _context.UserFriendships.Remove(userFriendship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFriendshipExists(string id)
        {
          return (_context.UserFriendships?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
       
    }
}
