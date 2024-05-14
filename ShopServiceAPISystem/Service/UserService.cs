using AutoMapper;
using BusinessObjects.Models;
using DTOs;
using Repository.Interfaces;

namespace Service
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUser();
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
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
        public void CreateUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            _userRepository.AddUser(user);
        }
    }
}
