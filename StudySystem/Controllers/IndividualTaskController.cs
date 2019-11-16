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
    public class IndividualTaskController : Controller
    {
        private readonly SandboxDbContext _context;

        public IndividualTaskController(SandboxDbContext context)
        {
            _context = context;
        }

        // GET: IndividualTask
        public async Task<IActionResult> Index()
        {
            var sandboxDbContext = _context.IndividualTasks.Include(i => i.Class).Include(i => i.Student);
            return View(await sandboxDbContext.ToListAsync());
        }

        // GET: IndividualTask/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualTask = await _context.IndividualTasks
                .Include(i => i.Class)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualTask == null)
            {
                return NotFound();
            }

            return View(individualTask);
        }

        // GET: IndividualTask/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Classes, "Id", "Id");
            return View();
        }

        // POST: IndividualTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,ClassId,StudentId")] IndividualTask individualTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individualTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", individualTask.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Classes, "Id", "Id", individualTask.StudentId);
            return View(individualTask);
        }

        // GET: IndividualTask/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualTask = await _context.IndividualTasks.FindAsync(id);
            if (individualTask == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", individualTask.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Classes, "Id", "Id", individualTask.StudentId);
            return View(individualTask);
        }

        // POST: IndividualTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,Text,ClassId,StudentId")] IndividualTask individualTask)
        {
            if (id != individualTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individualTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividualTaskExists(individualTask.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", individualTask.ClassId);
            ViewData["StudentId"] = new SelectList(_context.Classes, "Id", "Id", individualTask.StudentId);
            return View(individualTask);
        }

        // GET: IndividualTask/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualTask = await _context.IndividualTasks
                .Include(i => i.Class)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualTask == null)
            {
                return NotFound();
            }

            return View(individualTask);
        }

        // POST: IndividualTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var individualTask = await _context.IndividualTasks.FindAsync(id);
            _context.IndividualTasks.Remove(individualTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividualTaskExists(long? id)
        {
            return _context.IndividualTasks.Any(e => e.Id == id);
        }
    }
}
