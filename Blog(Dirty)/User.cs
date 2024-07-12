using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Dirty_
{
    public class User
    {
        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; // Adjust the size based on your security requirements
                rng.GetBytes(salt);
                return salt;
            }
        }
        static byte[] salt = GenerateSalt();
        static string HashPassword(string password)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }

        private bool CheckPassword(string password, byte[] hashedPassword)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Compare hashedBytes with the hashedPassword
                for (int i = 0; i < hashedPassword.Length; i++)
                {
                    if (hashedBytes[i] != hashedPassword[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public string DehashPassword(string hashedPasswordWithSaltBase64, string[] dictionary)
        {
            byte[] hashedPasswordWithSalt = Convert.FromBase64String(hashedPasswordWithSaltBase64);

            // Extract the hashed password part (assuming the hash is SHA-256, so 32 bytes)
            byte[] hashedPassword = new byte[32];
            Buffer.BlockCopy(hashedPasswordWithSalt, salt.Length, hashedPassword, 0, hashedPassword.Length);

            foreach (var password in dictionary)
            {
                if (CheckPassword(password, hashedPassword))
                {
                    return password;
                }
            }

            return null; // Return null if no match found
        }
        public string Password
        {
            get
            {
                return DehashPassword(Password, new string[] { salt.ToString() });
            }
            set
            {
                value = HashPassword(value);
            }
        }
        public string UserName { get; set; }
    }
}
