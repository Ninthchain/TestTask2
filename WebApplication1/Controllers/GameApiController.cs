using GameApi.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api-[controller]/")]
[ApiController]

public class GameController : Controller
{
    GameContext _context;

    public GameController(GameContext context)
    {
        _context = context;
    }

    [HttpGet]

    [Route("[action]/{gameId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public object GetGameState(string gameId)
    {
        Game? game;
        GameState result;


        if (gameId.IsNullOrEmpty()) return BadRequest(new { reason = "The gameId is null or empty" });

        game = _context.Games.Where(game => game.Id.Equals(gameId)).ElementAt(0);

        if (game is null) return NotFound(new { });

        result = game.State;

        return result;
    }

    [HttpPut]
    [Route("[action]/{gameId}/horizontalIndex={horizontalIndex}&verticalIndex={verticalIndex}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public object MakeMove(string gameId, int horizontalIndex, int verticalIndex)
    {
        Game? game;

        game = _context.Games.Where(game => game.Id.Equals(gameId)).ElementAt(0);

        if (game is null) return NotFound(new { });
        if (!game.Map.IsEmpty(horizontalIndex, verticalIndex)) return BadRequest(new { });

        if(game.State == GameState.TurnX)
        {
            game.Map.SetValue(MapSlotValue.CrossOccupied, horizontalIndex, verticalIndex);
        }

        return game.Map;
    }

    //I could do the real authentication to remove from http request second player id. But dont have so much time :((

    [HttpPost]
    [Route("[action]/game={gameId}&joiningPlayerId={playerId}")]
    public IActionResult Join(string gameId, string playerId)
    {
        Game? game = _context.Games
                            .Where(g => g.Id.ToString() == gameId)
                            .FirstOrDefault();

        if (game is null) return NotFound();

        game.SecondPlayer = new Player(playerId);
        game.State = (GameState)new Random().Next(1, 3);

        return Ok();
    }

    [HttpPost]
    [Route("[action]/creatorId={id1}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public JsonResult CreateGame(string id1)
    {
        if (id1.IsNullOrEmpty()) return Json(new
        {
            error = "The player id is null",
            statusCode = BadRequest().StatusCode
        });

        Game game = new();

        _context.Games.Add(game);

        return Json(game.State);
    }
}