﻿using AutoMapper;
using BusinessObjects.Models;
using DTOs;
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
        public void UpdateUser(int id)
        {
            _userRepository.UpdateUser(id);
        }
        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }
    }
}
