using System.Security.Cryptography;
using System.Text;
using GroceryShopApp.Repository;

namespace GroceryShopApp.Services
{
    internal class AdminServices
    {
        private readonly UserRepository _userRepository;
        private readonly ProductRepository _productRepository;

        public AdminServices(UserRepository userRepository, ProductRepository productRepository)
        {
            this._userRepository = userRepository;
            this._productRepository = productRepository;
        }

        internal bool IsAdmin(string userName, string password)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToHexString(hash).ToLowerInvariant();

            if (this._userRepository.IsUserAdmin(userName, hashedPassword))
            {
                return true;
            }

            return false;
        }
    }
}