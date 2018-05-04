using Persistence;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Repository.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ApplicationDbContext _databaseService;

        public ToDoTaskRepository(ApplicationDbContext databaseService)
        {
            _databaseService = databaseService;
        }

        public IReadOnlyList<ToDoTask> GetAllTasks()
        {
            return _databaseService.ToDoTasks.ToList();
        }

        public ToDoTask GetTaskById(Guid id)
        {
            return _databaseService.ToDoTasks.SingleOrDefault(task => task.Id == id);
        }

        public void CreateTask(ToDoTask toDoTask)
        {
            _databaseService.ToDoTasks.Add(toDoTask);

            _databaseService.SaveChanges();
        }

        public void EditTask(ToDoTask toDoTask)
        {
            _databaseService.ToDoTasks.Update(toDoTask);

            _databaseService.SaveChanges();
        }

        public void DeleteTask(ToDoTask toDoTask)
        {
            _databaseService.ToDoTasks.Remove(toDoTask);

            _databaseService.SaveChanges();
        }
    }
}
