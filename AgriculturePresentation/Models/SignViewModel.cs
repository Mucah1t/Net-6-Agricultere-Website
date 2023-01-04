using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class SignViewModel
    {
        [Required(ErrorMessage ="Please enter a username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        public string password { get; set; }
    }
}
