using System.ComponentModel.DataAnnotations;


namespace TJS.VIMS.ViewModel
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Pass Phrase")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
      
    }
}