using BusinessObjects.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User Login(string userName, string password);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        string GenerateToken(User user);
    }
}
