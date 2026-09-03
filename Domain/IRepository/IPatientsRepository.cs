using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IPatientsRepository
    {
        void Add(Patients patient);
        void Update(Patients patient);
        void Delete(int id);
        Patients GetById(int id);
        List<Patients> GetAll();
    }
}
