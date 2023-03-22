using GameApi.Enum;
using WebApplication1.Utilites.Crypto;

namespace WebApplication1.Models
{
    public class Game
    {

        private Guid _id;


        private GameMap _map;


        public Guid Id => _id;

        public GameState State { get; set; }

        public GameMap Map => _map;

        public Player FirstPlayer { get; set; }

        public Player SecondPlayer { get; set; }

        public Game()
        {
            State = new GameState();
            _map = new GameMap(new System.Drawing.Size(3, 3));
            _id = Guid.NewGuid();
        }

        public bool IsFull() => FirstPlayer is not null && SecondPlayer is not null;
    }
}
