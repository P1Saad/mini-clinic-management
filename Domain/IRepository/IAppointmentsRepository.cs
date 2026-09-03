using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IAppointmentsRepository
    {
        void Add(Appointments appointment);
        void Update(Appointments appointment);
        void Delete(int id);
        Appointments GetById(int id);
        List<Appointments> GetAll();
    }
}
