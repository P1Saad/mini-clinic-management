using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : BaseEntity
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }


    }
}
