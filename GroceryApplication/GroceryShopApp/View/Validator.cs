namespace GroceryShopApp.View
{
    internal static class Validator
    {
        internal static bool ValidateSignupFields(string? fullName, string? userName, string? phone, string? password)
        {
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (phone.Length != 10 || !IsDigit(phone))
            {
                return false;
            }

            if (!IsAlphaNumeric(password))
            {
                return false;
            }

            return true;
        }

        internal static bool ValidateLoginFields(string? userName, string? password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (!IsAlphaNumeric(password))
            {
                return false;
            }

            return true;
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
