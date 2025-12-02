using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories.IRepositories;
using RestaurantManagementSystem.Services.IServices;
namespace RestaurantManagementSystem.Services
{
    public class PasswordTokenServices :IPasswordTokenService
    {
        public IPasswordTokenRepository _tokenRepository;
        public IUserRepository _userRepository;
        public IConfiguration _configuration;

        public PasswordTokenServices(IPasswordTokenRepository tokenRepository, IUserRepository userRepository, IConfiguration configuration)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> GeneratePasswordToken(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            var tokenBody = Guid.NewGuid().ToString();
            PasswordToken token = new PasswordToken
            {
                UserId = user.Id,
                TokenValue = tokenBody,
                Expiration = DateTime.UtcNow.AddHours(24)
            };
            await _tokenRepository.AddPasswordToken(token);
            return tokenBody;
        }

        public async Task<string> GeneratePasswordLink(string email)
        {
            string tokenValue = await GeneratePasswordToken(email);
            if (tokenValue == null)
            {
                return null;
            }
            var baseUrl = _configuration["ClientURL"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                return null;
            }
            var resetLink = $"{baseUrl}?token={tokenValue}";
            return resetLink;
        }
    }
}
