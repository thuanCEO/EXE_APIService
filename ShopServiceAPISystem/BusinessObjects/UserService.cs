using DataAccessObjects.Interfaces;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _userRepository.GetUserByUserNameAndPassword(userName, password);
        }

        public string GenerateToken(User user)
        {
            return _userRepository.GenerateToken(user);
        }
    }
}
