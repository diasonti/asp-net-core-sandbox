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
    public class TaskGradeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskGradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskGrade
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            var sandboxDbContext = _context.TaskGrades.Include(t => t.Task);
            return View(await sandboxDbContext.ToListAsync());
        }

        // GET: TaskGrade/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskGrade = await _context.TaskGrades
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskGrade == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            return View(taskGrade);
        }

        // GET: TaskGrade/Create
        public IActionResult Create()
        {
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id");
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            return View();
        }

        // POST: TaskGrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade,TaskId")] TaskGrade taskGrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", taskGrade.TaskId);
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            return View(taskGrade);
        }

        // GET: TaskGrade/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskGrade = await _context.TaskGrades.FindAsync(id);
            if (taskGrade == null)
            {
                return NotFound();
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", taskGrade.TaskId);
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            return View(taskGrade);
        }

        // POST: TaskGrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,Grade,TaskId")] TaskGrade taskGrade)
        {
            if (id != taskGrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskGradeExists(taskGrade.Id))
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
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Id", taskGrade.TaskId);
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            return View(taskGrade);
        }

        // GET: TaskGrade/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskGrade = await _context.TaskGrades
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskGrade == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Task Grades";
            ViewData["page"] = "TaskGrade";
            return View(taskGrade);
        }

        // POST: TaskGrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var taskGrade = await _context.TaskGrades.FindAsync(id);
            _context.TaskGrades.Remove(taskGrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskGradeExists(long? id)
        {
            return _context.TaskGrades.Any(e => e.Id == id);
        }
    }
}
