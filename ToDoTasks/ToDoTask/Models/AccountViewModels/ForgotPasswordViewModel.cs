using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
