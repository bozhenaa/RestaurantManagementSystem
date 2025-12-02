namespace RestaurantManagementSystem.Data.Entities
{
    public class OnlineOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Enums.OnlineOrderStatus Status { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
