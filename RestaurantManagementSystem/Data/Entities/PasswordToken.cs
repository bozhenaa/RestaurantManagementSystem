using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Data.Entities
{
    public class PasswordToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string TokenValue { get; set; }
        public DateTime Expiration { get; set; }
    }
}
