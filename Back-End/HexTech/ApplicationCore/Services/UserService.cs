using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserByName(string name, string password)
        {
            return _userRepository.GetByName(name, password);
        }
    }
}
