using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using aspNetCoreSandbox.Models;
using aspNetCoreSandbox.Models.Entities;
using aspNetCoreSandbox.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreSandbox.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CrudController : Controller
    {
        private readonly SandboxDbContext _dbContext;

        public CrudController(SandboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET /api/crud/all
        [HttpGet]
        public ActionResult<List<CrudItem>> All()
        {
            List<CrudItem> items =_dbContext.CrudItems.ToList();
            return new OkObjectResult(items);
        }
        
        // POST /api/crud/add
        [HttpPost]
        public ActionResult Save([FromBody] List<CrudItemForm> items)
        {
            foreach (CrudItemForm form in items)
            {
                CrudItem item;
                item = form.Id == 0 ? _dbContext.Add(new CrudItem()).Entity : _dbContext.CrudItems.Find(form.Id);

                item.Text = form.Text;
            }
            _dbContext.SaveChanges();
            return new OkResult();
        }
    }
}
