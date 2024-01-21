using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Core.Models
{
    public class Setting : BaseEntity
    {
        [StringLength(maximumLength: 50)]
        public string? Key { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Value { get; set; }
    }
}
