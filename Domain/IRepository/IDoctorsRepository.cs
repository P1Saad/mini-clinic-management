using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IDoctorsRepository
    {
        void Add(Doctors doctor);
        void Update(Doctors doctor);
        void Delete(int id);
        Doctors GetById(int id);
        List<Doctors> GetAll();
    }
}
