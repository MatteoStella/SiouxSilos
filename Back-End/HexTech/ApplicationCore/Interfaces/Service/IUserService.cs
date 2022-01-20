using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByName(string name, string password); 
    }
}
