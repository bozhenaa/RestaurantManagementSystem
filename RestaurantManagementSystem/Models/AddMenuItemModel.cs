using RestaurantManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.DTOs
{
    public class AddMenuItemModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(MenuItemCategory))]
        public MenuItemCategory Category { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Range(1, 8000, ErrorMessage = "Weight must be positive")]
        public int Weight { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal Price { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal? PromoPrice { get; set; }
    }
}
