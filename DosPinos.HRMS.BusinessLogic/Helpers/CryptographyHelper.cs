﻿namespace DosPinos.HRMS.BusinessLogic.Helpers
{
    internal static class CryptographyHelper
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
            using StreamWriter writer = new(cryptoStream);

            writer.Write(text);
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
            using StreamReader reader = new(cryptoStream);

            return reader.ReadToEnd();
        }

        public static bool CompareEncryptedAndDecrypted(string originalText, string encryptedText)
        {
            string decryptedText = Decrypt(encryptedText);
            return string.Equals(originalText, decryptedText, StringComparison.Ordinal);
        }
    }
}