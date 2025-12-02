using RestaurantManagementSystem.Data.Entities;

namespace RestaurantManagementSystem.Models
{
    public class MenuResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuItem> Dishes { get; set; }
    }
}
