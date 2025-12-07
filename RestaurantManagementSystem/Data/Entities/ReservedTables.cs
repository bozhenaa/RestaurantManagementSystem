using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Data.Entities
{
    public class ReservedTables
    {
        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
       
        public int RestaurantTableId { get; set; }
        [ForeignKey("RestaurantTableId")]
        public RestaurantTable RestaurantTable { get; set; }

    }
}
