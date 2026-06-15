using TaxiManager9000.Domain.Models;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IUIService
    {
        int ChooseMenu<T>(List<T> items);
        User LogInMenu();
    }
}
