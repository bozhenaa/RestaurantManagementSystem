using RestaurantManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.DTOs
{
    public class AddRestaurantTableModel
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Table number must be between 1 and 1000")]
        public int TableNumber { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number of seats must be between 1 and 20")]
        public int Seats { get; set; }

        [Required]
        [EnumDataType(typeof(RoomName))]
        public RoomName RoomName { get; set; }
    }
}
