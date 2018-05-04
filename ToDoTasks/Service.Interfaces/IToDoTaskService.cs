using System;
using System.Collections.Generic;
using Entities;

namespace Service.Interfaces
{
    public interface IToDoTaskService
    {
        IReadOnlyList<ToDoTask> GetAllTasks();
        void CreateTask(string userId, string title, string description, DateTime startDate, DateTime endDate);
        void EditTask(Guid id, string description, DateTime startDate, DateTime endDate);
        void DeleteTask(Guid id);
        ToDoTask GetTaskById(Guid id);
        double GetHours(Guid id);
    }
}
