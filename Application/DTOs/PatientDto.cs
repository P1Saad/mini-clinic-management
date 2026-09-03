using Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs
{
    public class PatientDto : BaseDTOs
    {
        [Required]
        [RegularExpression(@"^(?!string$)", ErrorMessage = "Patient name is required.")]
        public string PatientName { get; set; }


        public string Phone { get; set; }
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^(?!string$)", ErrorMessage = "Patient gender is required.")]

        public string Gender { get; set; }
    }
}
