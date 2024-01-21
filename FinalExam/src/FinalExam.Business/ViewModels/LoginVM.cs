using System.ComponentModel.DataAnnotations;

namespace FinalExam.Business.ViewModels
{
    public class LoginVM
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string UsernameOrEmail { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Password { get; set; }
    }
}
