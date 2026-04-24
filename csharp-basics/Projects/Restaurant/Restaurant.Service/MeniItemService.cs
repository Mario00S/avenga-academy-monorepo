using Restaurant.Domain;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Models;

namespace Restaurant.Services;

public class MenuItemService
{
    private DataAccess _dataAccess;

    public MenuItemService()
    {
        _dataAccess = new DataAccess();
    }

    public List<MenuItem> GetAllMenuItems()
    {
        return _dataAccess.GetAllMenuItems();
    }

    public List<MenuItem> GetMenuItemsByCategory(MenuCategory category)
    {
        List<MenuItem> menuItemsByCategory = _dataAccess.GetAllMenuItems()
            .Where(x => x.Category == category)
            .ToList();

        return menuItemsByCategory;
    }

    public List<MenuItem> SearchMenuItemsByName(string searchValue)
    {
        if (string.IsNullOrWhiteSpace(searchValue))
        {
            return new List<MenuItem>();
        }

        List<MenuItem> filteredMenuItems = _dataAccess.GetAllMenuItems()
            .Where(x => x.Name.ToLower().Contains(searchValue.ToLower()))
            .ToList();

        return filteredMenuItems;
    }
}