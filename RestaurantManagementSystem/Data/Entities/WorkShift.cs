namespace RestaurantManagementSystem.Data.Entities
{
    public class WorkShift
    {
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal CurrentHourlyWage { get; set; }
    }
}
