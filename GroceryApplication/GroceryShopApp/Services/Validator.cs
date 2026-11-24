namespace GroceryShopApp.Services
{
    /// <summary>
    /// Validates the fields for appropriate data usage.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Validates the user entered registering details.
        /// </summary>
        /// <param name="fullName">Full name of the user</param>
        /// <param name="userName">Unique username of the user</param>
        /// <param name="phone">Phone number of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>Returns whether the details entered are valid or not</returns>
        internal static string ValidateSignupFields(string? fullName, string? userName, string? phone, string? password)
        {
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(password))
            {
                return "Full-Name is invalid";
            }

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4 || userName.Length > 10)
            {
                return $"User Name is invalid";
            }

            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10 || !IsDigit(phone))
            {
                return $"Phone number is invalid";
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || !IsAlphaNumeric(password))
            {
                return $"Password is invalid";
            }

            return "passed";
        }

        /// <summary>
        ///  Validates the user entered log-in details.
        /// </summary>
        /// <param name="userName">Unique username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>Returns whether the details entered are valid or not</returns>
        internal static string ValidateLoginFields(string? userName, string? password)
        {
            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4 || userName.Length > 10)
            {
                return $"User Name is invalid";
            }

            if (string.IsNullOrWhiteSpace(password) || !IsAlphaNumeric(password) || password.Length < 8)
            {
                return $"Password is invalid";
            }

            return "passed";
        }

        private static bool IsAlphaNumeric(string data)
        {
            int digit = 0;
            int letter = 0;

            foreach (char c in data)
            {
                if (char.IsDigit(c))
                {
                    digit += 1;
                }

                if (char.IsLetter(c))
                {
                    letter += 1;
                }
            }

            return digit > 0 && letter > 0;
        }

        private static bool IsDigit(string data)
        {
            foreach (char c in data)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
