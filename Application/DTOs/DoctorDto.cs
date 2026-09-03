using Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DoctorDto : BaseDTOs
    {
        public string DoctorName { get; set; }
        public string Phone { get; set; }
        public int SpecialtyID { get; set; }
    }
}
