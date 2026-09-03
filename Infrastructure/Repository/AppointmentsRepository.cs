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
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly AppDbContext _context;

        public AppointmentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Appointments appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }

        public List<Appointments> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointments GetById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Update(Appointments appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }
    }
}
