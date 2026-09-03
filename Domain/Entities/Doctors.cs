using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctors : BaseEntity
    {
        public string DoctorName { get; set; }
        public string Phone { get; set; }
        public Specialties Specialty { get; set; }
        public int SpecialtyID { get; set; }
    }
}
