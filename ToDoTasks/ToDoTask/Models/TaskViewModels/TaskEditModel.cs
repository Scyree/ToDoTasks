using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models.TaskViewModels
{
    public class TaskEditModel
    {
        public TaskEditModel()
        {
        }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public TaskEditModel(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
