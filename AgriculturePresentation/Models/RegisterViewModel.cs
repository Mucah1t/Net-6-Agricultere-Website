using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please, enter a username!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please, enter a password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, re-enter a password!")]
        [Compare("Password",ErrorMessage = "The passwords you entered do not match. Please, fix the error.")]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Please, enter a mail!")]
        public string Mail { get; set; }
    }
}
