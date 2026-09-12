using Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.DTOs
{
    public class PatientDto : BaseDTOs
    {
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
