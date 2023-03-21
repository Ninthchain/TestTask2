using System.Text;
using WebApplication1.Models;
using WebApplication1.Utilites.Crypto.Aes;

namespace WebApplication1.Utilites.Crypto
{
    public static class Encrypter
    {
        public static string GetEncryptedId()
        {
            return AES5.Encrypt(StringGenerator.GetRandomString(32));
        }
    }
}
