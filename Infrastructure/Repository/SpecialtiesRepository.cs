using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SpecialtiesRepository : ISpecialtiesRepository
    {
        private readonly AppDbContext _context;

        public SpecialtiesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Specialties specialty)
        {
            _context.Specialties.Add(specialty);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var specialty = _context.Specialties.Find(id);
            if (specialty != null)
            {
                _context.Specialties.Remove(specialty);
                _context.SaveChanges();
            }
        }

        public List<Specialties> GetAll()
        {
            return _context.Specialties.ToList();
        }

        public Specialties GetById(int id)
        {
            return _context.Specialties.Find(id);
        }

        public void Update(Specialties specialty)
        {
            _context.Specialties.Update(specialty);
            _context.SaveChanges();
        }
    }
}
