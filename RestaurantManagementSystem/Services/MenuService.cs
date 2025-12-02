using RestaurantManagementSystem.Data.Entities;
using RestaurantManagementSystem.Repositories;

namespace RestaurantManagementSystem.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepo;
        private readonly IMenuItemRepository _menuItemRepo;

        public MenuService(IMenuRepository menuRepo, IMenuItemRepository menuItemRepo)
        {
            _menuRepo = menuRepo;
            _menuItemRepo = menuItemRepo;
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            return await _menuRepo.GetAllMenus();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            var menu = await _menuRepo.GetMenuById(id);
            if (menu == null) throw new Exception("Menu not found.");
            return menu;
        }

        public async Task<Menu> CreateMenu(string name)
        {
            var menu = new Menu { Name = name };

            await _menuRepo.AddMenu(menu);
            await _menuRepo.SaveChangesAsync();

            return menu;
        }

        public async Task AddDishToMenu(int menuId, int dishId)
        {
            var menu = await _menuRepo.GetMenuById(menuId);
            var dish = await _menuItemRepo.GetMenuItemById(dishId);

            if (menu == null || dish == null)
                throw new Exception("Menu or dish not found.");

            if (!menu.MenuItems.Any(x => x.Id == dishId))
                menu.MenuItems.Add(dish);

            await _menuRepo.SaveChangesAsync();
        }

        public async Task RemoveDishFromMenu(int menuId, int dishId)
        {
            var menu = await _menuRepo.GetMenuById(menuId);
            if (menu == null) throw new Exception("Menu not found.");

            var dish = menu.MenuItems.FirstOrDefault(x => x.Id == dishId);
            if (dish == null) throw new Exception("Dish not in this menu.");

            menu.MenuItems.Remove(dish);

            await _menuRepo.SaveChangesAsync();
        }

        public async Task DeleteMenu(int menuId)
        {
            var menu = await _menuRepo.GetMenuById(menuId);
            if (menu == null)
                throw new Exception("Menu not found.");

            await _menuRepo.DeleteMenu(menu);
            await _menuRepo.SaveChangesAsync();
        }
    }
}
