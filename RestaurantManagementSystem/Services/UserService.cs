using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace RestaurantManagementSystem.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null");
            }
            var existingUser = await _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with the same email already exists.");
            }
            await _userRepository.AddUser(user);
        }
        public async Task UpdateUser(UpdateUserInfoDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null");
            }
            var existingUser = await _userRepository.GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User does not exists.");
            }
            if (existingUser.Email != user.Email)
            {
                var checkEmail = await _userRepository.GetUserByEmail(user.Email);
                if (checkEmail != null)
                {
                    throw new InvalidOperationException("Email is already taken.");
                }
            }
            if (existingUser.Username != user.Username)
            {
                var checkUsername = await _userRepository.GetUserByUsername(user.Username);
                if (checkUsername != null)
                {
                    throw new InvalidOperationException("Username is already taken.");
                }
            }
            existingUser.Name = user.Name;
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            await _userRepository.UpdateUser(existingUser);
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User does not exists.");
            }
            await _userRepository.DeleteUser(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            return await _userRepository.GetUserByEmail(email);
        }


        public async Task<User> GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            return await _userRepository.GetUserByUsername(username);
        }
    }
}
