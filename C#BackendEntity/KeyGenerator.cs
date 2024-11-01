using System;
using System.Security.Cryptography;

namespace C_BackendEntity
{
    public class KeyGenerator
    {
        private static RandomNumberGenerator random = RandomNumberGenerator.Create();
        public static string GenerateRandomKey(int size) // Size in bytes
        {
            var key = new byte[size];
            random.GetBytes(key);
            return Convert.ToBase64String(key);

        }
    }
}
