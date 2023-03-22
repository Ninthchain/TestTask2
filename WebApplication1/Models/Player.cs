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

        private PlayerToken _token;

        public PlayerToken Token;

        public string Id => _id;

        public string Name
        {
            get => _name;
            protected set => _name = value; 
        }

        public PlayerToken token
        {
            get => _token;
            protected set => _token = value;
        }

        public Player(string id, PlayerToken token) 
        {
            _id = id;
            _token = token;
        }
    }
}
