namespace RestaurantManagementSystem.Data.Entities
{
    public class MenuItemIngredient
    {
        public int MenuItemIngredientId { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public decimal RequiredQuantity { get; set; }
    }
}
