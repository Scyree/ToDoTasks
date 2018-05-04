using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models.TaskViewModels
{
    public class TaskCreateModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        [StringLength(2000, ErrorMessage = "Maximum number of characters is 2000!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A start is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "A end date is required.")]
        public DateTime EndDate { get; set; }
    }
}
