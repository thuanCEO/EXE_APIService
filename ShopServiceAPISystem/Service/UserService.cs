using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Repository.Interfaces;

namespace Service
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
            return _userRepository.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User Login(string userName, string password)
        {
            return _userRepository.Login(userName, password);
        }

        public string GenerateToken(User user)
        {
            return _userRepository.GenerateToken(user);
        }
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
        public async Task UpdateUser(User user, IFormFile image)
        {
            await _userRepository.UpdateUser(user, image);
        }
        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }
    }
}
