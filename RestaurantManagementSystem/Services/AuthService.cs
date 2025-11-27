using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<string> GetUserToken(User user)
        {
            var secret = _configuration["JWT_SECRET"];
            if (string.IsNullOrEmpty(secret))
            {
                throw new Exception("JWT Secret is missing");
            }
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                   new Claim("username", user.Username),
                   new Claim("role", user.UserRole.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
        public async Task RegisterUser(RegisterUserDto request)
        {
            if (_userRepository.GetUserByEmail(request.Email) != null || _userRepository.GetUserByUsername(request.Username) != null)
            {
                throw new Exception("User with this email already exists");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            User user = new User
            {
                Username = request.Username,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                HashedPassword = passwordHash,
                UserRole = Role.client
            };
            await _userRepository.AddUser(user);
        }

        public async Task<string> LogInUser(LogInDto request)
        {
            var user = await _userRepository.GetUserByUsernameOrEmail(request.UsernameOrEmail);
            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.HashedPassword);
            if (!isPasswordValid)
            {
                throw new Exception("Invalid password");
            }
            string userToken = await GetUserToken(user);
            return userToken;
        }
    }
}
