using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudySystem.Data;
using StudySystem.Models;

namespace StudySystem.Controllers
{
    public class UserAccountToCourseLinkController : Controller
    {
        private readonly SandboxDbContext _context;

        public UserAccountToCourseLinkController(SandboxDbContext context)
        {
            _context = context;
        }

        // GET: UserAccountToCourseLink
        public async Task<IActionResult> Index()
        {
            var sandboxDbContext = _context.UserAccountToCourseLink.Include(u => u.Course).Include(u => u.UserAccount);
            return View(await sandboxDbContext.ToListAsync());
        }

        // GET: UserAccountToCourseLink/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccountToCourseLink = await _context.UserAccountToCourseLink
                .Include(u => u.Course)
                .Include(u => u.UserAccount)
                .FirstOrDefaultAsync(m => m.UserAccountId == id);
            if (userAccountToCourseLink == null)
            {
                return NotFound();
            }

            return View(userAccountToCourseLink);
        }

        // GET: UserAccountToCourseLink/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title");
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Password");
            return View();
        }

        // POST: UserAccountToCourseLink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserAccountId,CourseId")] UserAccountToCourseLink userAccountToCourseLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccountToCourseLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", userAccountToCourseLink.CourseId);
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Password", userAccountToCourseLink.UserAccountId);
            return View(userAccountToCourseLink);
        }

        // GET: UserAccountToCourseLink/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccountToCourseLink = await _context.UserAccountToCourseLink.FindAsync(id);
            if (userAccountToCourseLink == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", userAccountToCourseLink.CourseId);
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Password", userAccountToCourseLink.UserAccountId);
            return View(userAccountToCourseLink);
        }

        // POST: UserAccountToCourseLink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserAccountId,CourseId")] UserAccountToCourseLink userAccountToCourseLink)
        {
            if (id != userAccountToCourseLink.UserAccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccountToCourseLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountToCourseLinkExists(userAccountToCourseLink.UserAccountId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", userAccountToCourseLink.CourseId);
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Password", userAccountToCourseLink.UserAccountId);
            return View(userAccountToCourseLink);
        }

        // GET: UserAccountToCourseLink/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccountToCourseLink = await _context.UserAccountToCourseLink
                .Include(u => u.Course)
                .Include(u => u.UserAccount)
                .FirstOrDefaultAsync(m => m.UserAccountId == id);
            if (userAccountToCourseLink == null)
            {
                return NotFound();
            }

            return View(userAccountToCourseLink);
        }

        // POST: UserAccountToCourseLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userAccountToCourseLink = await _context.UserAccountToCourseLink.FindAsync(id);
            _context.UserAccountToCourseLink.Remove(userAccountToCourseLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountToCourseLinkExists(long id)
        {
            return _context.UserAccountToCourseLink.Any(e => e.UserAccountId == id);
        }
    }
}
