using System;
using System.Collections.Generic;
using Entities;

namespace Repository.Interfaces
{
    public interface IToDoTaskRepository
    {
        IReadOnlyList<ToDoTask> GetAllTasks();
        ToDoTask GetTaskById(Guid id);
        void CreateTask(ToDoTask toDoTask);
        void EditTask(ToDoTask toDoTask);
        void DeleteTask(ToDoTask toDoTask);
    }
}
