namespace WebApplication1.Models
{
    public enum PlayerToken
    {
        Cross = 0,
        Circle = 1
    }

    public class Player
    {
        private string _id;

        private string _name;

        public string Id => _id;

        public string Name
        {
            get => _name;
            protected set => _name = value; 
        }

        public Player(string id) => _id = id;
    }
}
