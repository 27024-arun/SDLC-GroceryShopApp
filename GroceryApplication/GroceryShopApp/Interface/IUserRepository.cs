using GroceryShopApp.Model;

namespace GroceryShopApp.Interface
{
    /// <summary>
    /// Defines the operations for the user repository.
    /// </summary>
    internal interface IUserRepository
    {
        /// <summary>
        /// Adds the user data to the repository.
        /// </summary>
        /// <param name="user">Data of user.</param>
        void AddUser(User user);

        /// <summary>
        /// Checks whether the user data already exists in repository.
        /// </summary>
        /// <param name="userName">Unique username of the user.</param>
        /// <param name="phone">Phone number of the user.</param>
        /// <returns>Returns whether the user already exists or not.</returns>
        bool IsUserAlreadyExists(string userName, string phone);

        /// <summary>
        /// Checks whether the user has already signed up or not.
        /// </summary>
        /// <param name="userName">Unique username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Returns whether the user is registered or not.</returns>
        bool IsRegisteredUser(string userName, string password);

        /// <summary>
        /// Checks whether the user has already signed up and checks if the user is admin.
        /// </summary>
        /// <param name="userName">Unique username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Returns whether the user is an admin or not.</returns>
        bool IsUserAdmin(string userName, string password);

        /// <summary>
        /// Checks whether the username exists or not.
        /// </summary>
        /// <param name="userName">Unique username of the user.</param>
        /// <returns>Returns whether the username exists or not.</returns>
        bool IsUserNameValid(string userName);

        /// <summary>
        /// Identifies whether the admin is already present or not.
        /// </summary>
        /// <returns>Returns whether an admin is present or not.</returns>
        bool IsAdminPresent();
    }
}