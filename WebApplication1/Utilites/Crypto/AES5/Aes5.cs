using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Utilites.Crypto.Aes
{
    public static class AES5
    {
        public static string Encrypt(string data)
        {
            MD5 keyHash = MD5.Create();

            byte[] key = keyHash.ComputeHash(Encoding.ASCII.GetBytes(StringGenerator.GetRandomString(32)));

            using (AesCryptoServiceProvider AEScryptoProvider = new() { BlockSize = 128, KeySize = 256, Key = key})
            {
                AEScryptoProvider.GenerateIV();

                AEScryptoProvider.Mode = CipherMode.CBC;
                AEScryptoProvider.Padding = PaddingMode.PKCS7;

                byte[] byteData = ASCIIEncoding.ASCII.GetBytes(data);
                byte[] encryptedData = AEScryptoProvider.CreateEncryptor(AEScryptoProvider.Key, AEScryptoProvider.IV).TransformFinalBlock(byteData, 0, byteData.Length);

                string? v = MD5.HashData(encryptedData).ToString();

                return v;
            }
        }
    }
}
