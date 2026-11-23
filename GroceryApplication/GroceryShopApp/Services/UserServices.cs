using System.Security.Cryptography;
using System.Text;
using GroceryShopApp.Model;
using GroceryShopApp.Repository;

namespace GroceryShopApp.Services
{
    internal class UserServices
    {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        internal bool CreateUser(string fullName, string userName, string phone, string password)
        {
            if (this._userRepository.IsUserAlreadyExists(userName, phone))
            {
                return false;
            }

            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToHexString(hash).ToLowerInvariant();

            User user = new User
            {
                Name = fullName,
                UserName = userName,
                Phone = phone,
                Password = hashedPassword,
            };

            this._userRepository.AddUser(user);
            return true;
        }

        internal void GetUser(string? userName, string? password)
        {
            throw new NotImplementedException();
        }

        internal bool UserExists(string userName, string password)
        {
            if (this._userRepository.IsUserAlreadyExists(userName, password))
            {
                return true;
            }

            return false;
        }
    }
}
