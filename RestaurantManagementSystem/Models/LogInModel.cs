using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.DTOs
{
    public record LogInModel([Required] string UsernameOrEmail, [Required][DataType(DataType.Password)] string Password);
}
