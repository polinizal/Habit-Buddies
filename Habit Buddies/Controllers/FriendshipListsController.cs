using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Habit_Buddies.Data;
using Habit_Buddies.Data.Entities;

namespace Habit_Buddies.Controllers
{
    public class FriendshipListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendshipListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FriendshipLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FriendshipList.Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FriendshipLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FriendshipList == null)
            {
                return NotFound();
            }

            var friendshipList = await _context.FriendshipList
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendshipList == null)
            {
                return NotFound();
            }

            return View(friendshipList);
        }

        // GET: FriendshipLists/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return View();
        }

        // POST: FriendshipLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId")] FriendshipList friendshipList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendshipList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", friendshipList.UserId);
            return View(friendshipList);
        }

        // GET: FriendshipLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FriendshipList == null)
            {
                return NotFound();
            }

            var friendshipList = await _context.FriendshipList.FindAsync(id);
            if (friendshipList == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", friendshipList.UserId);
            return View(friendshipList);
        }

        // POST: FriendshipLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId")] FriendshipList friendshipList)
        {
            if (id != friendshipList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendshipList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendshipListExists(friendshipList.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", friendshipList.UserId);
            return View(friendshipList);
        }

        // GET: FriendshipLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FriendshipList == null)
            {
                return NotFound();
            }

            var friendshipList = await _context.FriendshipList
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friendshipList == null)
            {
                return NotFound();
            }

            return View(friendshipList);
        }

        // POST: FriendshipLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FriendshipList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FriendshipList'  is null.");
            }
            var friendshipList = await _context.FriendshipList.FindAsync(id);
            if (friendshipList != null)
            {
                _context.FriendshipList.Remove(friendshipList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendshipListExists(int id)
        {
          return (_context.FriendshipList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
