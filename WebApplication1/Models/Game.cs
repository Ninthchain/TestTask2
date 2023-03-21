using WebApplication1.Models.Dto;

namespace WebApplication1.Models
{
    public class Game
    {
        public GameState CurrentState { get; set; }

        public int Id { get; }
        
        public Game(int uniqueId)
        {
            Id = uniqueId;
        }
    }
}
