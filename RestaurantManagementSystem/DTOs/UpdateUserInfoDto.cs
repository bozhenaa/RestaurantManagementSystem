using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.DTOs
{
    public class UpdateUserInfoDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
