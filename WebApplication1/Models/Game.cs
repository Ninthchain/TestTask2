using WebApplication1.Utilites.Crypto;

namespace WebApplication1.Models
{
    public class Game
    {
        private string _id;

        private Player _bluePlayer;
        private Player _redPlayer;

        private GameState _state;

        public GameState State => _state;

        public string Id => _id;


        public Player BluePlayer => _bluePlayer;
        public Player RedPlayer => _redPlayer;

        public Game(Player bluePlayer, Player redPlayer)
        {
            _id = GameGeneratorManager.GetUniqueId();
            _bluePlayer = bluePlayer;
            _redPlayer = redPlayer;
        }
    }
}
