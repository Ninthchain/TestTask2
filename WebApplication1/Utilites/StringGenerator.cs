namespace WebApplication1.Utilites
{
    public static class StringGenerator
    {
        public static string GetRandomString(int length)
        {
            Random random = new Random();

            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_=";

            return new string(Enumerable.Repeat(alphabet, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
