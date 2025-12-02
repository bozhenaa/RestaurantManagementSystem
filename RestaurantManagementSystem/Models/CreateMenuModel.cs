namespace RestaurantManagementSystem.Models
{
    public class CreateMenuModel
    {
        public string Name { get; set; }
        public List<int> MenuItemIds { get; set; } 
    }
}
