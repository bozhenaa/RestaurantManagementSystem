using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.DTOs
{
    public class AddMenuItemModel
    {
        public string Name { get; set; }
        public MenuItemCategory Category { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }
    }
}
