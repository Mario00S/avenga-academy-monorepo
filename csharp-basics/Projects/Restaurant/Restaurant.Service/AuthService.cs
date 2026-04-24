using Restaurant.Domain;
using Restaurant.Domain.Models;

namespace Restaurant.Service
{
    public class AuthService
    {
        private DataAccess _dataAccess;

        public AuthService()
        {
            _dataAccess = new DataAccess();
        }

        public Admin? LoginAdmin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            Admin? admin = _dataAccess.GetAdmin(username, password);
            return admin;
        }

        public Waiter? LoginWaiter(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            Waiter? waiter = _dataAccess.GetWaiter(username, password);
            return waiter;
        }
    }
}
