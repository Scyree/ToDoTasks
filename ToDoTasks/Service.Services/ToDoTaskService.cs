using System;
using System.Collections.Generic;
using Entities;
using Service.Interfaces;
using Repository.Interfaces;

namespace Service.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IWorkingWithFiles _fileManagement;
        private readonly IToDoTaskRepository _repository;
        private readonly string _folder;

        public ToDoTaskService(IWorkingWithFiles fileManagement, IToDoTaskRepository repository)
        {
            _fileManagement = fileManagement;
            _repository = repository;
            _folder = "task";
        }
        
        public IReadOnlyList<ToDoTask> GetAllTasks()
        {
            return _repository.GetAllTasks();
        }
        
        public void CreateTask(string userId, string title, string description, DateTime startDate, DateTime endDate)
        {
            var value = Guid.NewGuid();
            var random = new Random();
            var taskFile = random.Next(1, 6);
            var path = _folder +  "\\" + value;
            var imageName = _folder + taskFile + ".jpg";
            
            _fileManagement.CopyFile(_folder, value, taskFile.ToString());

            var toDoTask = ToDoTask.CreateToDoTask(
                userId,
                title,
                description,
                path,
                imageName,
                startDate,
                endDate
            );

            _repository.CreateTask(toDoTask);
        }

        public void EditTask(Guid id, string title, string description, DateTime startDate, DateTime endDate)
        {
            var taskToBeEdited = _repository.GetTaskById(id);

            if (taskToBeEdited != null)
            {
                if (description != null)
                {
                    taskToBeEdited.Description = description;
                }

                if (title != null)
                {
                    taskToBeEdited.Title = title;
                }
                
                _repository.EditTask(taskToBeEdited);
            }
        }

        public void DeleteTask(Guid id)
        {
            var taskToBeDeleted = _repository.GetTaskById(id);

            if (taskToBeDeleted != null)
            {
                _repository.DeleteTask(taskToBeDeleted);
            }
        }

        public ToDoTask GetTaskById(Guid id)
        {
            return _repository.GetTaskById(id);
        }

        public double GetHours(Guid id)
        {
            var dueTime = _repository.GetTaskById(id);

            if (dueTime.StartDate > dueTime.EndDate)
            {
                return (dueTime.StartDate - dueTime.EndDate).TotalHours;
            }
            return (dueTime.EndDate - dueTime.StartDate).TotalHours;
        }
    }
}
