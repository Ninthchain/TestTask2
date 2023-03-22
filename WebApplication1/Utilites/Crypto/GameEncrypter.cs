using System.Text;
using WebApplication1.Models;
using WebApplication1.Utilites.Crypto.Aes;

namespace WebApplication1.Utilites.Crypto
{
    public static class GameGeneratorManager
    {
        public static string GetUniqueId()
        {
            return AES5.Encrypt(StringGenerator.GetRandomString(32));
        }
    }
}
