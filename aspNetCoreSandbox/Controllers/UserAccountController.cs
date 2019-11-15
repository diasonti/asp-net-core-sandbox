using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using aspNetCoreSandbox.Models;
using aspNetCoreSandbox.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreSandbox.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class UserAccountController : Controller
    {
        private readonly SandboxDbContext _dbContext;

        public UserAccountController(SandboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET /api/crud/all
        [HttpGet]
        public ActionResult<List<UserAccount>> All()
        {
            List<UserAccount> items =_dbContext.UserAccounts.ToList();
            List<UserAccount> forms = new List<UserAccount>();
            items.ForEach(item => forms.Add(item));
            return new OkObjectResult(forms);
        }
        
        // POST /api/crud/save
        [HttpPost]
        public ActionResult Save([FromBody] UserAccount form)
        {
            UserAccount entity = form.Id.HasValue ? _dbContext.UserAccounts.Find(form.Id.Value) : _dbContext.Add(new UserAccount()).Entity;
            entity.Username = form.Username;
            entity.Password = form.Password;
            entity.Role = form.Role;
            _dbContext.SaveChanges();
            return new OkResult();
        }
        
        // POST /api/crud/delete
        [HttpPost]
        public ActionResult Delete([FromBody] UserAccount form)
        {
            if (!form.Id.HasValue) 
                return new BadRequestResult();
            UserAccount crudItem = _dbContext.UserAccounts.Find(form.Id.Value);
            _dbContext.Remove(crudItem);
            _dbContext.SaveChanges();
            return new OkResult();
        }
    }
}
