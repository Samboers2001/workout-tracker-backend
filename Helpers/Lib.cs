using System.Linq;

namespace workout_tracker_backend.Helpers
{
    public class Lib
    {
        public bool IsValidPassword(string password)
        {
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit) || password.Length < 5)
            {
                return false;
            }
            return true;
        }
        public bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool EmailIsEmpty(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return true;
        }
        public bool PasswordIsEmpty(string password)
        {
            if (string.IsNullOrEmpty(password))           
            {
                return false;
            }
            return true;
        }
        public bool NameIsEmpty(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }    }
}