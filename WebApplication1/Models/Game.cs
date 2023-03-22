using WebApplication1.Utilites.Crypto;

namespace WebApplication1.Models
{
    public class Game
    {
        private (Player, Player) _players;

        private Player _currentPlayer;

        private string _id;

        private GameState _state;

        private GameMap _map;

        public Player CurentPlayer => _currentPlayer;

        public string Id => _id;

        public GameState State => _state;

        public GameMap Map => _map;

        public Game(string playerId1, string playerId2)
        {
            _state = new GameState();
            _map = new GameMap(new System.Drawing.Size(3, 3));


            _id = Generator.GetUniqueId();
            
            PlayerToken first_token = (PlayerToken) new Random().Next(0, 2);
            PlayerToken second_token = first_token == PlayerToken.Cross ? PlayerToken.Circle : PlayerToken.Cross;

            _players.Item1 = new Player(playerId1, first_token);
            _players.Item2
        }
    }
}
