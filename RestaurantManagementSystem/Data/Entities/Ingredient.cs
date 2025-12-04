namespace RestaurantManagementSystem.Data.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string Name { get; set; }

        public decimal Quantity { get; set; }   

        public string Unit { get; set; }        

        public ICollection<MenuItemIngredient> MenuItemIngredients { get; set; } = new List<MenuItemIngredient>();
    }
}
