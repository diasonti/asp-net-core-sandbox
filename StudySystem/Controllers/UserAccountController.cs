using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudySystem.Data;
using StudySystem.Models;

namespace StudySystem.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserAccount
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View(await _context.UserAccounts.ToListAsync());
        }

        // GET: UserAccount/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View(userAccount);
        }

        // GET: UserAccount/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View();
        }

        // POST: UserAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Role")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View(userAccount);
        }

        // GET: UserAccount/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View(userAccount);
        }

        // POST: UserAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id,Username,Password,Role")] UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.Id))
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
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View(userAccount);
        }

        // GET: UserAccount/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "User Accounts";
            ViewData["page"] = "UserAccount";
            return View(userAccount);
        }

        // POST: UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);
            _context.UserAccounts.Remove(userAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult ValidatePassword(string password)
        { 
            if (password.Length < 6)
            {
                return Json(data: "Password should be at least 6 symbols long");
            }
            else if (password.Length > 255)
            {
                return Json(data: "Password should not be longer than 255 symbols");
            }
            else if (!Regex.Match(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$").Success)
            {
                return Json(data: "Password should contain lowercase and uppercase letters, and numbers");
            }
            return Json(data: true);
        }
        
        public IActionResult ValidateRole(string role)
        { 
            if (!role.Equals("ADMIN") && !role.Equals("STUDENT"))
            {
                return Json(data: "Role can be either 'ADMIN' or 'STUDENT'");
            }
            return Json(data: true);
        }
        
        private bool UserAccountExists(long? id)
        {
            return _context.UserAccounts.Any(e => e.Id == id);
        }
    }
}
