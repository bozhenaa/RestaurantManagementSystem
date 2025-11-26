using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.DTOs
{
    public record LogInDto([Required] string UsernameOrEmail, [Required][DataType(DataType.Password)] string Password);
}
