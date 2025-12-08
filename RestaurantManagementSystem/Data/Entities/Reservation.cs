namespace RestaurantManagementSystem.Data.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ReservationName { get; set; }
        public string ReservationType { get; set; }
        public DateOnly ReservationDate { get; set; }
        public TimeOnly ReservationTime { get; set; }
        public int GuestNumber { get; set; }
        public List<ReservedTables> ReservedTables { get; set; }
    }
}
