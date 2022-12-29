using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage ="This are should be filled.")]
        public string Title { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "This are should be filled.")]
        public string Image { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "This are should be filled.")]
        public string Description { get; set; }
    }

}
