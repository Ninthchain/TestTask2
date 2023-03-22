namespace WebApplication1.Models
{
    public enum PlayerToken
    {
        Cross,
        Circle
    }

    public class Player
    {
        private string _id;

        private string _name;

        private PlayerToken _token;

        public string Id 
        { 
            get => _id; 

            private set => _id = value; 
            
        }

        public string Name
        {
            get => _name;
            private set => _name = value; 
        }

        public PlayerToken token
        {
            get => _token;
            private set => _token = value;
        }

        public Player(string id, PlayerToken token) 
        {
            _id = id;
            _token = token;
        }
    }
}
