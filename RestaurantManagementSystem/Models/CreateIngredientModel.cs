namespace RestaurantManagementSystem.Models
{
    public class CreateIngredientModel
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }

        
        public List<MenuItemIngredientModel> MenuItemIngredients { get; set; } = new List<MenuItemIngredientModel>();
    }
}
