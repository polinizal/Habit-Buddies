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
    public class FakeFriendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FakeFriendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FakeFriends
        public async Task<IActionResult> Index()
        {
              return _context.FakeFriends != null ? 
                          View(await _context.FakeFriends.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.FakeFriends'  is null.");
        }

        // GET: FakeFriends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FakeFriends == null)
            {
                return NotFound();
            }

            var fakeFriend = await _context.FakeFriends
                .FirstOrDefaultAsync(m => m.FakeFriendId == id);
            if (fakeFriend == null)
            {
                return NotFound();
            }

            return View(fakeFriend);
        }

        // GET: FakeFriends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FakeFriends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FakeFriendId,FriendName,FriendRank")] FakeFriend fakeFriend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fakeFriend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fakeFriend);
        }

        // GET: FakeFriends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FakeFriends == null)
            {
                return NotFound();
            }

            var fakeFriend = await _context.FakeFriends.FindAsync(id);
            if (fakeFriend == null)
            {
                return NotFound();
            }
            return View(fakeFriend);
        }

        // POST: FakeFriends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FakeFriendId,FriendName,FriendRank")] FakeFriend fakeFriend)
        {
            if (id != fakeFriend.FakeFriendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakeFriend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakeFriendExists(fakeFriend.FakeFriendId))
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
            return View(fakeFriend);
        }

        // GET: FakeFriends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FakeFriends == null)
            {
                return NotFound();
            }

            var fakeFriend = await _context.FakeFriends
                .FirstOrDefaultAsync(m => m.FakeFriendId == id);
            if (fakeFriend == null)
            {
                return NotFound();
            }

            return View(fakeFriend);
        }

        // POST: FakeFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FakeFriends == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FakeFriends'  is null.");
            }
            var fakeFriend = await _context.FakeFriends.FindAsync(id);
            if (fakeFriend != null)
            {
                _context.FakeFriends.Remove(fakeFriend);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakeFriendExists(int id)
        {
          return (_context.FakeFriends?.Any(e => e.FakeFriendId == id)).GetValueOrDefault();
        }
    }
}
