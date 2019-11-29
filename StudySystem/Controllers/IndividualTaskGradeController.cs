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
    public class IndividualTaskGradeController : Controller
    {
        private readonly SandboxDbContext _context;

        public IndividualTaskGradeController(SandboxDbContext context)
        {
            _context = context;
        }

        // GET: IndividualTaskGrade
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            var sandboxDbContext = _context.IndividualTaskGrades.Include(i => i.Task);
            return View(await sandboxDbContext.ToListAsync());
        }

        // GET: IndividualTaskGrade/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualTaskGrade = await _context.IndividualTaskGrades
                .Include(i => i.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualTaskGrade == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            return View(individualTaskGrade);
        }

        // GET: IndividualTaskGrade/Create
        public IActionResult Create()
        {
            ViewData["TaskId"] = new SelectList(_context.IndividualTasks, "Id", "Id");
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            return View();
        }

        // POST: IndividualTaskGrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade,TaskId")] IndividualTaskGrade individualTaskGrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individualTaskGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(_context.IndividualTasks, "Id", "Id", individualTaskGrade.TaskId);
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            return View(individualTaskGrade);
        }

        // GET: IndividualTaskGrade/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualTaskGrade = await _context.IndividualTaskGrades.FindAsync(id);
            if (individualTaskGrade == null)
            {
                return NotFound();
            }
            ViewData["TaskId"] = new SelectList(_context.IndividualTasks, "Id", "Id", individualTaskGrade.TaskId);
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            return View(individualTaskGrade);
        }

        // POST: IndividualTaskGrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,Grade,TaskId")] IndividualTaskGrade individualTaskGrade)
        {
            if (id != individualTaskGrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individualTaskGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividualTaskGradeExists(individualTaskGrade.Id))
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
            ViewData["TaskId"] = new SelectList(_context.IndividualTasks, "Id", "Id", individualTaskGrade.TaskId);
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            return View(individualTaskGrade);
        }

        // GET: IndividualTaskGrade/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualTaskGrade = await _context.IndividualTaskGrades
                .Include(i => i.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualTaskGrade == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Individual Task Grades";
            ViewData["page"] = "IndividualTaskGrade";
            return View(individualTaskGrade);
        }

        // POST: IndividualTaskGrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var individualTaskGrade = await _context.IndividualTaskGrades.FindAsync(id);
            _context.IndividualTaskGrades.Remove(individualTaskGrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividualTaskGradeExists(long? id)
        {
            return _context.IndividualTaskGrades.Any(e => e.Id == id);
        }
    }
}
