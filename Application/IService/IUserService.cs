using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IUserService
    {
        void CreateUser(UserDto userDto);
        UserDto GetUserById(int id);
        IList<UserDto> GetAllUsers();
        void UpdateUser(UserDto userDto);

        void DeleteUser(int id);
    }
}
