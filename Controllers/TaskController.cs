using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adet_mid_assignment_Espeleta_Michelle.Models;

namespace adet_mid_assignment_Espeleta_Michelle.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskDatabaseContext _db;
        public TaskModel Task { get; set; }
        public TaskController(TaskDatabaseContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Tasks.ToListAsync());
        }

        public IActionResult Upsert(int? id)
        {
            Task = new TaskModel();
            if (id == null)
            {
                return View(Task);
            }

            Task = _db.Tasks.FirstOrDefault(i => i.Id == id);
            if (Task == null)
            {
                return NotFound();
            }
            return View(Task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(int id)
        {
            Task = new TaskModel();
            if (ModelState.IsValid)
            {
                Task.Name = this.Request.Form["taskName"];
                Task.TaskDescription = this.Request.Form["taskDescription"];
                Task.Id = id;
                //Insert (Create Task)
                if (Task.Id == 0)
                {
                    Task.State = "To Do";
                    Task.TotalHours = 0;
                    Task.DateCreated = DateTime.Now;
                    //create
                    _db.Tasks.Add(Task);
                }
                else
                {
                    _db.Update(Task);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Task);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                _db.Tasks.Remove(task);
                _db.SaveChanges();
            }
            return RedirectToAction("index");

        }

        public async Task<IActionResult> ChangeState(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                if (task.State == "To Do")
                {
                    task.State = "Doing";
                    task.DateStarted = DateTime.Now;
                }
                else if (task.State == "Doing")
                {
                    task.State = "Done";
                    task.DateFinished = DateTime.Now;
                    task.TotalHours = int.Parse(this.Request.Form["totalHours"]);
                }
                _db.Update(task);
                _db.SaveChanges();

            }

            return RedirectToAction("index");
        }


    }
}
