using System;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using ToDoTask.Models.TaskViewModels;

namespace ToDoTask.Controllers
{
    public class ToDoTasksController : Controller
    {
        private readonly IToDoTaskService _service;

        public ToDoTasksController(IToDoTaskService service)
        {
            _service = service;
        }

        // GET: Tasks
        public IActionResult Index()
        {
            return View(_service.GetAllTasks());
        }

        // GET: Tasks/Details
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoTask = _service.GetTaskById(id.Value);

            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId, Title, Description, StartDate, EndDate")] TaskCreateModel taskCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskCreateModel);
            }

            _service.CreateTask(taskCreateModel.UserId, taskCreateModel.Title, taskCreateModel.Description, taskCreateModel.StartDate, taskCreateModel.EndDate);

            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Edit
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = _service.GetTaskById(id.Value);

            if (taskToDo == null)
            {
                return NotFound();
            }

            var taskEditModel = new TaskEditModel(
                taskToDo.Title,
                taskToDo.Description,
                taskToDo.StartDate,
                taskToDo.EndDate
            );

            return View(taskEditModel);
        }

        // POST: Tasks/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Title, Description, StartDate, EndDate")] TaskEditModel taskEditModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskEditModel);
            }

            _service.EditTask(id, taskEditModel.Title, taskEditModel.Description, taskEditModel.StartDate, taskEditModel.EndDate);

            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Delete
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskToDo = _service.GetTaskById(id.Value);

            if (taskToDo == null)
            {
                return NotFound();
            }

            return View(taskToDo);
        }

        // POST: Tasks/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _service.DeleteTask(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
