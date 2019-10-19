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
        public ActionResult<List<CrudItemForm>> All()
        {
            List<CrudItem> items =_dbContext.CrudItems.ToList();
            List<CrudItemForm> forms = new List<CrudItemForm>();
            items.ForEach(item => forms.Add(item.toForm()));
            return new OkObjectResult(forms);
        }
        
        // POST /api/crud/save
        [HttpPost]
        public ActionResult Save([FromBody] CrudItemForm form)
        {
            CrudItem entity = form.Id.HasValue ? _dbContext.CrudItems.Find(form.Id.Value) : _dbContext.Add(new CrudItem()).Entity;
            entity.Text = form.Text;
            _dbContext.SaveChanges();
            return new OkResult();
        }
        
        // POST /api/crud/delete
        [HttpPost]
        public ActionResult Delete([FromBody] CrudItemForm form)
        {
            if (!form.Id.HasValue) 
                return new BadRequestResult();
            CrudItem crudItem = _dbContext.CrudItems.Find(form.Id.Value);
            _dbContext.Remove(crudItem);
            _dbContext.SaveChanges();
            return new OkResult();
        }
    }
}
