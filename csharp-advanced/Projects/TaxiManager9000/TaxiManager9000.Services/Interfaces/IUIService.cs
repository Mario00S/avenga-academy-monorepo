using TaxiManager9000.Domain.BaseEntity;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Services.Enums;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IUIService
    {
        int ChooseMenu<T>(List<T> items);
        User LogInMenu();
        int MainMenu(Role role);
        List<MenuChoice> MenuItems { get; set; }
        int ChooseEntitiesMenu<T>(List<T> entities) where T : BaseEntity;
    }
}
