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
    public class PatientsRepository : IPatientsRepository
    {
        private readonly AppDbContext _context;

        public PatientsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Patients patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public List<Patients> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patients GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public void Update(Patients patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }
    }
}
