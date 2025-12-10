using RestaurantManagementSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Data.Entities
{
    public class Employee
    {
        [ForeignKey("User")]
        public int EmployeeId { get; set; }
        public User User { get; set; }

        public EmployeeRole JobTitle { get; set; }
        public decimal HourlyWage { get; set; }
        public DateTime HireDate { get; set; }
        public List<WorkShift> Shifts { get; set; }

    }
}
