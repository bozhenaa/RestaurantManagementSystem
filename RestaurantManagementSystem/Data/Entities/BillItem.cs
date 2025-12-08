namespace RestaurantManagementSystem.Data.Entities
{
    public class BillItem
    {
        public int Id { get; set; }

        public int BillId { get; set; }
        public Bill Bill { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
