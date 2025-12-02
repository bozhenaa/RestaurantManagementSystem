using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.DTOs
{
    public class RegisterUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
