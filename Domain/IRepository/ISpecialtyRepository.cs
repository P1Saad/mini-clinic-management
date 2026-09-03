using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ISpecialtiesRepository
    {
        void Add(Specialties specialty);
        void Update(Specialties specialty);
        void Delete(int id);
        Specialties GetById(int id);
        List<Specialties> GetAll();
    }
}
