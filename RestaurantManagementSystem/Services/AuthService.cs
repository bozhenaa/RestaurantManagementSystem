using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> GetUserToken(User user)
        {
            var secret = _configuration["JWT_SECRET"];

            if (string.IsNullOrEmpty(secret))
                throw new Exception("JWT Secret is missing");

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.Username),
                new Claim("role", user.UserRole.ToString())
            };

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task RegisterUser(RegisterUserModel request)
        {
            if (await _userRepository.GetUserByEmail(request.Email) != null ||
                await _userRepository.GetUserByUsername(request.Username) != null)
            {
                throw new Exception("User already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

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

        public async Task<string> LogInUser(LogInModel request)
        {
            var user = await _userRepository.GetUserByUsernameOrEmail(request.UsernameOrEmail);

            if (user == null)
                throw new Exception("User not found");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.HashedPassword))
                throw new Exception("Invalid password");

            return await GetUserToken(user);
        }
    }
}
