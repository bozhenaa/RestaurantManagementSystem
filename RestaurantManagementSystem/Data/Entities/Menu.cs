namespace RestaurantManagementSystem.Data.Entities
{
    public class Menu
    {
        
            public int Id { get; set; }
            public string Name { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }

    }

