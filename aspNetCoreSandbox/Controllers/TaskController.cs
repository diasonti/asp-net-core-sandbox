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
    public class TaskController : Controller
    {
        private SandboxDbContext _dbContext;

        public TaskController(SandboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // GET /api/task/fromdb
        [HttpGet]
        public ActionResult<List<TodoItem>> FromDb()
        {
            List<TodoItem> items =_dbContext.TodoItems.ToList();
            return new ActionResult<List<TodoItem>>(items);
        }

        // GET /api/task/items
        [HttpGet]
        public ActionResult<List<TodoItemForm>> items()
        {
            TodoItemForm item = new TodoItemForm();
            item.Id = 27;
            item.Text = "Doo the dishes";
            item.CreatedAt = DateTime.Now;
            List<TodoItemForm> list = new List<TodoItemForm>();
            list.Add(item);
            return new ActionResult<List<TodoItemForm>>(list);
        }
    }
}