using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
