using Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DoctorDto : BaseDTOs
    {
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int SpecialtyID { get; set; }
    }
}
