using System;
using System.Collections.Generic;

namespace RestaurantManagementSystem.Data.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string State { get; set; }

        public ICollection<BillItem> BillItems { get; set; }
    }
}
