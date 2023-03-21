using WebApplication1.Utilites.Crypto;

namespace WebApplication1.Models
{
    public class Game
    {
        private string _id;

        private Player _player1;
        private Player _player2;

        private GameState _state;

        public GameState State => _state;

        public string Id => _id;


        public Player Player1 => _player1;
        public Player Player2 => _player2;

        public Game()
        {
            _id = Encrypter.GetEncryptedId();
        }
    }
}
