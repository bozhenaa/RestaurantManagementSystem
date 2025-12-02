using RestaurantManagementSystem.Enums;
using System.Text.Json.Serialization;

namespace RestaurantManagementSystem.Data.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MenuItemCategory Category { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }  
        public decimal? PromoPrice { get; set; }

        [JsonIgnore]
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();

    }
}
