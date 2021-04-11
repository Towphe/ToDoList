using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
        private todolistContext dbContext;
        public TasksController(todolistContext dbCtx)
        {
            dbContext = dbCtx;
        }
        public IActionResult Index()
        {
            return View(dbContext.Todos);
        }
        public IActionResult AddTask(string title, string title_desc)
        {
            dbContext.Todos.Add(new Todo()
            {
                TaskTitle = title,
                TaskDetails = title_desc
            });
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveTask(int taskID)
        {
            // Fix this - `ViewData["TitleId"]` returns null
            dbContext.Todos.Remove(dbContext.Todos.Find(taskID));
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
