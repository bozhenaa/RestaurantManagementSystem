using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.DTOs;
using RestaurantManagementSystem.Repositories;

namespace RestaurantManagementSystem.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemService(MenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        public async Task AddMenuItem(AddMenuItemModel menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
            var newMenuItem = new MenuItem
            {
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                PromoPrice = menuItem.PromoPrice,
                Weight = menuItem.Weight
            };
            await _menuItemRepository.AddMenuItem(newMenuItem);
        }

        public async Task AddPromoPrice(MenuItem menuItem, decimal newPrice)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
            menuItem.PromoPrice = newPrice;
            await _menuItemRepository.UpdateMenuItem(menuItem);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
           return await _menuItemRepository.GetAllMenuItems();
        }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemRepository.GetMenuItemById(id);
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
            return menuItem;
        }

        public async Task RemoveMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
            await _menuItemRepository.RemoveMenuItem(menuItem);
        }

        public async Task RemovePromoPrice(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
            menuItem.PromoPrice = null;
            await _menuItemRepository.UpdateMenuItem(menuItem);
        }

        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
           await _menuItemRepository.UpdateMenuItem(menuItem);
        }

        public async Task DeleteMenuItem(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException();
            }
            await _menuItemRepository.RemoveMenuItem(menuItem);
        }
    }
}
