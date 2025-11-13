using System.Security.Cryptography;
using System.Text;

namespace PracticandoWebApiParcialDos.Utils
{
    public static class PasswordEncryption
    {
        private static readonly string Key = "adrianlayme2025_key_segura";
        private static readonly string IV = "presi_vector_1234";

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key.Substring(0, 32));
            aes.IV = Encoding.UTF8.GetBytes(IV.Substring(0, 16));

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var plainBytes = Encoding.UTF8.GetBytes(plainText);

            var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key.Substring(0, 32));
            aes.IV = Encoding.UTF8.GetBytes(IV.Substring(0, 16));

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var cipherBytes = Convert.FromBase64String(encryptedText);

            var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
