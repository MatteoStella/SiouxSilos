using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByName(string name, string password);
    }
}
