using TaxiManager9000.Domain.Models;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService() { }

        public User CurrentUser { get; set; }

        public void LogIn(string username, string password)
        {
            User userDb = GetAll().SingleOrDefault(x=> x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            if (userDb is null)
            {
                throw new Exception("Login failed! Try again........");
            }

            CurrentUser = userDb;
        }
    }
}
