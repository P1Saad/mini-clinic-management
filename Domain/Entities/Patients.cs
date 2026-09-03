using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patients : BaseEntity
    {
        public string PatientName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

    }
}
