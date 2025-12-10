using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Models
{
    public class MakeReservationModel
    {
        public int ReservationId { get; set; }
        public string ReservationName { get; set; }
        public string ReservationType { get; set; }
        public RoomName ReservationRoom { get; set; }
        public DateOnly ReservationDate { get; set; }
        public TimeOnly ReservationTime { get; set; }
        public int GuestNumber { get; set; }
    }
}
