using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAllUser();
        public User GetUserByUserNameAndPassword(string userName, string password);
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
    }
}
