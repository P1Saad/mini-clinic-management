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
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly AppDbContext _context;

        public DoctorsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Doctors doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }

        public List<Doctors> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctors GetById(int id)
        {
            return _context.Doctors.Find(id);
        }

        public void Update(Doctors doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
    }
}
