using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{

    public interface IUserRepository
    {
        void Add(Users user);
        void Update(Users user);
        void Delete(int id);
        Users GetById(int id);

        List<Users> GetAll();

    }
}
