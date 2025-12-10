using RestaurantManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class RequestReservationModel
    {
        [Required]
        public int Seats { get; set; }
        public RoomName RoomName { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly Time { get; set; }
    }
}
