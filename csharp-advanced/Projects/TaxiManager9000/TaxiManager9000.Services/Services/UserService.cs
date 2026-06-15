using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Models;
using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService() { }

        public User CurrentUser { get; set; }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (CurrentUser.Password != oldPassword || oldPassword == newPassword || !ValidationHelper.ValidatePassword(newPassword))
            {
                return false;
            }
            CurrentUser.Password = newPassword;
            bool isUpdated = Update(CurrentUser);
            return isUpdated;
        }

        public void CreateNewUser(string username, string password, Role role)
        {
            bool userExists = GetAll().Any(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
            if (userExists)
            {
                throw new Exception("User already exists!");
            }
            User newUser = new User(username, password, role);
            Insert(newUser);
        }

        public void LogIn(string username, string password)
        {
            User userDb = GetAll().SingleOrDefault(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            if (userDb is null)
            {
                throw new Exception("Login failed! Try again........");
            }

            CurrentUser = userDb;
        }
    }
}