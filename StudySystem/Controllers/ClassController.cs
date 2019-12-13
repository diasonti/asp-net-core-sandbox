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
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            var sandboxDbContext = _context.Classes.Include(c => c.Course);
            return View(await sandboxDbContext.ToListAsync());
        }

        // GET: Class/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clazz = await _context.Classes
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clazz == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            return View(clazz);
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title");
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Topic,CourseId")] Class clazz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clazz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", clazz.CourseId);
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            return View(clazz);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clazz = await _context.Classes.FindAsync(id);
            if (clazz == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", clazz.CourseId);
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            return View(clazz);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,Topic,CourseId")] Class clazz)
        {
            if (id != clazz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clazz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(clazz.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", clazz.CourseId);
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            return View(clazz);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clazz = await _context.Classes
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clazz == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Classes";
            ViewData["page"] = "Class";
            return View(clazz);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var clazz = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(clazz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(long? id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
