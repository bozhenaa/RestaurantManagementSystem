using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class CreateOnlineOrderModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public List<CartItemsModel> Items { get; set; }
    }

    public class CartItemsModel
    {
        [Required]
        public int MenuItemId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
