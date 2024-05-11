using DataAccessObjects.Interfaces;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class UserBLL
    {
        private IUserRepository _userRepository;

        public UserBLL(IUserRepository userRepository)
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
    }
}
