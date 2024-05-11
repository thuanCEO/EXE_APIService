using DataAccessObjects.Interfaces;
using DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly bs6ow0djyzdo8teyhoz4Context _context;
        public UserRepository(bs6ow0djyzdo8teyhoz4Context context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
