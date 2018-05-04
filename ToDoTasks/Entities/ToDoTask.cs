using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ToDoTask
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Folder { get; set; }

        public string ImageName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public static ToDoTask CreateToDoTask(string userId, string title, string description, string folder, string imageName, DateTime startDate, DateTime endDate)
        {
            var instance = new ToDoTask
            {
                Id = Guid.NewGuid()
            };

            instance.UpdateToDoTask(userId, title, description, folder, imageName, startDate, endDate);

            return instance;
        }

        private void UpdateToDoTask(string userId, string title, string description, string folder, string imageName, DateTime startDate, DateTime endDate)
        {
            UserId = userId;
            Title = title;
            Description = description;
            Folder = folder;
            ImageName = imageName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
