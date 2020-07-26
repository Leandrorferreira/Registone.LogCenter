using System;
using System.Security.Cryptography;
using System.Text;

namespace Registone.LogCenter.Services
{
    public class Encryptor : IEncryptor
    {
        private string Hash { get; set; }

        public Encryptor()
        {
            Hash = GenerateKey();
        }
        
        public string Encrypt(string password)
        {
            var provider = new TripleDESCryptoServiceProvider();

            var md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteText;

            byteHash = md5.ComputeHash(Encoding.ASCII.GetBytes(Hash));
            byteText = Encoding.ASCII.GetBytes(password);

            md5.Clear();

            provider.Key = byteHash;
            provider.Mode = CipherMode.ECB;

            return Convert.ToBase64String(provider.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length));
        }

        public string Decrypt(string password)
        {
            var provider = new TripleDESCryptoServiceProvider();

            var md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteText;

            byteHash = md5.ComputeHash(Encoding.ASCII.GetBytes(Hash));
            byteText = Convert.FromBase64String(password);

            md5.Clear();

            provider.Key = byteHash;
            provider.Mode = CipherMode.ECB;

            return Encoding.ASCII.GetString(provider.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length));
        }

        private string GenerateKey()
        {
            return "AAF5B14D-ABDF-4B93-B1B1-94000B2668F4";
        }
    }
}
