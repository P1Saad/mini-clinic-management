using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointments : BaseEntity
    {
        public Patients Patient { get; set; }
        public int PatientID { get; set; }
        public Doctors Doctor { get; set; }
        public int DoctorID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }

    }
}
