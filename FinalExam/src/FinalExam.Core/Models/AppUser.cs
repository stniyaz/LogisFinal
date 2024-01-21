using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalExam.Core.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string FullName { get; set; }
    }
}
