using System.Text.Json;
using GroceryShopApp.Model;

namespace GroceryShopApp.Repository
{
    internal class UserRepository
    {
        private readonly List<User> _users = new List<User>();
        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        public UserRepository(string filePath)
        {
            this._filePath = filePath;
            this._users = this.LoadAll();
        }

        internal void AddUser(User user)
        {
            this._users.Add(user);
            this.WriteAll();
        }

        internal bool IsUserAlreadyExists(string userName, string phone)
        {
            if (this._users.Any(user => user.UserName == userName || user.Phone == phone))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool IsRegisteredUser(string userName, string password)
        {
            if (this._users.Any(user => user.UserName == userName && user.Password == password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal User? GetUser(string userName, string password)
        {
            return this._users.FirstOrDefault(user => user.UserName == userName && user.Password == password);
        }

        private void WriteAll()
        {
            string fileData = JsonSerializer.Serialize(this._users, this._options);
            File.WriteAllText(this._filePath, fileData);
        }

        private List<User> LoadAll()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<User>();
            }

            string fileData = File.ReadAllText(this._filePath);
            return JsonSerializer.Deserialize<List<User>>(fileData, this._options) ?? new List<User>();
        }
    }
}