using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample.Models
{
    public class SampleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }

        public SexOfSample Sex { get; set; }

        public int Age { get; set; }

        public enum SexOfSample
        {
            [Display(Name = "1 Male")]
            Male = 1,
            [Display(Name = "2 Female")]
            Female = 2
        }
    }
}
