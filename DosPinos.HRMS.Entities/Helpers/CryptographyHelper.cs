using System.Security.Cryptography;
using System.Text;
using DosPinos.HRMS.Entities.Resources.Commons;

namespace DosPinos.HRMS.Entities.Helpers
{
    public static class CryptographyHelper
    {
        private static readonly byte[] Key = Convert.FromBase64String(Commons.SecretKey);
        private static readonly byte[] IV = Convert.FromBase64String(Commons.SecretIV);

        public static string Encrypt(string text)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using MemoryStream memoryStream = new();
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using BinaryWriter writer = new(cryptoStream);

            writer.Write(Encoding.UTF8.GetBytes(text));
            cryptoStream.FlushFinalBlock();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] buffer = Convert.FromBase64String(encryptedText);

            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using MemoryStream memoryStream = new(buffer);
            using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader reader = new(cryptoStream, Encoding.UTF8);

            return reader.ReadToEnd();
        }

        public static bool CompareEncryptedAndDecrypted(string originalText, string encryptedText)
        {
            string decryptedText = Decrypt(encryptedText);
            return string.Equals(originalText, decryptedText, StringComparison.Ordinal);
        }
    }
}