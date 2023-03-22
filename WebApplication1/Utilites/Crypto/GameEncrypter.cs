using System.Text;
using WebApplication1.Models;
using WebApplication1.Utilites.Crypto.Aes;

namespace WebApplication1.Utilites.Crypto
{
    public static class Generator
    {
        public static string GetUniqueId() => AES5.Encrypt(StringGenerator.GetRandomString(32), AES5.GenerateKey());
    }
}
