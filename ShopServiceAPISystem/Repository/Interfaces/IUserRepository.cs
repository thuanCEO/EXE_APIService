using BusinessObjects.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User Login(string userName, string password);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        string GenerateToken(User user);
    }
}
