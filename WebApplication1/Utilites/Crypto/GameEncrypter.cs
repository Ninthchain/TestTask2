using System.Text;
using WebApplication1.Models;
using WebApplication1.Utilites.Crypto.Aes;

namespace WebApplication1.Utilites.Crypto
{
    public static class GameEncrypter
    {

        public static string GetEncryptedGameId()
        {
            return AES5.Encrypt(GetRandomString(32));
        }

        private static string GetRandomString(int length)
        {
            Random random = new Random();

            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_=";

            return new string(Enumerable.Repeat(alphabet, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
