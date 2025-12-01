using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Data.Entities
{
    public class RestaurantTable
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public int TableNumber { get; set; }
        public RoomName RoomName { get; set; }

    }
}
