using Microsoft.AspNetCore.Identity;
using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HashedPassword { get; set; }
        public Role UserRole { get; set; }
    }
}
