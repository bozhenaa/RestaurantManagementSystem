using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.DTOs
{
    public class AddRestaurantTableDto
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public RoomName RoomName { get; set; }
    }
}
