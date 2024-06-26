﻿using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.AspNetCore.Http;
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
        public User GetUserById(int id)
        {
            return _dao.GetUserById(id);
        }

        public User Login(string userName, string password)
        {

            return _dao.Login(userName, password);
        }

        public async Task UpdateUser(User user, IFormFile image)
        {
            await _dao.UpdateUser(user, image);
        }

        public string GenerateToken(User user)
        {
            return _dao.GenerateToken(user);
        }

        public async Task<User> LoginGoogle(string idToken)
        {
            return await _dao.LoginGoogle(idToken);
        }
        public int CountUsers(int? status = null)
        {
            return _dao.CountUsers(status);
        }

        public Task<bool> ForgotPassword(string email)
        {
            return _dao.ForgotPassword(email);
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message, List<IFormFile> attachments = null)
        {
            await _dao.SendEmailAsync(toEmail, subject, message, attachments);
        }

        public void UpdatePassword(int userId, string Password)
        {
            _dao.UpdatePassword(userId, Password);
        }
    }
}
