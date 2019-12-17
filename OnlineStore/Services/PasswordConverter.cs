using System;
using System.Security.Cryptography;
using System.Globalization;
using System.Text;

namespace OnlineStore.Services
{
    public static class PasswordConverter
    {
        public static string Hash(string password)
        {
            MD5 hasher = MD5.Create();
            byte[] bpass = Encoding.UTF8.GetBytes(password);
            byte[] hash = hasher.ComputeHash(bpass);
            string shash = Encoding.UTF8.GetString(hash);
            return shash;
        }
        public static bool Compare(string password, string hash)
        {
            string hashpass = Hash(password);
            byte[] hhash = Encoding.UTF8.GetBytes(hash);
            byte[] hpass = Encoding.UTF8.GetBytes(hashpass);
            bool equal = true;
            for (int i = 0; i < hhash.Length; i++)
            {
                if (hhash[i] != hpass[i]) {
                    equal = false;
                }
            }
            return equal;
        }
    }
}
