using Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AppointmentDto : BaseDTOs
    {
        
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int DoctorID { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
