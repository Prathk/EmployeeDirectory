using System;
using System.Text;

namespace EmployeeDirectory.Infrastructure
{
    public class PasswordService
    {

        private static string key = "mykey!";

        public static bool Verify(string password, string hashedPassword)
        {
            var newHashPassword = xorIt(password);
            if (hashedPassword.Equals(newHashPassword))
                return true;
            else
                return false;
        }

        public static string CreateHash(string password)
        {
            return xorIt(password);
        }

        private static string xorIt(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            String result = sb.ToString();

            return result;
        }
    }
}
