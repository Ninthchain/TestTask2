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

        MapSlotValue value = game.CurentPlayer.Token == PlayerToken.Circle ? MapSlotValue.CircleOccupied : MapSlotValue.CrossOccupied;

        game.Map.SetValue(value, horizontalIndex, verticalIndex);

        return game.Map;
    }

    [HttpPost]
    [Route("[action]/firstPlayerId={id1}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public JsonResult CreateGame(string id1)
    {
        Game game;

        if (id1.IsNullOrEmpty() || id2.IsNullOrEmpty()) return Json(new
        {
            error = "The player id is null",
            statusCode = BadRequest().StatusCode
        });

        game = new(id1, id2);

        _context.Games.Add(game);

        return Json(game.State);
    }
}