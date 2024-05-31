using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _dao;
        public UserRepository(UserDAO dao)
        {
            _dao = dao;
        }

        public void CreateUser(User user)
        {
            _dao.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            _dao.DeleteUser(id);
        }
        public List<User> GetAllUsers()
        {
            return _dao.GetAllUsers();
        }

        public User Login(string userName, string password)
        {

            return _dao.Login(userName, password);
        }

        public void UpdateUser(User user)
        {
            _dao.UpdateUser(user);
        }

        public string GenerateToken(User user)
        {
            return _dao.GenerateToken(user);
        }

    }
}
