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

        // GET: UserAccountToCourseLink/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title");
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts.Where(ua => ua.Role.Equals("STUDENT")), "Id", "Username");
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
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts.Where(ua => ua.Role.Equals("STUDENT")), "Id", "Username", userAccountToCourseLink.UserAccountId);
            return View(userAccountToCourseLink);
        }

        // GET: UserAccountToCourseLink/Delete
        public IActionResult Delete(long? userAccountId, long? courseId)
        {
            if (userAccountId == null || courseId == null)
            {
                return NotFound();
            }

            var userAccountToCourseLink = _context.UserAccountToCourseLink
                .Include(u => u.Course).Include(u => u.UserAccount)
                .Where(l => l.UserAccountId.Equals(userAccountId))
                .First(l => l.CourseId.Equals(courseId));
            if (userAccountToCourseLink == null)
            {
                return NotFound();
            }

            return View(userAccountToCourseLink);
        }

        // POST: UserAccountToCourseLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long userAccountId, long courseId)
        {
            var userAccountToCourseLink = _context.UserAccountToCourseLink
                .Where(l => l.UserAccountId.Equals(userAccountId))
                .First(l => l.CourseId.Equals(courseId));
            _context.UserAccountToCourseLink.Remove(userAccountToCourseLink);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
