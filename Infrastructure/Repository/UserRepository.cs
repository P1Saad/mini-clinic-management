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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context; // dependency Injection

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        public Users GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public Users GetByIdandCatId(int id, int catId)
        {
            return _context.Users.Find(id, catId);
        }

        public void Update(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
