using RestaurantManagementSystem.DTOs;

namespace RestaurantManagementSystem.Models
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AddMenuItemModel> MenuItems { get; set; }
    }

}
